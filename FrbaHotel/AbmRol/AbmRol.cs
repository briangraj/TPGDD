using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRol
{
    public partial class AbmRol : Form
    {
        public AbmRol()
        {
            InitializeComponent();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            DatosRol datosRol = new DatosRol();
            datosRol.Show();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            ListadoRolBaja listadoBaja = new ListadoRolBaja();
            listadoBaja.Show();
        }
    }
}
