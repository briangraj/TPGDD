using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrbaHotel.Utilidades;
using System.Data.SqlClient;

namespace FrbaHotel.AbmHotel
{
    public partial class BajaHotel : Form
    {
        private int idHotel;

        public BajaHotel(int idHotel)
        {
            InitializeComponent();
            this.idHotel = idHotel;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.limpiarControles(Controls);
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProviderBajaHotel.Clear();
                validarDatos();
                if (Validaciones.errorProviderConError(errorProviderBajaHotel, Controls))
                    return;

                insertarBajaHotel();

                MessageBox.Show("Se registro la baja de hotel");
                Close();
            }
            catch (SqlException) { }
        }

        private void insertarBajaHotel()
        {
            DB.ejecutarQuery(
                "INSERT INTO LA_QUERY_DE_PAPEL.Hotel_Baja (Id_Hotel, Fecha_inicio, Fecha_fin, Descripcion) " +
                "VALUES (@idHotel, @fechaInicio, @fechaFin, @descripcion)",
                "idHotel", idHotel, "fechaInicio", dateTimePickerFechaInicio.Value, "fechaFin", dateTimePickerFechaFin.Value, "descripcion", textBoxDescripcion.Text);
        }

        protected void validarDatos()
        {
            Validaciones.validarControles(errorProviderBajaHotel, Controls);
            Validaciones.validarFechasAnteriores(errorProviderBajaHotel, Controls);
            if (dateTimePickerFechaInicio.Value > dateTimePickerFechaFin.Value)
            {
                errorProviderBajaHotel.SetError(dateTimePickerFechaInicio, "No puedes ser posterior a la fecha de fin");
            }
            DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.validar_baja_hotel", "idHotel", idHotel, "fechaInicio", dateTimePickerFechaInicio.Value, "fechaFin", dateTimePickerFechaFin.Value);
        }
    }
}
