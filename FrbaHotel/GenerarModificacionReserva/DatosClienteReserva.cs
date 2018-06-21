using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;

namespace FrbaHotel.GenerarModificacionReserva
{
    class DatosClienteReserva : AbmCliente.DatosCliente
    {
        private Reserva reserva;

        public DatosClienteReserva(Reserva reserva)
        {
            this.reserva = reserva;
        }


    }
}
