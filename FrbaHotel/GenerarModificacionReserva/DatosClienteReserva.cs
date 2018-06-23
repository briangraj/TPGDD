using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;
using System.Windows.Forms;

namespace FrbaHotel.GenerarModificacionReserva
{
    class DatosClienteReserva : AbmCliente.DatosCliente
    {
        private Reserva reserva;

        public DatosClienteReserva(Reserva reserva) : base()
        {
            this.reserva = reserva;
            labelHabilitado.Visible = false;
            checkBoxHabilitado.Visible = false;
        }

        protected override void accionAceptar()
        {
            DB.correrQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.clientes (Nombre, Apellido, Tipo_Documento, Nro_Documento, Mail, Telefono, Direccion, Localidad, Nacionalidad, Fecha_Nacimiento, Habilitado) " +
                    "VALUES (@nombre, @apellido, @tipoDocumento, @nroDocumento, @mail, @telefono, @direccion, @localidad, @nacionalidad, @fechaNacimiento, 1)",
                    "nombre", textBoxNombre.Text, "apellido", textBoxApellido.Text, "tipoDocumento", textBoxTipoDoc.Text, "nroDocumento", textBoxNroDoc.Text,
                    "mail", textBoxMail.Text, "telefono", textBoxTelefono.Text, "direccion", textBoxDireccion.Text, "localidad", textBoxLocalidad.Text,
                    "nacionalidad", textBoxNacionalidad.Text, "fechaNacimiento", dateTimePickerFechaNac.Value, "habilitado", checkBoxHabilitado.Checked);

            MessageBox.Show("Se creo el cliente");


            GenerarReserva generar = new GenerarReserva(reserva, new Cliente(textBoxTipoDoc.Text, Convert.ToInt32(textBoxNroDoc.Text)));
            Hide();
            generar.Show();
        }
    }
}
