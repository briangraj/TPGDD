using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    class Funcionalidad
    {
        public Funcionalidad(String descripcion, String id)
        {
            this.descripcion = descripcion;
            this.id = id;
        }

        public String descripcion;
        public String id;
    }
}
