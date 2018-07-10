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
            DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.insertClientes",
                    "Nombre", textBoxNombre.Text, "Apellido", textBoxApellido.Text, "Tipo_Documento", comboBoxTipoDoc.SelectedItem, "Nro_Documento", textBoxNroDoc.Text,
                    "Mail", textBoxMail.Text, "Telefono", textBoxTelefono.Text, "Direccion", textBoxDireccion.Text, "Localidad", textBoxLocalidad.Text,
                    "Nacionalidad", textBoxNacionalidad.Text, "Fecha_Nacimiento", dateTimePickerFechaNac.Value, "Habilitado", checkBoxHabilitado.Checked);

            MessageBox.Show("Se creo el cliente");

            GenerarReserva generar = new GenerarReserva(reserva, new Cliente(comboBoxTipoDoc.SelectedItem.ToString(), Convert.ToInt32(textBoxNroDoc.Text)));
            Hide();
            generar.Show();
        }
    }
}
