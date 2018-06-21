using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Habitacion
    {
        public int idHotel;
        public int nroHabitacion;

        public Habitacion(int idHotel, int nroHabitacion)
        {
            this.idHotel = idHotel;
            this.nroHabitacion = nroHabitacion;
        }
    }
}
