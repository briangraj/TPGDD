using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;

namespace FrbaHotel.GenerarModificacionReserva.FormaNueva
{
    class DatosReservaAl : DatosReserv
    {
        public DatosReservaAl(Usuario usuario) : base(usuario) { }

        protected override void accionBotonSiguiente()
        {
            Reserva reserva = new Reserva(dateTimePickerDesde.Value, dateTimePickerHasta.Value, comboBoxTipoHab.SelectedItem.ToString(), comboBoxTipoReg.SelectedItem.ToString(), usuario);

            ConfirmacionReserva confirmacion = new ConfirmacionReserva(reserva, tablaHabSeleccionadas, this);
            confirmacion.Show();
            Hide();
        }
    }
}
