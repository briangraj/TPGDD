using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Utilidades;
using FrbaHotel.Entidades;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    class ListadoUsuarioBaja : ListadoUsuario
    {
        public ListadoUsuarioBaja(Usuario usuario) : base(usuario) { }

        protected override String queryTabla()
        {
            return  "SELECT Username, Password, Id_Rol, Nombre, Apellido, Tipo_Documento, Nro_Documento, Mail, Telefono, Direccion, Fecha_Nacimiento " +
                    "FROM LA_QUERY_DE_PAPEL.usuarios " +
                        "WHERE Nombre LIKE @nombre " +
                            "AND Apellido LIKE @apellido " +
                            "AND Tipo_Documento LIKE @tipoDocumento " +
                            "AND Nro_Documento LIKE @nroDocumento " +
                            "AND Mail LIKE @mail " +
                            "AND Habilitado = 1";
        }

        protected override String textoBoton()
        {
            return "Eliminar";
        }

        protected override void accionBoton(DataGridViewCellEventArgs e)
        {
            DB.correrQuery(
                "DELETE FROM LA_QUERY_DE_PAPEL.usuarios " +
                "WHERE Username = @username",
                "username", dataGridViewUsuarios.CurrentRow.Cells["Username"].Value.ToString());

            llenarTabla();
            MessageBox.Show("Usuario eliminado");
        }
    }
}
