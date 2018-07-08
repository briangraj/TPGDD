using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Regimen
    {
        public String descripcion;
        public int id;

        public Regimen(String descripcion, int id)
        {
            this.descripcion = descripcion;
            this.id = id;
        }
    }
}
