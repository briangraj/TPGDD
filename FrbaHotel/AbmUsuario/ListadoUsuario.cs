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
    public abstract partial class ListadoUsuario : Form
    {
        protected Usuario usuario;

        public ListadoUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            llenarTabla();
            dataGridViewUsuarios.Columns["Password"].Visible = false;
            dataGridViewUsuarios.Columns["Id_Usuario"].Visible = false;
            dataGridViewUsuarios.Columns["Habilitado"].Visible = false;
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

            dataGridViewUsuarios.DataSource = DB.correrQueryTabla(queryTabla(),
                "nombre", "%" + textBoxNombre.Text + "%", "apellido", "%" + textBoxApellido.Text + "%", "tipoDocumento", "%" + tipoDoc + "%",
                "nroDocumento", "%" + maskedTextBoxNroDoc.Text + "%", "mail", "%" + textBoxMail.Text + "%", "idHotel", usuario.idHotel);
        }

        protected abstract String queryTabla();

        protected void agregarColumna()
        {
            DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
            columna.HeaderText = "Seleccionar";
            columna.Text = textoBoton();
            columna.Name = "columnaBoton";
            columna.UseColumnTextForButtonValue = true;

            dataGridViewUsuarios.Columns.Add(columna);
        }

        protected abstract String textoBoton();

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewUsuarios.Columns[e.ColumnIndex].HeaderText == "Seleccionar" && e.RowIndex != -1)
                accionBoton(e);
        }

        protected abstract void accionBoton(DataGridViewCellEventArgs e);
    }
}
