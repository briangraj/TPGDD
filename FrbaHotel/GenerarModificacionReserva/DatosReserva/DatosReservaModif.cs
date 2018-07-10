using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;
using System.Data;

namespace FrbaHotel.GenerarModificacionReserva.DatosReserva
{
    class DatosReservaModif : DatosReserva
    {
        private Reserva reserva;

        public DatosReservaModif(Reserva reserva, Usuario usuario)
            : base(usuario)
        {
            this.reserva = reserva;
            cargarReserva();
            cargarHabitaciones();
            cargarHabitacionesReservadas();
            comboBoxTipoReg.Enabled = false;
        }

        private void cargarReserva()
        {
            dateTimePickerDesde.Value = reserva.fechaInicio;
            dateTimePickerHasta.Value = reserva.fechaFin;
            comboBoxTipoHab.SelectedIndex = comboBoxTipoHab.Items.IndexOf(reserva.tipoHabitacion);
            comboBoxTipoReg.SelectedIndex = comboBoxTipoReg.Items.IndexOf(reserva.descRegimen);
        }

        protected override System.Data.DataTable tablaDeHabitaciones(int idRegimen, string tipoHab)
        {
            //todo ver que el hotel no este en baja
            return DB.ejecutarFuncionDeTabla("LA_QUERY_DE_PAPEL.habitaciones_disponibles_para_reserva",
                "idHotel", usuario.idHotel, "idRegimen", idRegimen, "tipoHab", "%" + tipoHab + "%", "fechaDesde", dateTimePickerDesde.Value, "fechaHasta", dateTimePickerHasta.Value,
                "nroReserva", reserva.id);
        }

        private void cargarHabitacionesReservadas()
        {
            tablaHabSeleccionadas = DB.ejecutarFuncionDeTabla("LA_QUERY_DE_PAPEL.habitaciones_de_reserva", "nroReserva", reserva.id);

            dataGridViewHabReservadas.DataSource = tablaHabSeleccionadas;
        }

        protected override void accionBotonSiguiente()
        {
            reserva.usuario = usuario;

            abrirConfirmacion(reserva);
        }
    }
}
