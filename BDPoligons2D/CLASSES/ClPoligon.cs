using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace BDPoligons2D
{

    public abstract class ClPoligon
    {
        protected Form fMain { get; set; }                   // panell on es dibuixarà el polígon
        protected private Panel pnl { get; set; } =new Panel(); // panell dins el qual es dibuixa el polígon

        protected Point posCentre { get; set; }                 // posició del centre del Panel   
        protected Color colorInterior { get; set; }             // color de l'interior
        protected Boolean teInterior { get; set; }              // indica si té interior

        // Constructor 1 - No hi ha color interior
        protected ClPoligon(Form xfMain, Point xpos)
        {
            fMain = xfMain;
            colorInterior = Color.Empty;
            teInterior = false;
            posCentre = xpos;
            iniPanell();
        }

        // Constructor 2 - Hi ha color interior
        protected ClPoligon(Form xfMain, Point xpos, Color xcolor)
        {   
            fMain = xfMain;
            colorInterior = xcolor;
            teInterior = true;
            posCentre = xpos;
            iniPanell();
        }

        protected private void iniPanell()
        {
            pnl.Click += new EventHandler(nouColor);        // si es fa clic a la figura canvia el color aleatòriament

            pnl.DoubleClick += (s, e) => {
                ((FrmMain)fMain).eliminarFiguraIndividual(this);
            };
        }

        // aquest mètode serà comú a totes les subclasses
        protected private void nouColor(object sender, EventArgs e)
        {
            Random R=new Random();
            List<Color> llColors = new List<Color> { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Cyan, Color.Magenta, Color.Black, Color.White, Color.Gray, Color.Orange, Color.Pink, Color.Purple, Color.Brown, Color.Lime, Color.Teal, Color.Olive, Color.Navy, Color.Maroon, Color.Silver, Color.Goldenrod, Color.DarkRed, Color.DarkGreen, Color.DarkBlue, Color.DarkCyan, Color.DarkMagenta, Color.DarkGray, Color.LightGray, Color.LightPink, Color.LightBlue, Color.LightGreen, Color.LightYellow, Color.LightCyan, Color.LightCoral, Color.LightSeaGreen, Color.LightGoldenrodYellow, Color.MidnightBlue, Color.MistyRose, Color.LavenderBlush, Color.Honeydew, Color.ForestGreen, Color.Fuchsia, Color.AliceBlue, Color.AntiqueWhite, Color.Aquamarine, Color.Beige, Color.Bisque, Color.BlanchedAlmond, Color.Chartreuse, Color.Coral, Color.CornflowerBlue, Color.Cornsilk };

            if (colorInterior != Color.Empty)
            {
                colorInterior = llColors[R.Next(0, llColors.Count)];        // busquem un nou color aleatòriament
                pnl.Refresh();  // redibuixem el Panel
            }
        }

        // eliminem el panell del polígon del form
        public void eliminarPanell()
        {
            fMain.Controls.Remove(pnl);
        }

        // calcula i retorna l'àrea de la figura mesurada en pixels

        public abstract Double Perimetre();

        public abstract void Escalar(float e);

        public abstract Double Area();

        public void eliminar()
        {
            eliminarPanell();
            pnl.Dispose();
        }
    }
}
