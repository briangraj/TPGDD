using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class DatosReservaMod : Parche
    {
        private Reserva reserva;

        private DatosReservaMod(Reserva reserva, Usuario usuario) : base(usuario)
        {
            this.reserva = reserva;
            cargarReserva();
        }

        private void cargarReserva()
        {
            dateTimePickerDesde.Value = reserva.fechaInicio;
            dateTimePickerHasta.Value = reserva.fechaFin;
            comboBoxTipoHab.SelectedIndex = comboBoxTipoHab.Items.IndexOf(reserva.tipoHabitacion);
            comboBoxTipoReg.SelectedIndex = comboBoxTipoReg.Items.IndexOf(reserva.descRegimen);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

        }

        private void DatosReservaMod_Load(object sender, EventArgs e)
        {
            dataGridViewHabReservadas.DataSource = DB.ejecutarQueryDeTabla(
                "SELECT h.Nro_Habitacion, Piso, Ubicacion, Tipo_Hab, Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Habitacion h " +
                    "JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rh ON h.Id_Hotel = rh.Id_Hotel AND h.Nro_Habitacion = rh.Nro_Habitacion " +
                        "WHERE rh.Id_Reserva = @idReserva",
                "idReserva", reserva.id);
        }

        protected override DataTable tablaHabitacionesSeleccionadas()
        {
            throw new NotImplementedException();
        }

        protected override ComboBox ComboBoxTipoHab()
        {
            return comboBoxTipoHab;
        }

        protected override ComboBox ComboBoxTipoReg()
        {
            return comboBoxTipoReg;
        }

        protected override DataGridView DataGridViewReserva()
        {
            return dataGridViewReservaModif;
        }

        protected override ErrorProvider ErrorProviderReserva()
        {
            return errorProviderReservaMod;
        }

        protected override DateTimePicker DateTimePickerDesde()
        {
            return dateTimePickerDesde;
        }

        protected override DateTimePicker DateTimePickerHasta()
        {
            return dateTimePickerHasta;
        }
    }
}
