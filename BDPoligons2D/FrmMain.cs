using BDPoligons2D.CLASSES;
using BDPoligons2D.CLASSES.ClassesBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPoligons2D
{
    public partial class FrmMain : Form
    {
        private ClFitxerConnexioBD fitxerConnexioBD { get; set; }
        private ClBdMySQL bd { get; set; }

        String figura = "Quadrat";

        List<ClPoligon> llPoligons { get; set; } = new List<ClPoligon>();
        List<ClPoligonBD> llPoligonsBD { get; set; } = new List<ClPoligonBD>();

        List<ClQuadrat> llQuadrats { get; set; } = new List<ClQuadrat>();
        List<ClTriangleRectangle> llTrianglesRectangles { get; set; } = new List<ClTriangleRectangle>();
        List<ClTriangleIsosceles> llTrianglesIsosceles { get; set; } = new List<ClTriangleIsosceles>();
        List<ClTriangleEquilater> llTrianglesEquilaters { get; set; } = new List<ClTriangleEquilater>();
        List<ClRectangle> llRectangles { get; set; } = new List<ClRectangle>();
        List<ClCercle> llCercles { get; set; } = new List<ClCercle>();
        List<ClEllipse> llEllipses { get; set; } = new List<ClEllipse>();
        List<ClRombe> llRombes { get; set; } = new List<ClRombe>();
        List<ClPentagon> llPentagons { get; set; } = new List<ClPentagon>();
        List<ClHexagon> llHexagons { get; set; } = new List<ClHexagon>();
        List<ClHeptagon> llHeptagons { get; set; } = new List<ClHeptagon>();
        List<ClOctogon> llOctogons { get; set; } = new List<ClOctogon>();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            iniUI();
            if (connexioBD())
            {
                getDades();
                dibuixarPoligons();
            }
            else
            {
                this.Close();
            }
        }

        private void iniUI()
        {
            pnlConfig.Height = this.Height;
            lbEstat.Top = this.Height - lbEstat.Height - 70;
            btDelTots.Top = this.Height - btDelTots.Height - 70;
            btDelSeleccio.Top = btDelTots.Top - btDelSeleccio.Height - 10;
            btAreaTotal.Top = btDelSeleccio.Top - btAreaTotal.Height - 10;
            btAreaSeleccio.Top = btAreaTotal.Top - btAreaSeleccio.Height - 10;
        }

        private bool connexioBD()
        {
            Boolean xb = false;

            fitxerConnexioBD = new ClFitxerConnexioBD();
            if (fitxerConnexioBD.getCadenaConnexio().Trim() != "")
            {
                xb = activarConnexio();
            }
            else
            {
                MessageBox.Show("No hi ha cap cadena de connexió. Abans de res has d'establir la connexió amb la base de dades.", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return xb;
        }

        private Boolean activarConnexio()
        {
            Boolean xb = false;

            if (bd != null && bd.hihaConnexio())
            {
                bd.tancarConnexio();
            }

            fitxerConnexioBD = new ClFitxerConnexioBD();
            bd = new ClBdMySQL(fitxerConnexioBD.getCadenaConnexio());
            if (!(bd.testConnexio()))
            {
                MessageBox.Show("No he pogut connectar amb la base de dades." + Environment.NewLine + "Revisa que el servidor estigui actiu i que la cadena de connexió sigui correcta.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                xb = true;
            }
            return (xb);
        }

        private void getDades()
        {
            DataTable dtPoligons = ClPoligonBD.getIdTipusPoligons(bd);
            llPoligonsBD.Clear();

            foreach (DataRow fila in dtPoligons.Rows)
            {
                ClPoligonBD pBD = null;
                long id = Int64.Parse(fila["IdPoligon"].ToString());
                string tipus = fila["NomTipusPoligon"].ToString();

                switch (tipus)
                {
                    case "Quadrat": pBD = new ClQuadratBD(); break;
                    case "Triangle Rectangle": pBD = new ClTriangleRectangleBD(); break;
                    case "Triangle Isòsceles": pBD = new ClTriangleIsoscelesBD(); break;
                    case "Triangle Equilàter": pBD = new ClTriangleEquilaterBD(); break;
                    case "Rectangle": pBD = new ClRectangleBD(); break;
                    case "Cercle": pBD = new ClCercleBD(); break;
                    case "Ellipse": pBD = new ClEllipseBD(); break;
                    case "Rombe": pBD = new ClRombeBD(); break;
                    case "Pentàgon": pBD = new ClPentagonBD(); break;
                    case "Hexàgon": pBD = new ClHexagonBD(); break;
                    case "Heptàgon": pBD = new ClHeptagonBD(); break;
                    case "Octògon": pBD = new ClOctogonBD(); break;
                }

                if (pBD != null)
                {
                    pBD.getDadesPoligon(bd, id);
                    llPoligonsBD.Add(pBD);
                }
            }
        }

        private void dibuixarPoligons()
        {
            foreach (ClPoligonBD pBD in llPoligonsBD)
            {
                Color c = pBD.colorInterior;
                Point pos = pBD.posCentre;
                ClPoligon p = null;

                switch (pBD.tipusPoligon)
                {
                    case "Quadrat":
                        p = (c == Color.Empty) ? new ClQuadrat(this, pos, ((ClQuadratBD)pBD).Mida) : new ClQuadrat(this, pos, c, ((ClQuadratBD)pBD).Mida);
                        llQuadrats.Add((ClQuadrat)p);
                        break;

                    case "Triangle Rectangle":
                        p = (c == Color.Empty) ? new ClTriangleRectangle(this, pos, ((ClTriangleRectangleBD)pBD).Amplada, ((ClTriangleRectangleBD)pBD).Alcada) : new ClTriangleRectangle(this, pos, c, ((ClTriangleRectangleBD)pBD).Amplada, ((ClTriangleRectangleBD)pBD).Alcada);
                        llTrianglesRectangles.Add((ClTriangleRectangle)p);
                        break;

                    case "Triangle Isòsceles":
                        p = (c == Color.Empty) ? new ClTriangleIsosceles(this, pos, ((ClTriangleIsoscelesBD)pBD).Base, ((ClTriangleIsoscelesBD)pBD).Altura) : new ClTriangleIsosceles(this, pos, c, ((ClTriangleIsoscelesBD)pBD).Base, ((ClTriangleIsoscelesBD)pBD).Altura);
                        llTrianglesIsosceles.Add((ClTriangleIsosceles)p);
                        break;

                    case "Triangle Equilàter":
                        p = new ClTriangleEquilater(this, pos, c, ((ClTriangleEquilaterBD)pBD).Costat);

                        llTrianglesEquilaters.Add((ClTriangleEquilater)p);
                        break;

                    case "Rectangle":
                        p = (c == Color.Empty) ? new ClRectangle(this, pos, ((ClRectangleBD)pBD).Amplada, ((ClRectangleBD)pBD).Altura) : new ClRectangle(this, pos, ((ClRectangleBD)pBD).Altura, ((ClRectangleBD)pBD).Amplada,c);
                        llRectangles.Add((ClRectangle)p);
                        break;

                    case "Cercle":
                        p = (c == Color.Empty) ? new ClCercle(this, pos, ((ClCercleBD)pBD).Radi) : new ClCercle(this, pos, c, ((ClCercleBD)pBD).Radi);
                        llCercles.Add((ClCercle)p);
                        break;

                    case "Ellipse":
                        Color? colEli = (c == Color.Empty) ? (Color?)null : c;
                        p = new ClEllipse(this, pos, ((ClEllipseBD)pBD).RadiX, ((ClEllipseBD)pBD).RadiY, colEli);
                        llEllipses.Add((ClEllipse)p);
                        break;

                    case "Rombe":
                        Color? colRombe = (c == Color.Empty) ? (Color?)null : c;
                        p = new ClRombe(this, pos, ((ClRombeBD)pBD).DiagMajor, ((ClRombeBD)pBD).DiagMenor, colRombe);
                        llRombes.Add((ClRombe)p);
                        break;

                    case "Pentàgon":
                        p = (c == Color.Empty) ? new ClPentagon(this, pos, ((ClPentagonBD)pBD).Radi) : new ClPentagon(this, pos, c, ((ClPentagonBD)pBD).Radi);
                        llPentagons.Add((ClPentagon)p);
                        break;

                    case "Hexàgon":
                        p = (c == Color.Empty) ? new ClHexagon(this, pos, ((ClHexagonBD)pBD).Radi) : new ClHexagon(this, pos, c, ((ClHexagonBD)pBD).Radi);
                        llHexagons.Add((ClHexagon)p);
                        break;

                    case "Heptàgon":
                        p = (c == Color.Empty) ? new ClHeptagon(this, pos, ((ClHeptagonBD)pBD).Radi) : new ClHeptagon(this, pos, c, ((ClHeptagonBD)pBD).Radi);
                        llHeptagons.Add((ClHeptagon)p);
                        break;

                    case "Octògon":
                        p = (c == Color.Empty) ? new ClOctogon(this, pos, ((ClOctogonBD)pBD).Radi) : new ClOctogon(this, pos, c, ((ClOctogonBD)pBD).Radi);
                        llOctogons.Add((ClOctogon)p);
                        break;
                }

                if (p != null) llPoligons.Add(p);
            }
        }

        private void FrmMain_DoubleClick(object sender, EventArgs e)
        {
            switch (figura)
            {
                case "Quadrat": dibuixarQuadrat(); break;
                case "Rectangle": dibuixarRectangle(); break;
                case "Triangle Rectangle": dibuixarTriangleRectangle(); break;
                case "Triangle Isòsceles": dibuixarTriangleIsosceles(); break;
                case "Triangle Equilàter": dibuixarTriangleEquilater(); break;
                case "Rombe": dibuixarRombe(); break;
                case "Cercle": dibuixarCercle(); break;
                case "Ellipse": dibuixarEllipse(); break;
                case "Pentàgon": dibuixarPentagon(); break;
                case "Hexàgon": dibuixarHexagon(); break;
                case "Heptàgon": dibuixarHeptagon(); break;
                case "Octògon": dibuixarOctogon(); break;
            }
        }

        // selecció de figura


        //dibuixem un quadrat i l'inserim a la base de dades
        // --- GRUPO 1: CUADRILÁTEROS Y TRIÁNGULOS ---

        private void dibuixarQuadrat()
        {
            Point p = new Point(MousePosition.X, MousePosition.Y - SystemInformation.CaptionHeight);
            int m = (int)nupWidth.Value;
            Color c = chkInterior.Checked ? pnlColorInterior.BackColor : Color.Empty;
            ClQuadrat q = (c == Color.Empty) ? new ClQuadrat(this, p, m) : new ClQuadrat(this, p, c, m);
            llQuadrats.Add(q); llPoligons.Add(q);
            ClQuadratBD qBD = new ClQuadratBD { posCentre = p, Mida = m, colorInterior = c };
            qBD.addPoligonBD(bd); llPoligonsBD.Add(qBD);
        }

        private void dibuixarRectangle()
        {
            Point p = new Point(MousePosition.X, MousePosition.Y - SystemInformation.CaptionHeight);
            int w = (int)nupWidth.Value; int h = (int)nupHeight.Value;
            Color c = chkInterior.Checked ? pnlColorInterior.BackColor : Color.Empty;
            ClRectangle r = (c == Color.Empty) ? new ClRectangle(this, p, w, h) : new ClRectangle(this, p, h, w, c);
            llRectangles.Add(r); llPoligons.Add(r);
            ClRectangleBD rBD = new ClRectangleBD { posCentre = p, Amplada = w, Altura = h, colorInterior = c };
            rBD.addPoligonBD(bd); llPoligonsBD.Add(rBD);
        }

        private void dibuixarTriangleRectangle()
        {
            Point p = new Point(MousePosition.X, MousePosition.Y - SystemInformation.CaptionHeight);
            int w = (int)nupWidth.Value; int h = (int)nupHeight.Value;
            Color c = chkInterior.Checked ? pnlColorInterior.BackColor : Color.Empty;
            ClTriangleRectangle tr = (c == Color.Empty) ? new ClTriangleRectangle(this, p, w, h) : new ClTriangleRectangle(this, p, c, w, h);
            llTrianglesRectangles.Add(tr); llPoligons.Add(tr);
            ClTriangleRectangleBD trBD = new ClTriangleRectangleBD { posCentre = p, Amplada = w, Alcada = h, colorInterior = c };
            trBD.addPoligonBD(bd); llPoligonsBD.Add(trBD);
        }

        private void dibuixarTriangleIsosceles()
        {
            Point p = new Point(MousePosition.X, MousePosition.Y - SystemInformation.CaptionHeight);
            int w = (int)nupWidth.Value; int h = (int)nupHeight.Value;
            Color c = chkInterior.Checked ? pnlColorInterior.BackColor : Color.Empty;
            ClTriangleIsosceles ti = (c == Color.Empty) ? new ClTriangleIsosceles(this, p, w, h) : new ClTriangleIsosceles(this, p, c, w, h);
            llTrianglesIsosceles.Add(ti); llPoligons.Add(ti);
            ClTriangleIsoscelesBD tiBD = new ClTriangleIsoscelesBD { posCentre = p, Base = w, Altura = h, colorInterior = c };
            tiBD.addPoligonBD(bd); llPoligonsBD.Add(tiBD);
        }

        private void dibuixarTriangleEquilater()
        {
            Point p = new Point(MousePosition.X, MousePosition.Y - SystemInformation.CaptionHeight);
            int m = (int)nupWidth.Value;
            Color c = chkInterior.Checked ? pnlColorInterior.BackColor : Color.Empty;

            // Llamada directa al nuevo constructor de 4 parámetros
            ClTriangleEquilater te = new ClTriangleEquilater(this, p, c, m);

            llTrianglesEquilaters.Add(te);
            llPoligons.Add(te);

            ClTriangleEquilaterBD teBD = new ClTriangleEquilaterBD { posCentre = p, Costat = m, colorInterior = c };
            teBD.addPoligonBD(bd);
            llPoligonsBD.Add(teBD);
        }

        private void dibuixarRombe()
        {
            Point p = new Point(MousePosition.X, MousePosition.Y - SystemInformation.CaptionHeight);
            int dM = (int)nupWidth.Value;
            int dm = (int)nupHeight.Value;
            Color c = chkInterior.Checked ? pnlColorInterior.BackColor : Color.Empty;

            Color? colRombe = (c == Color.Empty) ? (Color?)null : c;
            ClRombe r = new ClRombe(this, p, dM, dm, colRombe);

            llRombes.Add(r);
            llPoligons.Add(r);

            ClRombeBD rBD = new ClRombeBD { posCentre = p, DiagMajor = dM, DiagMenor = dm, colorInterior = c };
            rBD.addPoligonBD(bd);
            llPoligonsBD.Add(rBD);
        }

        // --- GRUPO 2: CURVAS ---

        private void dibuixarCercle()
        {
            Point p = new Point(MousePosition.X, MousePosition.Y - SystemInformation.CaptionHeight);
            int rad = (int)nupWidth.Value;
            Color c = chkInterior.Checked ? pnlColorInterior.BackColor : Color.Empty;
            ClCercle ce = (c == Color.Empty) ? new ClCercle(this, p, rad) : new ClCercle(this, p, c, rad);
            llCercles.Add(ce); llPoligons.Add(ce);
            ClCercleBD ceBD = new ClCercleBD { posCentre = p, Radi = rad, colorInterior = c };
            ceBD.addPoligonBD(bd); llPoligonsBD.Add(ceBD);
        }

        private void dibuixarEllipse()
        {
            Point p = new Point(MousePosition.X, MousePosition.Y - SystemInformation.CaptionHeight);
            int rx = (int)nupWidth.Value;
            int ry = (int)nupHeight.Value;
            Color c = chkInterior.Checked ? pnlColorInterior.BackColor : Color.Empty;

            Color? colEli = (c == Color.Empty) ? (Color?)null : c;
            ClEllipse el = new ClEllipse(this, p, rx, ry, colEli);

            llEllipses.Add(el);
            llPoligons.Add(el);

            ClEllipseBD elBD = new ClEllipseBD { posCentre = p, RadiX = rx, RadiY = ry, colorInterior = c };
            elBD.addPoligonBD(bd);
            llPoligonsBD.Add(elBD);
        }

        // --- GRUPO 3: POLÍGONOS REGULARES (Clases separadas) ---

        private void dibuixarPentagon()
        {
            Point p = new Point(MousePosition.X, MousePosition.Y - SystemInformation.CaptionHeight);
            int r = (int)nupWidth.Value;
            Color c = chkInterior.Checked ? pnlColorInterior.BackColor : Color.Empty;
            ClPentagon f = (c == Color.Empty) ? new ClPentagon(this, p, r) : new ClPentagon(this, p, c, r);
            llPentagons.Add(f); llPoligons.Add(f);
            ClPentagonBD fBD = new ClPentagonBD { posCentre = p, Radi = r, colorInterior = c };
            fBD.addPoligonBD(bd); llPoligonsBD.Add(fBD);
        }

        private void dibuixarHexagon()
        {
            Point p = new Point(MousePosition.X, MousePosition.Y - SystemInformation.CaptionHeight);
            int r = (int)nupWidth.Value;
            Color c = chkInterior.Checked ? pnlColorInterior.BackColor : Color.Empty;
            ClHexagon f = (c == Color.Empty) ? new ClHexagon(this, p, r) : new ClHexagon(this, p, c, r);
            llHexagons.Add(f); llPoligons.Add(f);
            ClHexagonBD fBD = new ClHexagonBD { posCentre = p, Radi = r, colorInterior = c };
            fBD.addPoligonBD(bd); llPoligonsBD.Add(fBD);
        }

        private void dibuixarHeptagon()
        {
            Point p = new Point(MousePosition.X, MousePosition.Y - SystemInformation.CaptionHeight);
            int r = (int)nupWidth.Value;
            Color c = chkInterior.Checked ? pnlColorInterior.BackColor : Color.Empty;
            ClHeptagon f = (c == Color.Empty) ? new ClHeptagon(this, p, r) : new ClHeptagon(this, p, c, r);
            llHeptagons.Add(f); llPoligons.Add(f);
            ClHeptagonBD fBD = new ClHeptagonBD { posCentre = p, Radi = r, colorInterior = c };
            fBD.addPoligonBD(bd); llPoligonsBD.Add(fBD);
        }

        private void dibuixarOctogon()
        {
            Point p = new Point(MousePosition.X, MousePosition.Y - SystemInformation.CaptionHeight);
            int r = (int)nupWidth.Value;
            Color c = chkInterior.Checked ? pnlColorInterior.BackColor : Color.Empty;
            ClOctogon f = (c == Color.Empty) ? new ClOctogon(this, p, r) : new ClOctogon(this, p, c, r);
            llOctogons.Add(f); llPoligons.Add(f);
            ClOctogonBD fBD = new ClOctogonBD { posCentre = p, Radi = r, colorInterior = c };
            fBD.addPoligonBD(bd); llPoligonsBD.Add(fBD);
        }


        private void pnlColorInterior_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pnlColorInterior.BackColor = dlg.Color;
            }
        }

        private void chkInterior_CheckedChanged(object sender, EventArgs e)
        {
            pnlColorInterior.Visible= chkInterior.Checked;  
        }

        private void btAreaSeleccio_Click(object sender, EventArgs e)
        {
            double area = 0;
            switch (figura)
            {
                case "Quadrat": area = calcularArea(llQuadrats); break;
                case "Rectangle": area = calcularArea(llRectangles); break;
                case "Triangle Rectangle": area = calcularArea(llTrianglesRectangles); break;
                case "Triangle Isòsceles": area = calcularArea(llTrianglesIsosceles); break;
                case "Triangle Equilàter": area = calcularArea(llTrianglesEquilaters); break;
                case "Rombe": area = calcularArea(llRombes); break;
                case "Cercle": area = calcularArea(llCercles); break;
                case "Ellipse": area = calcularArea(llEllipses); break;
                case "Pentàgon": area = calcularArea(llPentagons); break;
                case "Hexàgon": area = calcularArea(llHexagons); break;
                case "Heptàgon": area = calcularArea(llHeptagons); break;
                case "Octògon": area = calcularArea(llOctogons); break;
            }
            MessageBox.Show($"L'àrea de {figura}s és: {area:F2}");
        }

        private void btAreaTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("L'àrea total dels polígons és " + calcularArea(llPoligons), "Àrea figura seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private Double calcularArea(IEnumerable<ClPoligon> xllista)     // posar IEnumerable fa que funcioni amb qualsevol llista de subclasses de ClPoligon
        {
            Double area = 0;

            foreach (ClPoligon p in xllista)
            {
                area += p.Area();
            }
            return area;
        }

        private void btDelSeleccio_Click(object sender, EventArgs e)
        {
            if (rdQuadrat.Checked)
            {
                eliminarPoligons("Quadrat");
            }
            else if (rdTriangleRectangle.Checked)
            {
                eliminarPoligons("Triangle Rectangle");
            }
            else if (rdTriangleIsosceles.Checked)
            {
                eliminarPoligons("Triangle Isòsceles");
            }
            else if (rdTriangleEquilater.Checked)
            {
                eliminarPoligons("Triangle Equilàter");
            }
            else if (rdRectangle.Checked)
            {
                eliminarPoligons("Rectangle");
            }
            else if (rdCercle.Checked)
            {
                eliminarPoligons("Cercle");
            }
            else if (rdEllipse.Checked)
            {
                eliminarPoligons("Ellipse");
            }
            else if (rdRombe.Checked)
            {
                eliminarPoligons("Rombe");
            }
            else if (rdPentagon.Checked)
            {
                eliminarPoligons("Pentàgon");
            }
            else if (rdHexagon.Checked)
            {
                eliminarPoligons("Hexàgon");
            }
            else if (rdHeptàgon.Checked)
            {
                eliminarPoligons("Heptàgon");
            }
            else if (rdOctogon.Checked)
            {
                eliminarPoligons("Octògon");
            }
        }

        private void btDelTots_Click(object sender, EventArgs e)
        {
            eliminarPoligons("Tots");
        }

        private void eliminarPoligons(String xtipusPoligon)
        {
            int i = 0;
            while (i < llPoligonsBD.Count)
            {
                if (llPoligonsBD[i].tipusPoligon == xtipusPoligon || xtipusPoligon == "Tots")
                {
                    llPoligonsBD[i].delPoligonBD(bd);

                    llPoligons[i].eliminarPanell();

 
                    string tipusABorrar = llPoligonsBD[i].tipusPoligon;

                    switch (tipusABorrar)
                    {
                        case "Quadrat":
                            llQuadrats.Remove((ClQuadrat)llPoligons[i]); break;
                        case "Triangle Rectangle":
                            llTrianglesRectangles.Remove((ClTriangleRectangle)llPoligons[i]); break;
                        case "Triangle Isòsceles":
                            llTrianglesIsosceles.Remove((ClTriangleIsosceles)llPoligons[i]); break;
                        case "Triangle Equilàter":
                            llTrianglesEquilaters.Remove((ClTriangleEquilater)llPoligons[i]); break;
                        case "Rectangle":
                            llRectangles.Remove((ClRectangle)llPoligons[i]); break;
                        case "Cercle":
                            llCercles.Remove((ClCercle)llPoligons[i]); break;
                        case "Ellipse":
                            llEllipses.Remove((ClEllipse)llPoligons[i]); break;
                        case "Rombe":
                            llRombes.Remove((ClRombe)llPoligons[i]); break;
                        case "Pentàgon":
                            llPentagons.Remove((ClPentagon)llPoligons[i]); break;
                        case "Hexàgon":
                            llHexagons.Remove((ClHexagon)llPoligons[i]); break;
                        case "Heptàgon":
                            llHeptagons.Remove((ClHeptagon)llPoligons[i]); break;
                        case "Octògon":
                            llOctogons.Remove((ClOctogon)llPoligons[i]); break;
                    }

                    llPoligonsBD.RemoveAt(i);
                    llPoligons.RemoveAt(i);

              
                }
                else
                {
                    i++;
                }
            }
        }

        private void rdTriangleRectangle_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Checked)
            {
                figura = rb.Text;

                if (figura.Contains("Cercle") || figura.Contains("gon"))
                {
                    lbAmple.Text = "Radi";
                }
                else if (figura == "Triangle Equilàter" || figura == "Quadrat")
                {
                    lbAmple.Text = "Mida";
                }
                else if (figura == "Rombe")
                {
                    lbAmple.Text = "D. Major";
                }
                else
                {
                    lbAmple.Text = "Amplada";
                }

                bool necesitaAltura = (figura == "Rectangle" ||
                                       figura == "Triangle Rectangle" ||
                                       figura == "Triangle Isòsceles" ||
                                       figura == "Ellipse" ||
                                       figura == "Rombe");

                lbAltura.Visible = nupHeight.Visible = necesitaAltura;

                if (necesitaAltura)
                {
                    if (figura == "Ellipse") lbAltura.Text = "Radi Y";
                    else if (figura == "Rombe") lbAltura.Text = "D. Menor";
                    else lbAltura.Text = "Alçada";
                }
            }
        }

        private void btPerimetreTotal_Click(object sender, EventArgs e)
        {
            double sumaPerimetres = 0;
            foreach (ClPoligon p in llPoligons)
            {
                sumaPerimetres += p.Perimetre();
            }
            MessageBox.Show("El perímetre total és: " + sumaPerimetres.ToString("N2") + " pixels.");
        }

        public void eliminarFiguraIndividual(ClPoligon figuraABorrar)
        {
            int indice = llPoligons.IndexOf(figuraABorrar);

            if (indice != -1)
            {
                llPoligonsBD[indice].delPoligonBD(bd);

                llPoligons[indice].eliminarPanell();

                string tipus = llPoligonsBD[indice].tipusPoligon;
                switch (tipus)
                {
                    case "Quadrat": llQuadrats.Remove((ClQuadrat)llPoligons[indice]); break;
                    case "Triangle Rectangle": llTrianglesRectangles.Remove((ClTriangleRectangle)llPoligons[indice]); break;
                    case "Triangle Isòsceles": llTrianglesIsosceles.Remove((ClTriangleIsosceles)llPoligons[indice]); break;
                    case "Triangle Equilàter": llTrianglesEquilaters.Remove((ClTriangleEquilater)llPoligons[indice]); break;
                    case "Rectangle": llRectangles.Remove((ClRectangle)llPoligons[indice]); break;
                    case "Cercle": llCercles.Remove((ClCercle)llPoligons[indice]); break;
                    case "Ellipse": llEllipses.Remove((ClEllipse)llPoligons[indice]); break;
                    case "Rombe": llRombes.Remove((ClRombe)llPoligons[indice]); break;
                    case "Pentàgon": llPentagons.Remove((ClPentagon)llPoligons[indice]); break;
                    case "Hexàgon": llHexagons.Remove((ClHexagon)llPoligons[indice]); break;
                    case "Heptàgon": llHeptagons.Remove((ClHeptagon)llPoligons[indice]); break;
                    case "Octògon": llOctogons.Remove((ClOctogon)llPoligons[indice]); break;
                }

                llPoligonsBD.RemoveAt(indice);
                llPoligons.RemoveAt(indice);
            }
        }

        private void btPerimetreSeleccio_Click(object sender, EventArgs e)
        {
            String tipusSeleccionat = "";

            // 1. Determinar qué tipo está seleccionado
            if (rdQuadrat.Checked) tipusSeleccionat = "Quadrat";
            else if (rdTriangleRectangle.Checked) tipusSeleccionat = "Triangle Rectangle";
            else if (rdTriangleIsosceles.Checked) tipusSeleccionat = "Triangle Isòsceles";
            else if (rdTriangleEquilater.Checked) tipusSeleccionat = "Triangle Equilàter";
            else if (rdRectangle.Checked) tipusSeleccionat = "Rectangle";
            else if (rdCercle.Checked) tipusSeleccionat = "Cercle";
            else if (rdEllipse.Checked) tipusSeleccionat = "Ellipse";
            else if (rdRombe.Checked) tipusSeleccionat = "Rombe";
            else if (rdPentagon.Checked) tipusSeleccionat = "Pentàgon";
            else if (rdHexagon.Checked) tipusSeleccionat = "Hexàgon";
            else if (rdHeptàgon.Checked) tipusSeleccionat = "Heptàgon";
            else if (rdOctogon.Checked) tipusSeleccionat = "Octògon";

            if (tipusSeleccionat == "")
            {
                MessageBox.Show("Per favor, selecciona un tipus de figura.");
                return;
            }

            double sumaPerimetre = 0;
            int comptador = 0;

            for (int i = 0; i < llPoligonsBD.Count; i++)
            {
                if (llPoligonsBD[i].tipusPoligon == tipusSeleccionat)
                {
                    sumaPerimetre += llPoligons[i].Perimetre();
                    comptador++;
                }
            }

            // 3. Mostrar el resultado
            if (comptador > 0)
            {
                MessageBox.Show($"El perímetre total d'aquestes és: {sumaPerimetre.ToString("N2")} px.");
            }
            else
            {
                MessageBox.Show($"No hi ha cap figura de tipus '{tipusSeleccionat}' dibuixada.");
            }
        }
    }
}
