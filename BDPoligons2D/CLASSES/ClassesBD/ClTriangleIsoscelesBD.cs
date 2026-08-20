using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPoligons2D.CLASSES.ClassesBD
{
    public class ClTriangleIsoscelesBD : ClPoligonBD
    {
        public override string tipusPoligon => "Triangle Isòsceles";
        public int Base { get; set; }
        public int Altura { get; set; }

        public override Boolean getDadesPoligon(ClBdMySQL xbd, Int64 xid)
        {
            DataTable dt = new DataTable();
            idPoligon = xid;
            String xsql = $"SELECT * FROM tbpoligon p INNER JOIN tbtriangleisosceles t ON p.IdPoligon=t.IdPoligon WHERE p.IdPoligon={idPoligon}";
            if (xbd.getDades(xsql, dt))
            {
                posCentre = new Point(dt.Rows[0].Field<int>("CentreX"), dt.Rows[0].Field<int>("CentreY"));
                colorInterior = dt.Rows[0].IsNull("NomColor") ? Color.Empty : Color.FromName(dt.Rows[0].Field<String>("NomColor"));
                Base = dt.Rows[0].Field<int>("Base");
                Altura = dt.Rows[0].Field<int>("Altura");
                return true;
            }
            return false;
        }

        public override Boolean addPoligonBD(ClBdMySQL xbd)
        {
            addSuperPoligon(xbd, tipusPoligon);
            if (idPoligon > 0)
            {
                String xsql = $"INSERT INTO tbTriangleIsosceles (IdPoligon, `Base`, `Altura`) VALUES ({idPoligon}, {Base}, {Altura})";
                return xbd.ferOperacio(xsql);
            }
            return false;
        }
    }
}
