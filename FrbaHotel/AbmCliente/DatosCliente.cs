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
            cargarTiposDoc();
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

        private void cargarTiposDoc()
        {
            DB.ejecutarReader(
                "SELECT distinct(Tipo_Documento) " +
                "FROM LA_QUERY_DE_PAPEL.Persona",
                cargarTipoDoc);
        }

        public void cargarTipoDoc(SqlDataReader reader)
        {
            while (reader.Read())
            {
                comboBoxTipoDoc.Items.Add(reader.GetString(0));
            }
        }
    }
}
