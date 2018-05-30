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
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            byte[] pass = Usuario.encriptar(textBoxPass.Text);

            try
            {
                DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.procedure_login", "usuario", textBoxUser.Text, "contrasenia", pass);

                Usuario usuario = new Usuario(textBoxUser.Text);

                this.Hide();

                SeleccionarFuncionalidad form = new SeleccionarFuncionalidad(usuario);
                form.ShowDialog();
            }
            catch (SqlException ex)
            {
                if(ex.Message == "Usuario incorrecto")
                    errorProviderInicio.SetError(textBoxUser, "Usuario incorrecto");
                else if(ex.Message == "Usuario inhabilitado")
                    errorProviderInicio.SetError(textBoxUser, "Usuario inhabilitado");
                else
                    errorProviderInicio.SetError(textBoxPass, ex.Message);
            }
        }
    }
}
