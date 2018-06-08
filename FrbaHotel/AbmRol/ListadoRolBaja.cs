using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using FrbaHotel.Utilidades;

namespace FrbaHotel.AbmRol
{
    class ListadoRolBaja : ListadoRol
    {
        protected override void llenarTabla()
        {
            dataGridViewRoles.DataSource = DB.correrQueryTabla(
                "SELECT Nombre " +
                "FROM LA_QUERY_DE_PAPEL.Rol " +
                    "WHERE Nombre like '%" + textBoxNombreRol.Text + "%'" +
                        "AND Habilitado = 1");
        }

        protected override String textoBoton()
        {
            return "Eliminar";
        }

        protected override void accionBoton(DataGridViewCellEventArgs e)
        {
            DB.correrQuery(
                "DELETE FROM LA_QUERY_DE_PAPEL.Rol " +
                "WHERE Nombre = '" + dataGridViewRoles.CurrentRow.Cells["Nombre"].Value.ToString() + "'");

            llenarTabla();
            MessageBox.Show("Rol eliminado");
        }
    }
}
