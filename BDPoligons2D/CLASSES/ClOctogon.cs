using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPoligons2D.CLASSES
{
    public class ClOctogon : ClPoligon
    {
        private int Radi { get; set; }
        private const int Costats = 8;

        public ClOctogon(Form xf, Point xc, int r) : base(xf, xc)
        {
            Radi = r;
            dibuixarFigura();
        }

        public ClOctogon(Form xf, Point xc, Color col, int r) : base(xf, xc, col)
        {
            Radi = r;
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            pnl.Size = new Size(Radi * 2, Radi * 2);
            pnl.Location = new Point(posCentre.X - Radi, posCentre.Y - Radi);
            pnl.Paint += (s, e) => {
                PointF[] pts = calcularVertexs();
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                if (colorInterior != Color.Empty) e.Graphics.FillPolygon(new SolidBrush(colorInterior), pts);
                e.Graphics.DrawPolygon(new Pen(Color.Black, 2), pts);
            };
            fMain.Controls.Add(pnl);
            pnl.BringToFront();
        }

        private PointF[] calcularVertexs()
        {
            PointF[] pts = new PointF[Costats];
            for (int i = 0; i < Costats; i++)
            {
                double angle = 2 * Math.PI * i / Costats - Math.PI / 2;
                pts[i] = new PointF(Radi + (float)(Radi * Math.Cos(angle)), Radi + (float)(Radi * Math.Sin(angle)));
            }
            return pts;
        }

        public override double Area() => 0.5 * Costats * Math.Pow(Radi, 2) * Math.Sin(2 * Math.PI / Costats);

        // Implementación para ClPentagon (n=5), ClHexagon (n=6), etc.
        public override Double Perimetre()
        {
            int n = 8; // Cambiar según la figura (6 para hexágono, 7 heptágono, 8 octógono)
            double costat = 2 * Radi * Math.Sin(Math.PI / n);
            return n * costat;
        }

        public override void Escalar(float e)
        {
            Radi = (int)(Radi * e);
            dibuixarFigura();
        }
    }
}
