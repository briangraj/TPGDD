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
using System.Data.SqlClient;

namespace FrbaHotel.Login
{
    public partial class SeleccionarHotel : Form
    {
        private Usuario usuario;
        private List<Hotel> hoteles = new List<Hotel>();

        public SeleccionarHotel(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            //cargarHoteles();
        }

        private void cargarHoteles()
        {
            DB.ejecutarReader(
                "SELECT H.Nombre, H.Id_Hotel " +
                "FROM LA_QUERY_DE_PAPEL.Hotel H " +
                    "JOIN LA_QUERY_DE_PAPEL.UsuarioxHotel UH " +
                    "ON H.Id_Hotel = UH.Id_Hotel " +
                        "AND UH.Id_Rol = " + usuario.id.ToString(),
            cargarComboBox);
        }

        public void cargarComboBox(SqlDataReader reader)
        {
            hoteles.Add(new Hotel(reader.GetString(0), reader.GetInt32(1).ToString()));
            comboBoxHoteles.Items.Add(reader.GetString(0));
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            if (comboBoxHoteles.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un hotel");
                return;
            }

            usuario.idHotel = Convert.ToInt32(hoteles[comboBoxHoteles.SelectedIndex].id);

            Hide();
            SeleccionarFuncionalidad form = new SeleccionarFuncionalidad(usuario);
            form.ShowDialog();
        }
    }
}
