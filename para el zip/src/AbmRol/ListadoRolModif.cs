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
    class ListadoRolModif : ListadoRol
    {
        protected override void llenarTabla()
        {
            dataGridViewRoles.DataSource = DB.correrQueryTabla(
                "SELECT Nombre " +
                "FROM LA_QUERY_DE_PAPEL.Rol " +
                    "WHERE Nombre like '%" + textBoxNombreRol.Text + "%'");
        }

        protected override String textoBoton()
        {
            return "Modificar";
        }

        protected override void accionBoton(DataGridViewCellEventArgs e)
        {
            DatosRol datosRol = new DatosRol(dataGridViewRoles.CurrentRow.Cells["Nombre"].Value.ToString());
            Hide();
            datosRol.Show();
        }
    }
}
