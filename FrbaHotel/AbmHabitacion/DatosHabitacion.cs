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
using FrbaHotel.Entidades;
using System.Data.SqlClient;

namespace FrbaHotel.AbmHabitacion
{
    public abstract partial class DatosHabitacion : Form
    {
        protected Usuario usuario;

        public DatosHabitacion(Usuario usuario)
        {
            InitializeComponent();
            cargarTiposHabitacion();
            this.usuario = usuario;
        }

        private void cargarTiposHabitacion()
        {
            DB.ejecutarReader(
                "SELECT Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Tipo_Habitacion",
                cargarTipoHabitacion);
        }

        public void cargarTipoHabitacion(SqlDataReader reader)
        {
            while (reader.Read())
            {
                comboBoxTipoHab.Items.Add(reader.GetString(0));
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProviderHabitacion.Clear();
                validarDatos();
                if (Validaciones.errorProviderConError(errorProviderHabitacion, Controls))
                    return;

                accionAceptar();
            }
            catch (SqlException) { }
        }

        protected string ubicacion()
        {
            return checkBoxVistaExterior.Checked ? "S" : "N";
        }

        private void validarDatos()
        {
            Validaciones.validarControles(errorProviderHabitacion, Controls);
        }

        protected abstract void accionAceptar();

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.limpiarControles(Controls);
        }
    }
}
