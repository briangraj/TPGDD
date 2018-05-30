using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FrbaHotel.Entidades
{
    public class Usuario
    {
        string username;
        
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public Usuario(string username)
        {
            this.username = username;
        }

        public static byte[] encriptar(string texto)    // encripto una contraseña
        {
            return new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(texto), 0, Encoding.UTF8.GetByteCount(texto));
        }
    }
}
