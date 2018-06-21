using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Reserva
    {
        public DateTime fechaDeReserva;
        public DateTime fechaInicio;
        public DateTime fechaFin;
        public string descRegimen;
        public string tipoHabitacion;

        public List<Habitacion> habitaciones = new List<Habitacion>();

        public Reserva(DateTime fechaInicio, DateTime fechaFin, string tipoHabitacion, string descRegimen)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.tipoHabitacion = tipoHabitacion;
            this.descRegimen = descRegimen;
        }
    }
}
