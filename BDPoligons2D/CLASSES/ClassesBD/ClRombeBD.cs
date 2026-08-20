using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPoligons2D.CLASSES.ClassesBD
{
    public class ClRombeBD : ClPoligonBD
    {
        public override string tipusPoligon => "Rombe";
        public int DiagMajor { get; set; }
        public int DiagMenor { get; set; }

        public override Boolean getDadesPoligon(ClBdMySQL xbd, Int64 xid)
        {
            DataTable dt = new DataTable();
            idPoligon = xid;
            String xsql = $"SELECT * FROM tbpoligon p INNER JOIN tbrombe r ON p.IdPoligon=r.IdPoligon WHERE p.IdPoligon={idPoligon}";
            if (xbd.getDades(xsql, dt))
            {
                posCentre = new Point(dt.Rows[0].Field<int>("CentreX"), dt.Rows[0].Field<int>("CentreY"));
                colorInterior = dt.Rows[0].IsNull("NomColor") ? Color.Empty : Color.FromName(dt.Rows[0].Field<String>("NomColor"));
                DiagMajor = dt.Rows[0].Field<int>("DiagMajor");
                DiagMenor = dt.Rows[0].Field<int>("DiagMenor");
                return true;
            }
            return false;
        }

        public override Boolean addPoligonBD(ClBdMySQL xbd)
        {
            addSuperPoligon(xbd, tipusPoligon);
            if (idPoligon > 0)
            {
                String xsql = $"INSERT INTO tbRombe (IdPoligon, `DiagMajor`, `DiagMenor`) VALUES ({idPoligon}, {DiagMajor}, {DiagMenor})";
                return xbd.ferOperacio(xsql);
            }
            return false;
        }
    }
}
