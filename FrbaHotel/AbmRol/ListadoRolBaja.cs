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
        protected override void agregarColumna()
        {
            DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
            columna.HeaderText = "Seleccionar";
            columna.Text = "Eliminar";
            columna.Name = "columnaBoton";
            columna.UseColumnTextForButtonValue = true;

            dataGridViewRoles.Columns.Add(columna);
        }

        protected override void accionBoton(DataGridViewCellEventArgs e)
        {
            DB.correrQuery(
                "DELETE FROM LA_QUERY_DE_PAPEL.Rol " +
                "WHERE Nombre = '" + dataGridViewRoles.CurrentRow.Cells["Nombre"].Value.ToString() + "'");

            MessageBox.Show("Rol eliminado");
        }

        protected override DataTable contenidoTabla()
        {
            return DB.correrQueryTabla(
                "SELECT Nombre " +
                "FROM LA_QUERY_DE_PAPEL.Rol " +
                    "WHERE Nombre like '%" + textBoxNombreRol.Text + "%'" +
                        "AND Habilitado = 1");
        }
    }
}
