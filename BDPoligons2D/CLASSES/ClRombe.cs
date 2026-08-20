using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPoligons2D.CLASSES
{
    public class ClRombe : ClPoligon
    {
        public int DiagMajor { get; set; }
        public int DiagMenor { get; set; }

        public ClRombe(Form xfMain, Point xcentre, int dMaj, int dMin, Color? xc = null) : base(xfMain, xcentre)
        {
            DiagMajor = dMaj; DiagMenor = dMin;
            if (xc.HasValue) { colorInterior = xc.Value; teInterior = true; }
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            pnl.Size = new Size(DiagMenor, DiagMajor);
            pnl.Location = new Point(posCentre.X - DiagMenor / 2, posCentre.Y - DiagMajor / 2);
            pnl.Paint += (s, e) => {
                Point[] pts = {
                new Point(pnl.Width / 2, 0),
                new Point(pnl.Width, pnl.Height / 2),
                new Point(pnl.Width / 2, pnl.Height),
                new Point(0, pnl.Height / 2)
            };
                if (teInterior) e.Graphics.FillPolygon(new SolidBrush(colorInterior), pts);
                e.Graphics.DrawPolygon(new Pen(Color.Black, 2), pts);
            };
            fMain.Controls.Add(pnl);
        }
        public override double Area() => (DiagMajor * DiagMenor) / 2.0;

        public override Double Perimetre()
        {
            double costat = Math.Sqrt(Math.Pow(DiagMajor / 2.0, 2) + Math.Pow(DiagMenor / 2.0, 2));
            return costat * 4;
        }

        public override void Escalar(float e)
        {
            DiagMajor = (int)(DiagMajor * e);
            DiagMenor = (int)(DiagMenor * e);
            dibuixarFigura();
        }
    }
}
