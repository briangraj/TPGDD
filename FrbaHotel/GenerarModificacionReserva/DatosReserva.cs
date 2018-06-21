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
    public partial class DatosReserva : Form
    {
        private Usuario usuario;
        private bool primeraVez = true;
        private int idRegimen;

        public DatosReserva(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            cargarTiposHab(usuario.idHotel);
            cargarRegimenes(usuario.idHotel);
        }

        private void cargarTiposHab(int idHotel)
        {
            DB.ejecutarReader(
                "SELECT distinct(Descripcion) " +
                "FROM LA_QUERY_DE_PAPEL.Habitacion " +
                    "WHERE Id_Hotel = @idHotel",
            cargarComboBoxTiposHab, "idHotel", idHotel);
        }

        public void cargarComboBoxTiposHab(SqlDataReader reader)
        {
            comboBoxTipoHab.Items.Add(reader.GetString(0));
        }

        private void cargarRegimenes(int idHotel)
        {
            DB.ejecutarReader(
                "SELECT Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Regimen r " +
                    "JOIN LA_QUERY_DE_PAPEL.RegimenxHotel rh " +
                        "ON r.Id_Regimen = rh.Id_Regimen " +
                    "WHERE Id_Hotel = @idHotel",
            cargarComboBoxRegimenes, "idHotel", idHotel);
        }

        public void cargarComboBoxRegimenes(SqlDataReader reader)
        {
            comboBoxTipoReg.Items.Add(reader.GetString(0));
        }

        protected void agregarColumna()
        {
            DataGridViewCheckBoxColumn columna = new DataGridViewCheckBoxColumn();
            columna.HeaderText = "Seleccionar";
            columna.Name = "columnaBoton";
            columna.ReadOnly = false;
            
            dataGridViewReserva.Columns.Add(columna);
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

            cargarHabitaciones();

            if (primeraVez)
            {
                agregarColumna();
                primeraVez = false;
            }
        }

        private void validarDatos()
        {
            Validaciones.validarControles(errorProviderReserva, Controls);
            Validaciones.validarFechasAnteriores(errorProviderReserva, Controls);
            //todo validar que elija habitaciones
        }

        private void cargarHabitaciones()
        {
            idRegimen = DB.buscarIdRegimen(comboBoxTipoReg.SelectedItem.ToString());
            string tipoHab = "";
            if (comboBoxTipoHab.SelectedItem != null)
                tipoHab = comboBoxTipoHab.SelectedItem.ToString();

            dataGridViewReserva.DataSource = DB.correrQueryTabla(
                "SELECT h.Nro_Habitacion, Piso, Ubicacion, Tipo_Hab, Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Habitacion h " +
                    "JOIN LA_QUERY_DE_PAPEL.RegimenxHotel rho ON h.Id_Hotel = rho.Id_Hotel " +
                    "JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rha ON h.Id_Hotel = rha.Id_Hotel AND h.Nro_Habitacion = rha.Nro_Habitacion " +
                    "JOIN LA_QUERY_DE_PAPEL.Reserva r ON rha.Id_Reserva = r.Id_Reserva " +
	                    "WHERE rho.Id_Hotel = @idHotel " +
	                        "AND rho.Id_Regimen = @idRegimen " +
	                        "AND h.Habilitada = 1 " +
                            "AND Tipo_Hab LIKE @tipoHab " +
	                        "AND NOT (Fecha_Inicio BETWEEN @fechaDesde AND @fechaHasta OR Fecha_Fin BETWEEN @fechaDesde AND @fechaHasta)",
                "idHotel", usuario.idHotel, "idRegimen", idRegimen, "tipoHab", tipoHab, "fechaDesde", dateTimePickerDesde.Value, "fechaHasta" , dateTimePickerHasta.Value);

        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            errorProviderReserva.Clear();
            validarDatos();
            if (Validaciones.errorProviderConError(errorProviderReserva, Controls))
                return;

            Reserva reserva = new Reserva(dateTimePickerDesde.Value, dateTimePickerHasta.Value, comboBoxTipoHab.SelectedItem.ToString(), comboBoxTipoReg.SelectedItem.ToString(), usuario);

            ConfirmacionReserva confirmacion = new ConfirmacionReserva(reserva, tablaHabitacionesSeleccionadas(), this);
            confirmacion.Show();
            Hide();
        }

        private DataTable tablaHabitacionesSeleccionadas()
        {
            DataTable tabla = new DataTable();
            //tabla.Rows.Add(dataGridViewReserva.Rows.SharedRow(0));
            foreach(DataGridViewRow fila in dataGridViewReserva.Rows)
            {
                if(Convert.ToBoolean(fila.Cells["Seleccionar"].Value))
                    tabla.Rows.Add(fila);
            }
            return tabla;
        }
    }
}
