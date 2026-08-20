using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPoligons2D
{
    public class ClFitxerConnexioBD
    {
        // constants
        const String nomFitxerConnexio = "CFGBDMYSQL.TXT"; // fitxer on guardarem la cadena de connexió

        // propietats
        private String cadenaConnexio { get; set; } = "";

        // constructor
        public ClFitxerConnexioBD()
        {
            if (File.Exists(nomFitxerConnexio))
            {
                // si existeix el fitxer llegim la cadena de connexió que hi ha
                StreamReader sr = new StreamReader(nomFitxerConnexio);
                cadenaConnexio = sr.ReadLine();
                sr.Close();
            }
        }

        public Boolean guardarCadenaConnexio(String xcadenaConnexio)
        {
            Boolean xb = true;

            try
            {
                StreamWriter sw = new StreamWriter(nomFitxerConnexio, false);
                sw.WriteLine(xcadenaConnexio);
                sw.Close();
                cadenaConnexio = xcadenaConnexio;
            }
            catch (Exception)
            {
                xb = false;
                MessageBox.Show("No s'ha pogut guardar la cadena de connexió al fitxer " + nomFitxerConnexio, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return (xb);
        }

        public  String getCadenaConnexio()
        {
            return cadenaConnexio;
        }
    }
}
