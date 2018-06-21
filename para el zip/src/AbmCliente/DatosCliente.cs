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
        private string tipoDocClienteAModificar;
        private string nroDocClienteAModificar;

        public DatosCliente()
        {
            InitializeComponent();
            esAlta = true;
        }

        public DatosCliente(DataGridViewRow filaSeleccionada)
        {
            InitializeComponent();
            esAlta = false;
            cargarCliente(filaSeleccionada);
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
            Validaciones.validarFechasPosteriores(errorProviderCliente, Controls);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.limpiarControles(Controls);
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
            DB.ejecutarProcedimiento(
                "LA_QUERY_DE_PAPEL.procedure_update_cliente", "nombre", textBoxNombre.Text, "apellido", textBoxApellido.Text, "tipoDoc", textBoxTipoDoc.Text, "nroDoc", textBoxNroDoc.Text,
                "mail", textBoxMail.Text, "telefono", textBoxTelefono.Text, "direccion", textBoxDireccion.Text, "localidad", textBoxLocalidad.Text,
                "nacionalidad", textBoxNacionalidad.Text, "fechaNac", dateTimePickerFechaNac.Value, "habilitado", checkBoxHabilitado.Checked,
                "tipoDocOriginal", tipoDocClienteAModificar, "nroDocOriginal", nroDocClienteAModificar);

            MessageBox.Show("Se modifico el cliente");
        }

        private void cargarCliente(DataGridViewRow filaSeleccionada)
        {
            textBoxNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
            textBoxApellido.Text = filaSeleccionada.Cells["Apellido"].Value.ToString();
            textBoxTipoDoc.Text = filaSeleccionada.Cells["Tipo_Documento"].Value.ToString();
            textBoxNroDoc.Text = filaSeleccionada.Cells["Nro_Documento"].Value.ToString();
            textBoxMail.Text = filaSeleccionada.Cells["Mail"].Value.ToString();
            textBoxTelefono.Text = filaSeleccionada.Cells["Telefono"].Value.ToString();
            textBoxDireccion.Text = filaSeleccionada.Cells["Direccion"].Value.ToString();
            textBoxLocalidad.Text = filaSeleccionada.Cells["Localidad"].Value.ToString();
            textBoxNacionalidad.Text = filaSeleccionada.Cells["Nacionalidad"].Value.ToString();
            dateTimePickerFechaNac.Value = Convert.ToDateTime(filaSeleccionada.Cells["Fecha_Nacimiento"].Value);
            checkBoxHabilitado.Checked = Convert.ToBoolean(filaSeleccionada.Cells["Habilitado"].Value);

            tipoDocClienteAModificar = textBoxTipoDoc.Text;
            nroDocClienteAModificar = textBoxNroDoc.Text;
        }
    }
}
