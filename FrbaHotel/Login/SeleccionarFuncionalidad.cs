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
    public partial class SeleccionarFuncionalidad : Form
    {
        Usuario user;

        public SeleccionarFuncionalidad(Usuario usuario)
        {
            this.user = usuario;
            InitializeComponent();

            DB.ejecutarReader(
                "SELECT F.Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Funcionalidad F " +
                    "JOIN LA_QUERY_DE_PAPEL.FuncionalidadxRol FR " +
                    "ON F.Id_Funcion = FR.Id_Funcion " +
                        "AND FR.Id_Rol = " + "1", //TODO hay que ver que rol tiene el usuario
            cargarComboBox);

            
        }

        public void cargarComboBox(SqlDataReader reader)
        {
            comboBoxFuncionalidades.Items.Add(reader.GetString(0));
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            if (comboBoxFuncionalidades.SelectedIndex < 0)
            {
                MessageBox.Show("SELECCIONE FUNCIONALIDAD");
            }
            else
            {
                Form form;
                switch (comboBoxFuncionalidades.SelectedItem.ToString())
                {
                    case "ABM de Rol":
                        form = new AbmRol.AbmRol();
                        break;
                    default:
                        form = new AbmRol.AbmRol();
                        break;
                }

                form.Show();
            }
        }
    }
}
