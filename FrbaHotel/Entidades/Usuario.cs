using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using FrbaHotel.Utilidades;

namespace FrbaHotel.Entidades
{
    public class Usuario
    {
        public string username;
        public int id;

        public Usuario(string username)
        {
            this.username = username;
        }

        public void cargar()
        {
            id = DB.buscarIdUsuario(username);
        }

        public static byte[] encriptar(string texto)    // encripto una contraseña
        {
            return new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(texto), 0, Encoding.UTF8.GetByteCount(texto));
        }
    }
}
