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
    public partial class Egreso : Form
    {
        private Usuario usuario;
        private Reserva reserva;
        private List<Item> items = new List<Item>();
            
        public Egreso(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                reserva = new Reserva(Convert.ToInt32(textBoxNroReserva.Text));
                reserva.cargar();

                DB.ejecutarReader(
                    "SELECT Nro_Habitacion, " +
                        "(SELECT Precio * th.Porcentual + Recarga_Estrella FROM LA_QUERY_DE_PAPEL.Regimen, LA_QUERY_DE_PAPEL.Hotel WHERE Descripcion = @descripcion AND Id_Hotel = @idHotel) AS Precio " +
                    "FROM LA_QUERY_DE_PAPEL.ReservaxHabitacion " +
                        "WHERE Id_Reserva = @idReserva",
                    cargarHabitaciones, "idReserva", reserva.id, "descripcion", reserva.descRegimen, "idHotel", usuario.idHotel);

                RegistrarConsumible.RegistrarConsumibles registrarConsumible = new RegistrarConsumible.RegistrarConsumibles(reserva, items);
                Hide();
                registrarConsumible.Show();
            }
            catch (SqlException) { }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cargarHabitaciones(SqlDataReader reader)
        {
            int cantNoches = (Program.fechaActual - reserva.fechaInicio).Days;
            int nochesQueNoSeQuedo = (reserva.fechaFin - Program.fechaActual).Days;

            while (reader.Read())
            {
                Item item = new Item("Estadia habitacion: " + reader.GetString(0), reader.GetDecimal(1) * cantNoches, 1);
                items.Add(item);

                if (nochesQueNoSeQuedo > 0)
                {
                    Item item2 = new Item("Dia reservado sin alojo, habitacion: " + reader.GetString(0), reader.GetDecimal(1) * nochesQueNoSeQuedo, 1);
                    items.Add(item2);
                }
            }
        }

        private void validarDatos()
        {
            if (textBoxNroReserva.Text == "")
                throw new Exception("Debe ingresar un numero de reserva");

            DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.validar_reserva_para_egreso", "nroReserva", Convert.ToInt32(textBoxNroReserva.Text), "fechaActual", Program.fechaActual,
                "idUsuario", usuario.id);
        }
    }
}
