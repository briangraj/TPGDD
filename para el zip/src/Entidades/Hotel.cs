using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    class Hotel
    {
        public Hotel(String nombre, String id)
        {
            this.nombre = nombre;
            this.id = id;
        }

        public String nombre;
        public String id;
    }
}
