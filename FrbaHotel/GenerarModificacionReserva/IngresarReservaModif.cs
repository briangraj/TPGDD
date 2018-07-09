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
    public partial class IngresarReservaModif : Form
    {
        private Usuario usuario;

        public IngresarReservaModif(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(!reservaValida())
                    return;

                Reserva reserva = new Reserva(Convert.ToInt32(textBoxNroReserva.Text));
                reserva.cargar();

                DatosReserva.DatosReservaModif datosReserva = new DatosReserva.DatosReservaModif(reserva, usuario);
                Hide();
                datosReserva.Show();
            }
            catch (SqlException) { }
        }

        private bool reservaValida()
        {
            if (textBoxNroReserva.Text == "")
            {
                MessageBox.Show("Debe escribir un numero de reserva");
                return false;
            }

            DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.validar_reserva_modificable", "nroReserva", Convert.ToInt32(textBoxNroReserva.Text), "fechaActual", Program.fechaActual);

            return true;
        }
    }
}
