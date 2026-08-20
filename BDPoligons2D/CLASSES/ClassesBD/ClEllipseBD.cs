using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPoligons2D.CLASSES.ClassesBD
{
    public class ClEllipseBD : ClPoligonBD
    {
        public override string tipusPoligon => "Ellipse";
        public int RadiX { get; set; }
        public int RadiY { get; set; }

        public override bool getDadesPoligon(ClBdMySQL xbd, long xid)
        {
            DataTable dt = new DataTable();
            idPoligon = xid;
            string xsql = $"SELECT * FROM tbpoligon p INNER JOIN tbEllipse e ON p.IdPoligon=e.IdPoligon WHERE p.IdPoligon={idPoligon}";
            if (xbd.getDades(xsql, dt))
            {
                posCentre = new Point(dt.Rows[0].Field<int>("CentreX"), dt.Rows[0].Field<int>("CentreY"));
                colorInterior = dt.Rows[0].IsNull("NomColor") ? Color.Empty : Color.FromName(dt.Rows[0].Field<string>("NomColor"));
                RadiX = dt.Rows[0].Field<int>("RadiX");
                RadiY = dt.Rows[0].Field<int>("RadiY");
                return true;
            }
            return false;
        }

        public override bool addPoligonBD(ClBdMySQL xbd)
        {
            addSuperPoligon(xbd, tipusPoligon);
            if (idPoligon > 0)
            {
                string xsql = $"INSERT INTO tbEllipse (IdPoligon, `RadiX`, `RadiY`) VALUES ({idPoligon}, {RadiX}, {RadiY})";
                return xbd.ferOperacio(xsql);
            }
            return false;
        }
    }
}
