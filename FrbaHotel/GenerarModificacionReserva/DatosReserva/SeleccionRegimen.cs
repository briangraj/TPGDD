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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class SeleccionRegimen : Form
    {
        private Usuario usuario;
        public string descripcionRegimen;

        public SeleccionRegimen(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void dataGridViewRegimenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRegimenes.Columns[e.ColumnIndex].HeaderText != "Seleccionar" || e.RowIndex == -1)
                return;

            descripcionRegimen = dataGridViewRegimenes.CurrentRow.Cells["Descripcion"].Value.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SeleccionRegimen_Load(object sender, EventArgs e)
        {
            dataGridViewRegimenes.DataSource = DB.ejecutarQueryDeTabla(
                "SELECT Descripcion, Precio " +
                "FROM LA_QUERY_DE_PAPEL.RegimenxHotel rh " +
                    "JOIN LA_QUERY_DE_PAPEL.Regimen r " +
                        "ON rh.Id_Regimen = r.Id_Regimen " +
                    "WHERE rh.Id_Hotel = @idHotel",
                "idHotel", usuario.idHotel);

            DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
            columna.HeaderText = "Seleccionar";
            columna.Text = "Seleccionar";
            columna.Name = "columnaBoton";
            columna.UseColumnTextForButtonValue = true;

            dataGridViewRegimenes.Columns.Add(columna);
        }
    }
}
