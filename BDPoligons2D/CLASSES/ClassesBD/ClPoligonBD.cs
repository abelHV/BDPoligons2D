using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPoligons2D.CLASSES.ClassesBD
{
    public abstract class ClPoligonBD
    {
        // les propietats que corresponen amb les columnes de la taula tbPoligon les fem públiques
        // per a que es puguin llegir des de fora de la classe, les posem protected al set 
        // per a que només es puguin modificar des de les subclasses
        public abstract String tipusPoligon { get; }            // la fem abstract i així obliguem a que cada classe posi el seu tipus
                                                                // (Quadrat, Cercle, Triangle Rectangle, ...)
        public Int64 idPoligon { get; protected set; }  // fem el set protected per a que només es pugui modificar des de les subclasses
        public Point posCentre { get; set; }          // posició del centre del Panel   
        public Color colorInterior { get; set; }      // color de l'interior

        // aquest mètode retorna la llista de tots els polígons
        // en retorna només l'id i el tipus
        // el fem static per a que no calgui instanciar un objecte per a poder-lo cridar
        public static DataTable getIdTipusPoligons(ClBdMySQL xbd)
        {
            DataTable dtPoligons = new DataTable();
            String xsql = "";

            xsql = "SELECT IdPoligon, NomTipusPoligon FROM tbPoligon";
            xbd.getDades(xsql, dtPoligons);
            return dtPoligons;
        }

        // aquest mètode serà comú a totes les subclasses i afegeix la informació comuna a la taula tbPoligon
        // el fem protected per a que només es pugui cridar des de les subclasses
        protected void addSuperPoligon(ClBdMySQL xbd, String xtipus)
        {
            DataTable xdt = new DataTable();

            String xsql = "";

            if (colorInterior!=Color.Empty)
            {
                // si el color no és Color.Empty considerem que té interior
                xsql = $"INSERT INTO tbpoligon (NomTipusPoligon,CentreX,CentreY,NomColor) VALUES ('{xtipus}',{posCentre.X},{posCentre.Y},'{colorInterior.Name}')";
            }
            else
            {
                // si no hi ha interior posem NULL al colorInterior
                xsql = $"INSERT INTO tbpoligon (NomTipusPoligon,CentreX,CentreY,NomColor) VALUES ('{xtipus}',{posCentre.X},{posCentre.Y},NULL)";
            }
            if (xbd.ferOperacio(xsql))
            {
                xsql = "SELECT LAST_INSERT_ID()";   // obtenim l'Id del poligon acabat d'inserir
                                                    // encara que l'aplicació sigui multiusuarí, aquesta instrucció sempre retorna l'últim Id inserit per la connexió actual (cada usuari té la seva connexió)
                idPoligon = xbd.getDades(xsql, xdt) ? Convert.ToInt64(xdt.Rows[0][0]) : -1;
            }
        }

        // elimina el polígon de la base de dades
        // com que a la base de dades hem posat CASCADE podem posar
        // aquest mètode en la superclasse
        public Boolean delPoligonBD(ClBdMySQL xbd)
        {
            Boolean xb = false;
            String xsql = $"DELETE FROM tbpoligon WHERE IdPoligon={idPoligon}";

            xb=xbd.ferOperacio(xsql);
            return xb;
        }

        // afegeix el polígon a la base de dades
        public abstract Boolean addPoligonBD(ClBdMySQL xbd);
        
        // omple les propietats amb les dades que hi ha a la base de dades per a aquella instància de polígon
        // retorna true si ha pogut obtenir les dades i false en cas contrari
        public abstract Boolean getDadesPoligon(ClBdMySQL xbd,Int64 xid);

    }
}
