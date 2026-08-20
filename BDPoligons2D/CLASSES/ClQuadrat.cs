using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BDPoligons2D
{
    public class ClQuadrat : ClPoligon          // ClPoligons és la superclasse de la que es deriva ClQuadrat
    {
        private int Mida { get; set; }   // mida del costat del quadrat
        private Point posVertex { get; set; }   // posició on quedarà el vèrtex superior esquerre depenent del centre i la mida

        // constructor per a un quadrat sense interior 
        // : base(.....) ve determinat per l'herència del constructor genèric de la superclasse ClPoligons
        public ClQuadrat(Form xfMain, Point xcentre, int xmida) : base(xfMain, xcentre)     
        {
            Mida = xmida;
            dibuixarFigura();
        }

        // constructor per a un quadrat amb interior (2on constructor - sobrecàrrega)
        public ClQuadrat(Form xfMain, Point xcentre, Color xcolor, int xmida) : base(xfMain, xcentre, xcolor)
        {
            Mida = xmida;
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            posVertex = new Point((int)(posCentre.X - (Mida / 2)), (int)(posCentre.Y - (Mida / 2)));
            pnl.Size = new Size(Mida, Mida);
            pnl.Location = posVertex;
            pnl.Paint += new PaintEventHandler(ferQuadrat);
            fMain.Controls.Add(pnl);
            pnl.BringToFront();
        }

        // pinta el quadrat dins el Panel
        private void ferQuadrat(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 2);   // Pen per a traçar el contorn que farem de color negre i de 2 pixels de gruix

            Rectangle r=new Rectangle(new Point(0,0),new Size(Mida, Mida));
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (colorInterior != Color.Empty)
            {
                e.Graphics.FillRectangle(new SolidBrush(colorInterior), r);
            }
            e.Graphics.DrawRectangle(p, r);
        }

        // retorna l'àrea de la figura mesurada en pixels
        public override Double Area()
        {
            return (Mida * Mida);
        }

        public override Double Perimetre() => Mida * 4;

        public override void Escalar(float e)
        {
            Mida = (int)(Mida * e);
            dibuixarFigura();
        }

    }
}
