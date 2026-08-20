using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BDPoligons2D
{
    // Respecte a la pràctica sense BD he canviat el nom d'aquesta classe i ara es diu ClTriangle
    // i segons el tipus de triangle que es vulgui es dibuixa d'una manera o altra

    public class ClTriangleRectangle : ClPoligon                 // ClPoligons és la superclasse de la que es deriva ClQuadrat
    {
        public int Width { get; private set; }
        public int Height { get; private set; }    

        private Point posVertex { get; set; }   // posició on quedarà el vèrtex superior esquerre depenent del centre i la mida

        // constructor per a un quadrat sense interior 
        // : base(.....) ve determinat per l'herència del constructor genèric de la superclasse ClPoligons
        public ClTriangleRectangle(Form xfMain, Point xcentre, int xwidth, int xheight) : base(xfMain, xcentre)     
        {
            Width = xwidth;
            Height = xheight;
            dibuixarFigura();
        }


        // constructor per a un quadrat amb interior (2on constructor - sobrecàrrega)
        public ClTriangleRectangle(Form xfMain, Point xcentre, Color xcolor, int xwidth, int xheight) : base(xfMain, xcentre, xcolor)
        {
            Width = xwidth;
            Height = xheight;
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            posVertex = new Point((int)(posCentre.X - (Width / 2)), (int)(posCentre.Y - (Height / 2)));
            pnl.Size = new Size(Width, Height);
            pnl.Location = posVertex;
            pnl.Paint += new PaintEventHandler(ferTriangleRectangle);
            fMain.Controls.Add(pnl);
            pnl.BringToFront();
        }

        // pinta el quadrat dins el Panel
        private void ferTriangleRectangle(object sender, PaintEventArgs e)
        {
            Point[] vPunts=null;
            Pen p = new Pen(Color.Black, 2);   // Pen per a traçar el contorn que farem de color negre i de 2 pixels de gruix

            vPunts=new Point[4] { new Point(0, 0), new Point(0, Height), new Point(Width, Height), new Point(0, 0) };
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (colorInterior != Color.Empty)
            {
                e.Graphics.FillPolygon(new SolidBrush(colorInterior), vPunts);
            }
            e.Graphics.DrawPolygon(p, vPunts);
        }

        // retorna l'àrea de la figura mesurada en pixels
        public override Double Area()
        {
            return (Width*Height/2.0);
        }

        public override Double Perimetre()
        {
            // Calculamos la hipotenusa: raíz cuadrada de (ancho² + alto²)
            double hipotenusa = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
            return Width + Height + hipotenusa;
        }

        public override void Escalar(float e)
        {
            // El 'private set' permite modificarlo desde dentro de la clase
            Width = (int)(Width * e);
            Height = (int)(Height * e);

            // Es vital llamar a dibuixarFigura para actualizar el tamaño del Panel y la posición
            dibuixarFigura();
        }

    }
}
