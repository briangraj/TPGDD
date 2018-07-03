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
using System.Data.SqlClient;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class DatosReservaAlta : Parche
    {
        public DatosReservaAlta(Usuario usuario) : base (usuario)
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            errorProviderReserva.Clear();
            Validaciones.validarFechasAnteriores(errorProviderReserva, Controls);
            if (Validaciones.errorProviderConError(errorProviderReserva, Controls))
                return;

            if (comboBoxTipoReg.SelectedIndex == -1)
            {
                SeleccionRegimen regimen = new SeleccionRegimen(usuario);
                if (regimen.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Debe elegir un regimen");
                    return;
                }
                comboBoxTipoReg.SelectedIndex = comboBoxTipoReg.Items.IndexOf(regimen.descripcionRegimen);
            }

            if (primeraVez)
            {
                agregarColumna();
                primeraVez = false;
            }

            cargarHabitaciones();
        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            accionSiguiente();
        }

        protected override DataTable tablaHabitacionesSeleccionadas()
        {
            DataTable tabla = ((DataTable)DataGridViewReserva().DataSource).Clone();
            tabla.Rows.Clear();

            foreach (DataGridViewRow fila in DataGridViewReserva().Rows)
            {
                if (Convert.ToBoolean(fila.Cells["Seleccionar"].Value))
                {
                    tabla.Rows.Add(
                        fila.Cells["Nro_Habitacion"].Value,
                        fila.Cells["Piso"].Value,
                        fila.Cells["Ubicacion"].Value,
                        fila.Cells["Tipo_Hab"].Value,
                        fila.Cells["Descripcion"].Value
                    );
                }
            }
            return tabla;
        }

        private void dataGridViewReserva_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clickEnDataGrid(e);
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
            return dataGridViewReserva;
        }

        protected override ErrorProvider ErrorProviderReserva()
        {
            return errorProviderReserva;
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
