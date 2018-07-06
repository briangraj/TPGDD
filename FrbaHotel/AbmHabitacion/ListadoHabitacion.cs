using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;

namespace FrbaHotel.AbmHabitacion
{
    public abstract partial class ListadoHabitacion : Form
    {
        protected Usuario usuario;

        public ListadoHabitacion(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            llenarTabla();
            agregarColumna();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        protected void llenarTabla()
        {
            dataGridViewHabitaciones.DataSource = DB.correrQueryTabla(queryTabla(),
                "nroHab", "%" + textBoxNroHab.Text + "%", "piso", "%" + textBoxPiso + "%", "idHotel", usuario.idHotel);
        }

        protected abstract string queryTabla();

        protected void agregarColumna()
        {
            DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
            columna.HeaderText = "Seleccionar";
            columna.Text = textoBoton();
            columna.Name = "columnaBoton";
            columna.UseColumnTextForButtonValue = true;

            dataGridViewHabitaciones.Columns.Add(columna);
        }

        protected abstract string textoBoton();

        private void dataGridViewHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewHabitaciones.Columns[e.ColumnIndex].HeaderText == "Seleccionar" && e.RowIndex != -1)
                accionBoton(e);
        }

        protected abstract void accionBoton(DataGridViewCellEventArgs e);

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.limpiarControles(Controls);
        }
    }
}
