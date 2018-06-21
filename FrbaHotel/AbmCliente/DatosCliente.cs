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

namespace FrbaHotel.AbmCliente
{
    public abstract partial class DatosCliente : Form
    {
        public DatosCliente()
        {
            InitializeComponent();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProviderCliente.Clear();
                validarDatos();
                if (Validaciones.errorProviderConError(errorProviderCliente, Controls))
                    return;

                accionAceptar();
            }
            catch (SqlException) { }
        }

        private void validarDatos()
        {
            Validaciones.validarControles(errorProviderCliente, Controls);
            Validaciones.validarFechasPosteriores(errorProviderCliente, Controls);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.limpiarControles(Controls);
        }

        protected abstract void accionAceptar();
    }
}
