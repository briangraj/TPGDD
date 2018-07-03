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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class DatosReservaMod : Parche
    {
        public DatosReservaMod(Reserva reserva, Usuario usuario) : base(usuario)
        {
            cargarReserva(reserva);
        }

        private void cargarReserva(Reserva reserva)
        {
            dateTimePickerDesde.Value = reserva.fechaInicio;
            dateTimePickerHasta.Value = reserva.fechaFin;
            comboBoxTipoHab.SelectedIndex = comboBoxTipoHab.Items.IndexOf(reserva.tipoHabitacion);
            comboBoxTipoReg.SelectedIndex = comboBoxTipoReg.Items.IndexOf(reserva.descRegimen);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

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
