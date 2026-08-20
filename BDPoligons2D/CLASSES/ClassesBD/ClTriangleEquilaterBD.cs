using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPoligons2D.CLASSES.ClassesBD
{
    public class ClTriangleEquilaterBD : ClPoligonBD
    {
        public override string tipusPoligon => "Triangle Equilàter";
        public int Costat { get; set; }

        public override Boolean getDadesPoligon(ClBdMySQL xbd, Int64 xid)
        {
            DataTable dt = new DataTable();
            idPoligon = xid;
            String xsql = $"SELECT * FROM tbpoligon p INNER JOIN tbtriangleequilater t ON p.IdPoligon=t.IdPoligon WHERE p.IdPoligon={idPoligon}";
            if (xbd.getDades(xsql, dt))
            {
                posCentre = new Point(dt.Rows[0].Field<int>("CentreX"), dt.Rows[0].Field<int>("CentreY"));
                colorInterior = dt.Rows[0].IsNull("NomColor") ? Color.Empty : Color.FromName(dt.Rows[0].Field<String>("NomColor"));
                Costat = dt.Rows[0].Field<int>("Costat");
                return true;
            }
            return false;
        }

        public override Boolean addPoligonBD(ClBdMySQL xbd)
        {
            addSuperPoligon(xbd, tipusPoligon);
            if (idPoligon > 0)
            {
                String xsql = $"INSERT INTO tbTriangleEquilater (IdPoligon, `Costat`) VALUES ({idPoligon}, {Costat})";
                return xbd.ferOperacio(xsql);
            }
            return false;
        }
    }
}
