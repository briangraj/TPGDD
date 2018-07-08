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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class IngresoEgreso : Form
    {
        private Usuario usuario;

        public IngresoEgreso(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void buttonIngreso_Click(object sender, EventArgs e)
        {
            Ingreso ingreso = new Ingreso(usuario);
            Hide();
            ingreso.Show();
        }

        private void buttonEgreso_Click(object sender, EventArgs e)
        {

        }
    }
}
