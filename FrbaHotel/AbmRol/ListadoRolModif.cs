using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using FrbaHotel.Utilidades;

namespace FrbaHotel.AbmRol
{
    class ListadoRolModif : ListadoRol
    {
        protected override void agregarColumna()
        {
            DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
            columna.HeaderText = "Seleccionar";
            columna.Text = "Modificar";
            columna.Name = "columnaBoton";
            columna.UseColumnTextForButtonValue = true;

            dataGridViewRoles.Columns.Add(columna);
        }

        protected override void accionBoton(DataGridViewCellEventArgs e)
        {
            DatosRol datosRol = new DatosRol(dataGridViewRoles.CurrentRow.Cells["Nombre"].Value.ToString());
            Hide();
            datosRol.Show();
        }
    }
}
