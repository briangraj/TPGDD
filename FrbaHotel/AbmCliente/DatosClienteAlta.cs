using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Utilidades;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    class DatosClienteAlta : DatosCliente
    {
        protected override void accionAceptar()
        {
            DB.ejecutarQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.clientes (Nombre, Apellido, Tipo_Documento, Nro_Documento, Mail, Telefono, Direccion, Localidad, Nacionalidad, Fecha_Nacimiento, Habilitado) " +
                    "VALUES (@nombre, @apellido, @tipoDocumento, @nroDocumento, @mail, @telefono, @direccion, @localidad, @nacionalidad, @fechaNacimiento, @habilitado)",
                    "nombre", textBoxNombre.Text, "apellido", textBoxApellido.Text, "tipoDocumento", comboBoxTipoDoc.SelectedItem, "nroDocumento", textBoxNroDoc.Text,
                    "mail", textBoxMail.Text, "telefono", textBoxTelefono.Text, "direccion", textBoxDireccion.Text, "localidad", textBoxLocalidad.Text,
                    "nacionalidad", textBoxNacionalidad.Text, "fechaNacimiento", dateTimePickerFechaNac.Value, "habilitado", checkBoxHabilitado.Checked);

            MessageBox.Show("Se creo el cliente");
        }

    }
}
