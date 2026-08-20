using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPoligons2D
{
    public class ClKryptonita486
    {
        public static String encriptarText(string text)
        {
            // ProtectedData és una classe de .NET que pertany a System.Security.Cryptography;
            // Permet encriptar un text basant-se en el perfil de l'usuari de Windows que té la sessió (DataProtectionScope.CurrentUser)
            // o encriptar-lo basant-se en un perfil de la màquina (DataProtectionScope.LocalMachine).
            // En el primer cas, només l'usuari d'aquesta sessió podrà desencriptar el text i, en el segon, qualsevol usuari d'aquest Windows.
            String xs = "";
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(text);
                byte[] encriptat = ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine);
                xs=Convert.ToBase64String(encriptat);
            }
            catch (Exception excp)
            {
                MessageBox.Show("Error a l'encriptar el text: " + excp.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return xs;
        }

        public static String desencriptarText(string textEncriptat)
        {
            String xs = "";
            try
            {   
                byte[] data = Convert.FromBase64String(textEncriptat);
                byte[] desencriptat = ProtectedData.Unprotect(data, null, DataProtectionScope.LocalMachine);
                xs=Encoding.UTF8.GetString(desencriptat);
            }
            catch (Exception excp)
            {
                MessageBox.Show("Error al desencriptar el text: " + excp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return xs;
        }
    }
}
