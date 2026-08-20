using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPoligons2D.CLASSES.ClassesBD
{
    public class ClTriangleRectangleBD : ClPoligonBD
    {
        public override string tipusPoligon => "Triangle Rectangle";
        public int Amplada { get; set; }
        public int Alcada { get; set; }


        public override Boolean getDadesPoligon(ClBdMySQL xbd, Int64 xid)
        {
            Boolean xb = false;
            DataTable dt = new DataTable();

            idPoligon = xid;
            String xsql = $"SELECT * FROM tbpoligon p INNER JOIN tbtrianglerectangle q ON p.IdPoligon=q.IdPoligon WHERE p.IdPoligon={idPoligon}";
            if (xbd.getDades(xsql, dt))
            {
                posCentre = new Point(dt.Rows[0].Field<int>("CentreX"), dt.Rows[0].Field<int>("CentreY"));
                colorInterior = dt.Rows[0].IsNull("NomColor") ? Color.Empty : Color.FromName(dt.Rows[0].Field<String>("NomColor"));
                Amplada = dt.Rows[0].Field<int>("Amplada");
                Alcada = dt.Rows[0].Field<int>("Alcada");
            }
            return xb;
        }

        public override Boolean addPoligonBD(ClBdMySQL xbd)
        {
            Boolean xb = false;
            String xsql = "";

            // Primero insertamos en la tabla padre
            addSuperPoligon(xbd, "Rectangle");

            if (idPoligon > 0)
            {
                // Usamos ` ` para asegurar que MySQL encuentre las columnas exactas de tu CREATE TABLE
                xsql = $"INSERT INTO tbTriangleRectangle (IdPoligon, `Base`, `Altura`) VALUES ({idPoligon}, {Amplada}, {Alcada})";
                xb = xbd.ferOperacio(xsql);
            }
            return xb;
        }
    }
}
