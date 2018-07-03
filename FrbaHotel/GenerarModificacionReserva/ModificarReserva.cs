using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrbaHotel.Utilidades;
using FrbaHotel.Entidades;
using System.Data.SqlClient;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class ModificarReserva : Form
    {
        private Usuario usuario;

        public ModificarReserva(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Reserva reserva = new Reserva(Convert.ToInt32(textBoxNroReserva.Text));
                reserva.cargar();
            }
            catch (SqlException) { }
        }
    }
}
