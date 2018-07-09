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

namespace FrbaHotel.GenerarModificacionReserva.FormaNueva
{
    public partial class DatosReserv : Form
    {
        protected Usuario usuario;
        private DataTable tablaHabSeleccionadas = new DataTable();
        private bool primeraVez = true;

        public DatosReserv(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            cargarTiposHab(usuario.idHotel);
            cargarRegimenes(usuario.idHotel);
        }

        private void cargarTiposHab(int idHotel)
        {
            DB.ejecutarReader(
                "SELECT Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Tipo_Habitacion ",
            cargarComboBoxTiposHab);
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
            /*
            
            */
            cargarHabitaciones();
        }

        protected void cargarHabitaciones()
        {
            int idRegimen = DB.buscarIdRegimen(comboBoxTipoReg.SelectedItem.ToString());
            string tipoHab = "";
            if (comboBoxTipoHab.SelectedItem != null)
                tipoHab = comboBoxTipoHab.SelectedItem.ToString();

            DataTable tabla = DB.correrQueryTabla(
                "SELECT  h.Nro_Habitacion, Piso, Ubicacion, th.Descripcion AS Tipo_Habitacion, h.Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Habitacion h " +
                    //"LEFT JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rha ON h.Id_Hotel = rha.Id_Hotel AND h.Nro_Habitacion = rha.Nro_Habitacion " +
                    //"LEFT JOIN LA_QUERY_DE_PAPEL.reservas_sin_cancelar r ON rha.Id_Reserva = r.Id_Reserva " +
                    "JOIN LA_QUERY_DE_PAPEL.Tipo_Habitacion th ON h.Tipo_Hab = th.Id_tipo " +
                    "JOIN LA_QUERY_DE_PAPEL.RegimenxHotel rho ON h.Id_Hotel = rho.Id_Hotel " +
                        "WHERE rho.Id_Hotel = @idHotel " +
                            "AND rho.Id_Regimen = @idRegimen " +
                            "AND h.Habilitada = 1 " +
                            "AND th.Descripcion LIKE @tipoHab " +
                            "AND h.Nro_Habitacion NOT IN ( " +
                                    "SELECT distinct Nro_Habitacion FROM LA_QUERY_DE_PAPEL.reservas_sin_cancelar r " +
                                    "JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rh ON r.Id_Reserva = rh.Id_Reserva " +
                                        "WHERE Id_Hotel = @idHotel " +
                                            "AND Fecha_Inicio < @fechaHasta  AND Fecha_Fin > @fechaDesde)",
                "idHotel", usuario.idHotel, "idRegimen", idRegimen, "tipoHab", "%" + tipoHab + "%", "fechaDesde", dateTimePickerDesde.Value, "fechaHasta", dateTimePickerHasta.Value);

            dataGridViewHabitaciones.DataSource = tabla;

            if (primeraVez)
            {
                tablaHabSeleccionadas = tabla.Clone();
                tablaHabSeleccionadas.Clear();
                dataGridViewHabReservadas.DataSource = tablaHabSeleccionadas;
                primeraVez = false;
            }

            dataGridViewHabitaciones.DataSource = tabla;
        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            DataGridViewRow fila = dataGridViewHabitaciones.Rows[e.RowIndex];
            tablaHabSeleccionadas.Rows.Add(
                fila.Cells["Nro_Habitacion"].Value,
                fila.Cells["Piso"].Value,
                fila.Cells["Ubicacion"].Value,
                fila.Cells["Tipo_Habitacion"].Value,
                fila.Cells["Descripcion"].Value);
        }
    }
}
