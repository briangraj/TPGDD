using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Utilidades;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    class DatosClienteModif : DatosCliente
    {
        private string tipoDocClienteAModificar;
        private string nroDocClienteAModificar;

        public DatosClienteModif(DataGridViewRow filaSeleccionada) : base()
        {
            cargarCliente(filaSeleccionada);
        }

        protected override void accionAceptar()
        {
            DB.ejecutarProcedimiento(
                "LA_QUERY_DE_PAPEL.procedure_update_cliente", "nombre", textBoxNombre.Text, "apellido", textBoxApellido.Text, "tipoDoc", comboBoxTipoDoc.SelectedItem, "nroDoc", textBoxNroDoc.Text,
                "mail", textBoxMail.Text, "telefono", textBoxTelefono.Text, "direccion", textBoxDireccion.Text, "localidad", textBoxLocalidad.Text,
                "nacionalidad", textBoxNacionalidad.Text, "fechaNac", dateTimePickerFechaNac.Value, "habilitado", checkBoxHabilitado.Checked,
                "tipoDocOriginal", tipoDocClienteAModificar, "nroDocOriginal", nroDocClienteAModificar);

            MessageBox.Show("Se modifico el cliente");
        }

        private void cargarCliente(DataGridViewRow filaSeleccionada)
        {
            textBoxNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
            textBoxApellido.Text = filaSeleccionada.Cells["Apellido"].Value.ToString();
            comboBoxTipoDoc.SelectedIndex = comboBoxTipoDoc.Items.IndexOf(filaSeleccionada.Cells["Tipo_Documento"].Value.ToString());
            textBoxNroDoc.Text = filaSeleccionada.Cells["Nro_Documento"].Value.ToString();
            textBoxMail.Text = filaSeleccionada.Cells["Mail"].Value.ToString();
            textBoxTelefono.Text = filaSeleccionada.Cells["Telefono"].Value.ToString();
            textBoxDireccion.Text = filaSeleccionada.Cells["Direccion"].Value.ToString();
            textBoxLocalidad.Text = filaSeleccionada.Cells["Localidad"].Value.ToString();
            textBoxNacionalidad.Text = filaSeleccionada.Cells["Nacionalidad"].Value.ToString();
            dateTimePickerFechaNac.Value = Convert.ToDateTime(filaSeleccionada.Cells["Fecha_Nacimiento"].Value);
            checkBoxHabilitado.Checked = Convert.ToBoolean(filaSeleccionada.Cells["Habilitado"].Value);

            tipoDocClienteAModificar = comboBoxTipoDoc.SelectedItem.ToString();
            nroDocClienteAModificar = textBoxNroDoc.Text;
        }
    }
}
