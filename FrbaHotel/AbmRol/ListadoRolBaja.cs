using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
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
    }
}
