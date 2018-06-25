using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Utilidades;
using FrbaHotel.Entidades;

namespace FrbaHotel.GenerarModificacionReserva
{
    class ListadoClienteReserva : AbmUsuario.ListadoPersona
    {
        private Reserva reserva;

        public ListadoClienteReserva(Reserva reserva) : base()
        {
            this.reserva = reserva;
        }
        protected override void cargarTabla(string tipoDoc)
        {
            dataGridViewPersonas.DataSource = DB.correrQueryTabla(
                "SELECT Nombre, Apellido, Tipo_Documento, Nro_Documento, Mail, Telefono, Direccion, Localidad, Nacionalidad, Fecha_Nacimiento, Habilitado " +
                    "FROM LA_QUERY_DE_PAPEL.clientes c " +
                        "WHERE Nombre LIKE @nombre " +
                            "AND Apellido LIKE @apellido " +
                            "AND Tipo_Documento LIKE @tipoDocumento " +
                            "AND Nro_Documento LIKE @nroDocumento " +
                            "AND Mail LIKE @mail " +
                            "AND Habilitado = 1",
                "nombre", "%" + textBoxNombre.Text + "%", "apellido", "%" + textBoxApellido.Text + "%", "tipoDocumento", "%" + tipoDoc + "%",
                "nroDocumento", "%" + maskedTextBoxNroDoc.Text + "%", "mail", "%" + textBoxMail.Text + "%");
        }

        protected override string textoBoton()
        {
            return "Seleccionar";
        }

        protected override void accionBoton(System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            Cliente cliente = new Cliente(
                dataGridViewPersonas.Rows[e.RowIndex].Cells["Tipo_Documento"].Value.ToString(),
                Convert.ToInt32(dataGridViewPersonas.Rows[e.RowIndex].Cells["Nro_Documento"].Value));

            GenerarReserva generar = new GenerarReserva(reserva, cliente);
            Hide();
            generar.Show();
        }
    }
}
