using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    class Regimen
    {
        public String descripcion;
        public String id;

        public Regimen(String descripcion, String id)
        {
            this.descripcion = descripcion;
            this.id = id;
        }
    }
}
