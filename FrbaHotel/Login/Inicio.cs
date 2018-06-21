using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaHotel.Utilidades;
using FrbaHotel.Entidades;

namespace FrbaHotel.Login
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            textBoxUser.Text = "admin";
            textBoxPass.Text = "w23e";
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            byte[] pass = Usuario.encriptar(textBoxPass.Text);
            errorProviderInicio.Clear();

            try
            {
                DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.procedure_login", "usuario", textBoxUser.Text, "contrasenia", pass);

                Usuario usuario = new Usuario(textBoxUser.Text);
                usuario.cargar();

                SeleccionarHotel form = new SeleccionarHotel(usuario);
                form.Show();
                Hide();
            }
            catch (SqlException){ }
        }

        private void buttonGuest_Click(object sender, EventArgs e)
        {
            try
            {  
                Usuario usuario = new Usuario("guest");
                usuario.cargar();

                SeleccionarHotel form = new SeleccionarHotel(usuario);
                form.Show();
                Hide();
            }
            catch (SqlException) { }
        }
    }
}
