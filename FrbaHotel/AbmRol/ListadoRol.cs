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
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        private void llenarTabla()
        {
            dataGridViewRoles.DataSource = DB.correrQueryTabla(
                "SELECT Nombre " +
                "FROM LA_QUERY_DE_PAPEL.Rol " +
                    "WHERE Nombre like '%" + textBoxNombreRol.Text + "%'");

            agregarColumna();
        }

        protected abstract void agregarColumna();
    }
}
