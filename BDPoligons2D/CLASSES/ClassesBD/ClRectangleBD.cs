using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPoligons2D.CLASSES.ClassesBD
{
    public class ClRectangleBD : ClPoligonBD
    {
        public override string tipusPoligon => "Rectangle";
        public int Amplada { get; set; }
        public int Altura { get; set; }

        public override Boolean getDadesPoligon(ClBdMySQL xbd, Int64 xid)
        {
            DataTable dt = new DataTable();
            idPoligon = xid;

            String xsql = $"SELECT * FROM tbpoligon p INNER JOIN tbRectangle r ON p.IdPoligon=r.IdPoligon WHERE p.IdPoligon={idPoligon}";

            if (xbd.getDades(xsql, dt) && dt.Rows.Count > 0)
            {
                posCentre = new Point(dt.Rows[0].Field<int>("CentreX"), dt.Rows[0].Field<int>("CentreY"));
                colorInterior = dt.Rows[0].IsNull("NomColor") ? Color.Empty : Color.FromName(dt.Rows[0].Field<String>("NomColor"));
                Amplada = dt.Rows[0].Field<int>("Amplada");
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
                String xsql = $"INSERT INTO tbRectangle (IdPoligon, `Amplada`, `Altura`) VALUES ({idPoligon}, {Amplada}, {Altura})";
                return xbd.ferOperacio(xsql);
            }
            return false;
        }
    }
}
