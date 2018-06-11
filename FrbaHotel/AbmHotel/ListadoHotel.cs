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

namespace FrbaHotel.AbmHotel
{
    public abstract partial class ListadoHotel : Form
    {
        public ListadoHotel()
        {
            InitializeComponent();
            llenarTabla();
            agregarColumna();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.limpiarControles(Controls);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        protected void llenarTabla()
        {
            string cantEstrellas = "";
            if (comboBoxCantEstrellas.SelectedItem != null)
                cantEstrellas = comboBoxCantEstrellas.SelectedItem.ToString();

            dataGridViewHoteles.DataSource = DB.correrQueryTabla(queryTabla(),
                "nombre", "%" + textBoxNombre.Text + "%", "cantEstrellas", "%" + cantEstrellas + "%", "ciudad", "%" + textBoxCiudad.Text + "%",
                "pais", "%" + textBoxPais.Text + "%");
        }

        protected abstract String queryTabla();

        protected void agregarColumna()
        {
            DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
            columna.HeaderText = "Seleccionar";
            columna.Text = textoBoton();
            columna.Name = "columnaBoton";
            columna.UseColumnTextForButtonValue = true;

            dataGridViewHoteles.Columns.Add(columna);
        }

        protected abstract String textoBoton();
    }
}
