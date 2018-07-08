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

        private string queryTabla()
        {
            return "SELECT Id_Hotel, Nombre, Mail, Telefono, Direccion, Cant_Estrellas, Recarga_Estrella, Ciudad, Pais, Fecha_Creacion " +
                    "FROM LA_QUERY_DE_PAPEL.Hotel " +
                        "WHERE Nombre LIKE @nombre " +
                            "AND Cant_Estrellas LIKE @cantEstrellas " +
                            "AND Ciudad LIKE @ciudad " +
                            "AND Pais LIKE @pais";
        }

        protected void agregarColumna()
        {
            DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
            columna.HeaderText = "Seleccionar";
            columna.Text = textoBoton();
            columna.Name = "columnaBoton";
            columna.UseColumnTextForButtonValue = true;

            dataGridViewHoteles.Columns.Add(columna);
        }

        protected abstract string textoBoton();

        private void dataGridViewHoteles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewHoteles.Columns[e.ColumnIndex].HeaderText == "Seleccionar" && e.RowIndex != -1)
                accionBoton(e);
        }

        protected abstract void accionBoton(DataGridViewCellEventArgs e);

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.limpiarControles(Controls);
        }
    }
}
