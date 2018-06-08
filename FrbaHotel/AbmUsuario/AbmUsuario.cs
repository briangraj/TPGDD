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

namespace FrbaHotel.AbmUsuario
{
    public partial class AbmUsuario : Form
    {
        private Usuario usuario;

        public AbmUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            DatosUsuario datosUsuario = new DatosUsuario();
            datosUsuario.Show();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            ListadoUsuarioBaja listadoBaja = new ListadoUsuarioBaja(usuario);
            listadoBaja.Show();
        }

        private void buttonModificacion_Click(object sender, EventArgs e)
        {
            ListadoUsuarioModif listadoModif = new ListadoUsuarioModif(usuario);
            listadoModif.Show();
        }
    }
}
