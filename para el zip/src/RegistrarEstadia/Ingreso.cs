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

                if (numericUpDownCantHuespedes.Value > 1)
                {
                    ingresoDeHuespedes(Convert.ToInt32(numericUpDownCantHuespedes.Value));
                }
                
                registrarIngreso();

                MessageBox.Show("Se registro el ingreso correctamente");
                Close();
            }
            catch (SqlException) { }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void registrarIngreso()
        {
            DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.registrar_ingreso",
                "nroReserva", Convert.ToInt32(textBoxNroReserva.Text), "idUsuario", usuario.id, "fechaActual", Program.fechaActual);
        }

        private void ingresoDeHuespedes(int cantidadTotal)
        {
            //el que hizo la reserva ya se ingreso
            while (cantidadTotal > 1)
            {
                ResgistrarHuespedes regimen = new ResgistrarHuespedes();
                if (regimen.ShowDialog() == DialogResult.OK)
                {
                    cantidadTotal--;
                }
                else
                {
                    MessageBox.Show("Debe registrar un cliente");
                }
            }
        }

        private void validarDatos()
        {
            if (textBoxNroReserva.Text == "")
                throw new Exception("Debe ingresar un numero de reserva");

            if (numericUpDownCantHuespedes.Value < 0)
                throw new Exception("Debe ingresar una cantidad de huespedes valida");

            DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.validar_reserva_para_ingreso", "nroReserva", Convert.ToInt32(textBoxNroReserva.Text), "fechaActual", Program.fechaActual,
                "idUsuario", usuario.id);
        }
    }
}
