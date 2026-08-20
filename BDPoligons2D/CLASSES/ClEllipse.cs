using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BDPoligons2D.CLASSES
{
    public class ClEllipse : ClPoligon
        {
            public int RadiX { get; set; }
            public int RadiY { get; set; }

            public ClEllipse(Form xfMain, Point xcentre, int rx, int ry, Color? xcolor = null) : base(xfMain, xcentre)
            {
                RadiX = rx; RadiY = ry;
                if (xcolor.HasValue) { colorInterior = xcolor.Value; teInterior = true; }
                dibuixarFigura();
            }



            private void dibuixarFigura()
            {
                pnl.Size = new Size(RadiX * 2, RadiY * 2);
                pnl.Location = new Point(posCentre.X - RadiX, posCentre.Y - RadiY);
                pnl.Paint += (s, e) => {
                    Rectangle r = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
                    if (teInterior) e.Graphics.FillEllipse(new SolidBrush(colorInterior), r);
                    e.Graphics.DrawEllipse(new Pen(Color.Black, 2), r);
                };
                fMain.Controls.Add(pnl);
            }

            public override double Area() => Math.PI * RadiX * RadiY;

        public override Double Perimetre()
        {
            double a = RadiX;
            double b = RadiY;
            return Math.PI * (3 * (a + b) - Math.Sqrt((3 * a + b) * (a + 3 * b)));
        }

        public override void Escalar(float e)
        {
            RadiX = (int)(RadiX * e);
            RadiY = (int)(RadiY * e);
            dibuixarFigura();
        }
    }
}
