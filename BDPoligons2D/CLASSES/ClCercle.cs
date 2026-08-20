using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPoligons2D.CLASSES
{
    public class ClCercle : ClPoligon
    {
        private int Radi { get; set; }

        public ClCercle(Form xfMain, Point xcentre, int xradi) : base(xfMain, xcentre)
        {
            Radi = xradi;
            dibuixarFigura();
        }

        public ClCercle(Form xfMain, Point xcentre, Color xcolor, int xradi) : base(xfMain, xcentre, xcolor)
        {
            Radi = xradi;
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            int diametre = Radi * 2;
            pnl.Size = new Size(diametre, diametre);
            pnl.Location = new Point(posCentre.X - Radi, posCentre.Y - Radi);
            pnl.Paint += (s, e) => {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Rectangle r = new Rectangle(0, 0, diametre - 1, diametre - 1);
                if (teInterior) e.Graphics.FillEllipse(new SolidBrush(colorInterior), r);
                e.Graphics.DrawEllipse(new Pen(Color.Black, 2), r);
            };
            fMain.Controls.Add(pnl);
            pnl.BringToFront();
        }

        public override double Area() => Math.PI * Math.Pow(Radi, 2);

        public override Double Perimetre() => 2 * Math.PI * Radi;

        public override void Escalar(float e)
        {
            Radi = (int)(Radi * e);
            dibuixarFigura();
        }
    }
}
