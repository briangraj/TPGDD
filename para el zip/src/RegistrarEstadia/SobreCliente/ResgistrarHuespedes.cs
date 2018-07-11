using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarEstadia
{
    public partial class ResgistrarHuespedes : Form
    {
        public ResgistrarHuespedes()
        {
            InitializeComponent();
        }

        private void buttonClienteNuevo_Click(object sender, EventArgs e)
        {
            SobreCliente.DatosClienteIngreso datosCliente = new SobreCliente.DatosClienteIngreso();
            DialogResult = datosCliente.ShowDialog();
            Close();
        }

        private void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            SobreCliente.ListadoClienteIngreso listado = new SobreCliente.ListadoClienteIngreso();
            DialogResult = listado.ShowDialog();
            Close();
        }
    }
}
