using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPoligons2D.CLASSES
{
    public class ClRectangle : ClPoligon
    {
        public int Amplada { get; set; }
        public int Altura { get; set; }

        public ClRectangle(Form xfMain, Point xcentre, int w, int h, Color? xcolor = null) : base(xfMain, xcentre)
        {
            Amplada = w; Altura = h;
            if (xcolor.HasValue) { colorInterior = xcolor.Value; teInterior = true; }
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            pnl.Size = new Size(Amplada, Altura);
            pnl.Location = new Point(posCentre.X - Amplada / 2, posCentre.Y - Altura / 2);
            pnl.Paint += (s, e) => {
                Rectangle r = new Rectangle(0, 0, Amplada - 1, Altura - 1);
                if (teInterior) e.Graphics.FillRectangle(new SolidBrush(colorInterior), r);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 2), r);
            };
            fMain.Controls.Add(pnl);
        }

        public override double Area() => Amplada * Altura;

        public override Double Perimetre() => 2 * (Amplada + Altura);

        public override void Escalar(float e)
        {
            Amplada = (int)(Amplada * e);
            Altura = (int)(Altura * e);
            dibuixarFigura();
        }
    }
}
