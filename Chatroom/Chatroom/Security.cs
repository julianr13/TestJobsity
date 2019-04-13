using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom
{
    public class Security
    {
        public string generarMD5(string sCadena)
        {
            // Objeto de codificación
            UnicodeEncoding ueCodigo = new UnicodeEncoding();
            // Objeto para instanciar las codificación
            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();

            // Calcula el valor hash de la cadena recibida
            byte[] bHash = Md5.ComputeHash(ueCodigo.GetBytes(sCadena));

            // Convierte el hash en una cadena y lo devuelve
            return Convert.ToBase64String(bHash);
        }
    }
}