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

namespace FrbaHotel.AbmUsuario
{
    public partial class DatosUsuario : Form
    {
        private Usuario usuario;
        private bool alta;

        public DatosUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            alta = true;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            errorProviderDatosUsuario.Clear();
            validarDatos();
            if (Validaciones.errorProviderConError(errorProviderDatosUsuario, Controls))
                return;

            if (alta)
                atenderAlta();
            else
                atenderModificacion();
        }

        private void validarDatos()
        {
            Validaciones.textBoxsVacios(errorProviderDatosUsuario, Controls);
        }

        /////////////////////ALTA///////////////////////////
        private void atenderAlta()
        {

        }

        /////////////////////MODIFICACION///////////////////////////
        private void atenderModificacion()
        {

        }
    }
}
