using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPoligons2D.CLASSES.ClassesBD
{
    public class ClCercleBD : ClPoligonBD
    {
        public override string tipusPoligon => "Cercle";
        public int Radi { get; set; }

        public override bool getDadesPoligon(ClBdMySQL xbd, long xid)
        {
            DataTable dt = new DataTable();
            idPoligon = xid;
            string xsql = $"SELECT * FROM tbpoligon p INNER JOIN tbcercle c ON p.IdPoligon=c.IdPoligon WHERE p.IdPoligon={idPoligon}";
            if (xbd.getDades(xsql, dt))
            {
                posCentre = new Point(dt.Rows[0].Field<int>("CentreX"), dt.Rows[0].Field<int>("CentreY"));
                colorInterior = dt.Rows[0].IsNull("NomColor") ? Color.Empty : Color.FromName(dt.Rows[0].Field<string>("NomColor"));
                Radi = dt.Rows[0].Field<int>("Radi");
                return true;
            }
            return false;
        }

        public override bool addPoligonBD(ClBdMySQL xbd)
        {
            addSuperPoligon(xbd, tipusPoligon);
            if (idPoligon > 0)
            {
                string xsql = $"INSERT INTO tbCercle (IdPoligon, `Radi`) VALUES ({idPoligon}, {Radi})";
                return xbd.ferOperacio(xsql);
            }
            return false;
        }
    }
}
