using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPoligons2D.CLASSES.ClassesBD
{
    public class ClQuadratBD : ClPoligonBD
    {

        public override string tipusPoligon => "Quadrat";
        public int Mida { get; set; }

        public override Boolean getDadesPoligon(ClBdMySQL xbd, Int64 xid)
        {
            Boolean xb = false;
            DataTable dt = new DataTable();

            idPoligon = xid;
            String xsql = $"SELECT * FROM tbpoligon p INNER JOIN tbquadrat q ON p.IdPoligon=q.IdPoligon WHERE p.IdPoligon={idPoligon}";
            if (xbd.getDades(xsql, dt))
            {
                posCentre = new Point(dt.Rows[0].Field<int>("CentreX"), dt.Rows[0].Field<int>("CentreY"));
                colorInterior = dt.Rows[0].IsNull("NomColor") ? Color.Empty : Color.FromName(dt.Rows[0].Field<String>("NomColor"));
                Mida = dt.Rows[0].Field<int>("Mida");
            }
            return xb;
        }

        public override Boolean addPoligonBD(ClBdMySQL xbd)
        {
            Boolean xb = false;
            String xsql = "";

            addSuperPoligon(xbd, "Quadrat");
            if (idPoligon > 0)
            {
                xsql = $"INSERT INTO tbQuadrat (IdPoligon,`Mida`) VALUES ({idPoligon},{Mida})";
                xb = xbd.ferOperacio(xsql);
            }
            return xb;
        }
    }

}
