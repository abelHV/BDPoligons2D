using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPoligons2D.CLASSES.ClassesBD
{
    public class ClOctogonBD : ClPoligonBD
    {
        public override string tipusPoligon => "Octògon";
        public int Radi { get; set; }

        public override Boolean getDadesPoligon(ClBdMySQL xbd, Int64 xid)
        {
            DataTable dt = new DataTable();
            idPoligon = xid;
            String xsql = $"SELECT * FROM tbPoligon p INNER JOIN tbOctogon q ON p.IdPoligon=q.IdPoligon WHERE p.IdPoligon={idPoligon}";
            if (xbd.getDades(xsql, dt))
            {
                posCentre = new Point(dt.Rows[0].Field<int>("CentreX"), dt.Rows[0].Field<int>("CentreY"));
                colorInterior = dt.Rows[0].IsNull("NomColor") ? Color.Empty : Color.FromName(dt.Rows[0].Field<String>("NomColor"));
                Radi = dt.Rows[0].Field<int>("Radi");
                return true;
            }
            return false;
        }

        public override Boolean addPoligonBD(ClBdMySQL xbd)
        {
            addSuperPoligon(xbd, tipusPoligon);
            if (idPoligon > 0)
            {
                String xsql = $"INSERT INTO tbOctogon (IdPoligon, `Radi`) VALUES ({idPoligon}, {Radi})";
                return xbd.ferOperacio(xsql);
            }
            return false;
        }
    }
}
