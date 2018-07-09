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
using System.Data.SqlClient;

namespace FrbaHotel.CancelarReserva
{
    public partial class CancelarReserva : Form
    {
        private Usuario usuario;

        public CancelarReserva(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!reservaValida())
                    return;

                DialogResult dialogResult = MessageBox.Show("¿Esta seguro?", "Confirmar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    cancelarReserva();
                }
            }
            catch (SqlException) { }
        }

        private void cancelarReserva()
        {
            DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.cancelar_reserva", "nroReserva", Convert.ToInt32(textBoxNroReserva.Text), "motivo", textBoxMotivo.Text,
                "fechaCancelacion", Program.fechaActual, "idUsuario", usuario.id);
        }

        private bool reservaValida()
        {
            if (textBoxNroReserva.Text == "")
            {
                MessageBox.Show("Debe escribir un numero de reserva");
                return false;
            }

            DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.validar_reserva_activa", "nroReserva", Convert.ToInt32(textBoxNroReserva.Text));

            return true;
        }
    }
}
