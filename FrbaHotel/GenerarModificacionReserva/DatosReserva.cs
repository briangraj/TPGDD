using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;
using System.Data;

namespace FrbaHotel.GenerarModificacionReserva
{
    public abstract class DatosReserva : Form
    {
        protected Usuario usuario;
        protected bool primeraVez = true;
        protected int idRegimen;

        public DatosReserva() { }

        public DatosReserva(Usuario usuario)
        {
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
            ComboBoxTipoHab().Items.Add(reader.GetString(0));
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
            ComboBoxTipoReg().Items.Add(reader.GetString(0));
        }

        protected abstract ComboBox ComboBoxTipoHab();

        protected abstract ComboBox ComboBoxTipoReg();

        protected void agregarColumna()
        {
            DataGridViewCheckBoxColumn columna = new DataGridViewCheckBoxColumn();
            columna.HeaderText = "Seleccionar";
            columna.Name = "Seleccionar";

            DataGridViewReserva().Columns.Add(columna);
        }

        protected abstract DataGridView DataGridViewReserva();

        protected void validarDatos()
        {
            Validaciones.validarControles(ErrorProviderReserva(), Controls);
            Validaciones.validarFechasAnteriores(ErrorProviderReserva(), Controls);
            //todo validar que elija habitaciones
        }

        protected abstract ErrorProvider ErrorProviderReserva();

        protected void cargarHabitaciones()
        {
            idRegimen = DB.buscarIdRegimen(ComboBoxTipoReg().SelectedItem.ToString());
            string tipoHab = "";
            if (ComboBoxTipoHab().SelectedItem != null)
                tipoHab = ComboBoxTipoHab().SelectedItem.ToString();

            DataGridViewReserva().DataSource = DB.correrQueryTabla(
                "SELECT h.Nro_Habitacion, Piso, Ubicacion, Tipo_Hab, Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Habitacion h " +
                    "JOIN LA_QUERY_DE_PAPEL.RegimenxHotel rho ON h.Id_Hotel = rho.Id_Hotel " +
                    "LEFT JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rha ON h.Id_Hotel = rha.Id_Hotel AND h.Nro_Habitacion = rha.Nro_Habitacion " +
                    "LEFT JOIN LA_QUERY_DE_PAPEL.Reserva r ON rha.Id_Reserva = r.Id_Reserva " +
                        "WHERE rho.Id_Hotel = @idHotel " +
                            "AND rho.Id_Regimen = @idRegimen " +
                            "AND h.Habilitada = 1 " +
                            "AND Tipo_Hab LIKE @tipoHab " +
                            "AND (NOT (Fecha_Inicio BETWEEN @fechaDesde AND @fechaHasta OR Fecha_Fin BETWEEN @fechaDesde AND @fechaHasta) OR Fecha_Inicio IS NULL OR Fecha_Fin IS NULL)",
                "idHotel", usuario.idHotel, "idRegimen", idRegimen, "tipoHab", "%" + tipoHab + "%", "fechaDesde", DateTimePickerDesde().Value, "fechaHasta", DateTimePickerHasta().Value);
        }

        protected abstract DateTimePicker DateTimePickerDesde();

        protected abstract DateTimePicker DateTimePickerHasta();
        /*
        protected void accionSiguiente()
        {
            
        }
        */
        protected abstract DataTable tablaHabitacionesSeleccionadas();

        protected void clickEnDataGrid(DataGridViewCellEventArgs e)
        {
            if (DataGridViewReserva().Columns[e.ColumnIndex].HeaderText == "Seleccionar" && e.RowIndex != -1)
                DataGridViewReserva().Rows[e.RowIndex].Cells["Seleccionar"].Value = !Convert.ToBoolean(DataGridViewReserva().Rows[e.RowIndex].Cells["Seleccionar"].Value);
        }
    }
}
