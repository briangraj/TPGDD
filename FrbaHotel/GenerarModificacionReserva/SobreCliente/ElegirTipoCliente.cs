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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class ElegirTipoCliente : Form
    {
        private Reserva reserva;

        public ElegirTipoCliente(Reserva reserva)
        {
            InitializeComponent();
            this.reserva = reserva;
        }

        private void buttonClienteNuevo_Click(object sender, EventArgs e)
        {
            DatosClienteReserva datos = new DatosClienteReserva(reserva);
            Hide();
            datos.Show();
        }

        private void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            ListadoClienteReserva listado = new ListadoClienteReserva(reserva);
            Hide();
            listado.Show();
        }
    }
}
