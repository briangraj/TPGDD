using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrbaHotel.Utilidades;

namespace FrbaHotel.AbmRol
{
    public abstract partial class ListadoRol : Form
    {
        public ListadoRol()
        {
            InitializeComponent();
            llenarTabla();
            agregarColumna();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        private void llenarTabla()
        {
            dataGridViewRoles.DataSource = contenidoTabla();

        }

        protected abstract DataTable contenidoTabla();

        protected abstract void agregarColumna();

        private void dataGridViewRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != -1)
                return;

            accionBoton(e);
            llenarTabla();
        }

        protected abstract void accionBoton(DataGridViewCellEventArgs e);

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.LimpiarTextBox(Controls);
            llenarTabla();
        }
    }
}
