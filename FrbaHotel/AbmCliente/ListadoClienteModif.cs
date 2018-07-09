using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Utilidades;

namespace FrbaHotel.AbmCliente
{
    class ListadoClienteModif : AbmUsuario.ListadoPersona
    {
        protected override void cargarTabla(string tipoDoc)
        {
            dataGridViewPersonas.DataSource = DB.ejecutarQueryDeTabla(
                "SELECT Nombre, Apellido, Tipo_Documento, Nro_Documento, Mail, Telefono, Direccion, Localidad, Nacionalidad, Fecha_Nacimiento, Habilitado " +
                    "FROM LA_QUERY_DE_PAPEL.clientes c " +
                        "WHERE Nombre LIKE @nombre " +
                            "AND Apellido LIKE @apellido " +
                            "AND Tipo_Documento LIKE @tipoDocumento " +
                            "AND Nro_Documento LIKE @nroDocumento " +
                            "AND Mail LIKE @mail",
                "nombre", "%" + textBoxNombre.Text + "%", "apellido", "%" + textBoxApellido.Text + "%", "tipoDocumento", "%" + tipoDoc + "%",
                "nroDocumento", "%" + maskedTextBoxNroDoc.Text + "%", "mail", "%" + textBoxMail.Text + "%");
        }

        protected override string textoBoton()
        {
            return "Modificar";
        }

        protected override void accionBoton(System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            DatosClienteModif datos = new DatosClienteModif(dataGridViewPersonas.CurrentRow);
            this.Hide();
            datos.Show();
        }
    }
}
