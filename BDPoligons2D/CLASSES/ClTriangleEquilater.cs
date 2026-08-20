using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPoligons2D.CLASSES
{
    public class ClTriangleEquilater : ClPoligon
    {
        private int Costat { get; set; }
        private int Altura { get; set; }

        public ClTriangleEquilater(Form xfMain, Point xcentre, Color xcol, int xcostat) : base(xfMain, xcentre)
        {
            Costat = xcostat;
            colorInterior = xcol;

            if (xcol != Color.Empty)
            {
                teInterior = true;
            }

            Altura = (int)(Math.Sqrt(3) / 2 * Costat);
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            pnl.Size = new Size(Costat, Altura);
            pnl.Location = new Point(posCentre.X - (Costat / 2), posCentre.Y - (Altura / 2));
            pnl.Paint += (s, e) => {
                Point[] pts = { new Point(Costat / 2, 0), new Point(Costat, Altura), new Point(0, Altura) };

                if (teInterior)
                {
                    e.Graphics.FillPolygon(new SolidBrush(colorInterior), pts);
                }

                e.Graphics.DrawPolygon(new Pen(Color.Black, 2), pts);
            };
            fMain.Controls.Add(pnl);
        }

        public override Double Area() => (Math.Sqrt(3) / 4) * Math.Pow(Costat, 2);

        public override Double Perimetre() => Costat * 3;

        public override void Escalar(float e)
        {
            Costat = (int)(Costat * e);
            Altura = (int)(Math.Sqrt(3) / 2 * Costat);
            dibuixarFigura();
        }
    }
}
