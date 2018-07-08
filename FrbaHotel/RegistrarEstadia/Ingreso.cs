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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class Ingreso : Form
    {
        private Usuario usuario;

        public Ingreso(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatos();
            }
            catch (Exception) { }
        }

        private void validarDatos()
        {
            if (textBoxNroReserva.Text == "")
                throw new Exception("Debe ingresar un numero de reserva");

            DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.validar_reserva_para_ingreso", "nroReserva", Convert.ToInt32(textBoxNroReserva.Text), "fechaActual", Program.fechaActual,
                "idUsuario", usuario.id);
        }
    }
}
