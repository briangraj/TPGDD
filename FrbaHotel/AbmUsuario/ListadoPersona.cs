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
using FrbaHotel.Entidades;

namespace FrbaHotel.AbmUsuario
{
    public abstract partial class ListadoPersona : Form
    {
        protected Usuario usuario;

        //constructor para listar clientes
        public ListadoPersona()
        {
            InitializeComponent();
            llenarTabla();
            dataGridViewPersonas.Columns["Habilitado"].Visible = false;
            agregarColumna();
        }

        //constructor para listar usuarios
        public ListadoPersona(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            llenarTabla();
            dataGridViewPersonas.Columns["Password"].Visible = false;
            dataGridViewPersonas.Columns["Id_Usuario"].Visible = false;
            dataGridViewPersonas.Columns["Habilitado"].Visible = false;
            agregarColumna();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        protected void llenarTabla()
        {
            string tipoDoc = "";
            if (comboBoxTipoDoc.SelectedItem != null)
                tipoDoc = comboBoxTipoDoc.SelectedItem.ToString();

            cargarTabla(tipoDoc);
        }

        protected abstract void cargarTabla(string tipoDoc);

        protected void agregarColumna()
        {
            DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
            columna.HeaderText = "Seleccionar";
            columna.Text = textoBoton();
            columna.Name = "columnaBoton";
            columna.UseColumnTextForButtonValue = true;

            dataGridViewPersonas.Columns.Add(columna);
        }

        protected abstract String textoBoton();

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPersonas.Columns[e.ColumnIndex].HeaderText == "Seleccionar" && e.RowIndex != -1)
                accionBoton(e);
        }

        protected abstract void accionBoton(DataGridViewCellEventArgs e);

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.limpiarControles(Controls);
        }
    }
}
