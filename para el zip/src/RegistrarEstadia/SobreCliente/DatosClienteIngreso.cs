using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Utilidades;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarEstadia.SobreCliente
{
    class DatosClienteIngreso : AbmCliente.DatosCliente
    {
        public DatosClienteIngreso()
            : base()
        {
            labelHabilitado.Visible = false;
            checkBoxHabilitado.Visible = false;
            checkBoxHabilitado.Checked = true;
        }

        protected override void accionAceptar()
        {
            DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.insertClientes",
                    "Nombre", textBoxNombre.Text, "Apellido", textBoxApellido.Text, "Tipo_Documento", comboBoxTipoDoc.SelectedItem, "Nro_Documento", textBoxNroDoc.Text,
                    "Mail", textBoxMail.Text, "Telefono", textBoxTelefono.Text, "Direccion", textBoxDireccion.Text, "Localidad", textBoxLocalidad.Text,
                    "Nacionalidad", textBoxNacionalidad.Text, "Fecha_Nacimiento", dateTimePickerFechaNac.Value, "Habilitado", checkBoxHabilitado.Checked);

            MessageBox.Show("Se creo el cliente");

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
