using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPoligons2D.CLASSES
{
    public class ClTriangleIsosceles : ClPoligon
    {
        private int Base { get; set; }
        private int Altura { get; set; }

        public ClTriangleIsosceles(Form xfMain, Point xcentre, int xbase, int xaltura) : base(xfMain, xcentre)
        {
            Base = xbase;
            Altura = xaltura;
            dibuixarFigura();
        }

        public ClTriangleIsosceles(Form xfMain, Point xcentre, Color xcolor, int xbase, int xaltura) : base(xfMain, xcentre, xcolor)
        {
            Base = xbase;
            Altura = xaltura;
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            pnl.Size = new Size(Base, Altura);
            pnl.Location = new Point(posCentre.X - (Base / 2), posCentre.Y - (Altura / 2));
            pnl.Paint += (s, e) => {
                Point[] pts = { new Point(Base / 2, 0), new Point(Base, Altura), new Point(0, Altura) };
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                if (teInterior) e.Graphics.FillPolygon(new SolidBrush(colorInterior), pts);
                e.Graphics.DrawPolygon(new Pen(Color.Black, 2), pts);
            };
            fMain.Controls.Add(pnl);
            pnl.BringToFront();
        }

        public override Double Area() => (Base * Altura) / 2.0;

        public override Double Perimetre()
        {
            double costatIgual = Math.Sqrt(Math.Pow(Base / 2.0, 2) + Math.Pow(Altura, 2));
            return Base + (2 * costatIgual);
        }

        public override void Escalar(float e)
        {
            Base = (int)(Base * e);
            Altura = (int)(Altura * e);
            dibuixarFigura();
        }
    }
}
