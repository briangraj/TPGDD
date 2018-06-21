using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    public partial class AbmCliente : Form
    {
        public AbmCliente()
        {
            InitializeComponent();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            DatosCliente datos = new DatosCliente();
            datos.Show();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            ListadoClienteBaja listadoBaja = new ListadoClienteBaja();
            listadoBaja.Show();
        }

        private void buttonModificacion_Click(object sender, EventArgs e)
        {
            ListadoClienteModif listadoModif = new ListadoClienteModif();
            listadoModif.Show();
        }
    }
}
