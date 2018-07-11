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

namespace FrbaHotel.GenerarModificacionReserva
{
    public abstract partial class InfoReserva : Form
    {
        protected Reserva reserva;

        public InfoReserva(Reserva reserva)
        {
            InitializeComponent();
            this.reserva = reserva;
        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            try
            {
                generarInfoReserva();
            }
            catch (SqlException) { }
        }

        protected abstract void generarInfoReserva();

        protected void insertarReservaxHabitacion(int idReserva)
        {
            foreach (Habitacion habitacion in reserva.habitaciones)
            {
                DB.ejecutarQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.ReservaxHabitacion (Id_Reserva, Nro_Habitacion, Id_Hotel) " +
                    "VALUES (@idReserva, @nroHabitacion, @idHotel)",
                    "idReserva", idReserva, "nroHabitacion", habitacion.nroHabitacion, "idHotel", habitacion.idHotel);
            }
        }

        protected int cantNoches()
        {
            return (reserva.fechaFin - reserva.fechaInicio).Days;
        }

        protected int idRegimen()
        {
            return DB.buscarIdRegimen(reserva.descRegimen);
        }
    }
}
