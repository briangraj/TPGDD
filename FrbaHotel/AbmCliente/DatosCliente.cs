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
    public partial class DatosCliente : Form
    {
        private bool esAlta;

        public DatosCliente()
        {
            InitializeComponent();
            esAlta = true;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProviderCliente.Clear();
                validarDatos();
                if (Validaciones.errorProviderConError(errorProviderCliente, Controls))
                    return;

                if (esAlta)
                    atenderAlta();
                else
                    atenderModif();
            }
            catch (SqlException) { }
        }

        private void validarDatos()
        {
            Validaciones.validarControles(errorProviderCliente, Controls);
        }

        /////////////////////ALTA///////////////////////////
        private void atenderAlta()
        {
            DB.correrQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.clientes (Nombre, Apellido, Tipo_Documento, Nro_Documento, Mail, Telefono, Direccion, Localidad, Nacionalidad, Fecha_Nacimiento, Habilitado) " +
                    "VALUES (@nombre, @apellido, @tipoDocumento, @nroDocumento, @mail, @telefono, @direccion, @localidad, @nacionalidad, @fechaNacimiento, @habilitado)",
                    "nombre", textBoxNombre.Text, "apellido", textBoxApellido.Text, "tipoDocumento", textBoxTipoDoc.Text, "nroDocumento", textBoxNroDoc.Text,
                    "mail", textBoxMail.Text, "telefono", textBoxTelefono.Text, "direccion", textBoxDireccion.Text, "localidad", textBoxLocalidad.Text,
                    "nacionalidad", textBoxNacionalidad.Text, "fechaNacimiento", dateTimePickerFechaNac.Value, "habilitado", checkBoxHabilitado.Checked);

            MessageBox.Show("Se creo el cliente");
        }

        /////////////////////MODIFICACION///////////////////////////
        private void atenderModif()
        {
        }
    }
}
