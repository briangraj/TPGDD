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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class GenerarReserva : Form
    {
        private Reserva reserva;
        private Cliente cliente;

        public GenerarReserva(Reserva reserva, Cliente cliente)
        {
            InitializeComponent();
            this.reserva = reserva;
            this.cliente = cliente;
        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            int idReserva = insertarReserva();

            insertarReservaxHabitacion(idReserva);
        }

        private int insertarReserva()
        {
            int idRegimen = DB.buscarIdRegimen(reserva.descRegimen);
            int cantNoches = (reserva.fechaFin - reserva.fechaInicio).Days;

            return (int)DB.correrQueryEscalar(
                "INSERT INTO LA_QUERY_DE_PAPEL.Reserva (Id_Regimen, Fecha_Reserva, Cant_Noches, Fecha_Inicio, Fecha_Fin, Estado, Tipo_Documento, Nro_Documento) output INSERTED.Id_Reserva " +
                "VALUES (@idRegimen, @fechaDeReserva, @cantNoches, @fechaInicio, @fechaFin, 'Reserva correcta', )",
                "idRegimen", idRegimen, "fechaDeReserva", Program.fechaActual, "cantNoches", cantNoches, "fechaInicio", reserva.fechaInicio, "fechaFin", reserva.fechaFin);
        }

        private void insertarReservaxHabitacion(int idReserva)
        {
            foreach (Habitacion habitacion in reserva.habitaciones)
            {
                DB.correrQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.ReservaxHabitacion (Id_Reserva, Id_Hotel, Nro_Habitacion) " +
                    "VALUES (@idReserva, @idHotel, @nroHabitacion)",
                    "idReserva", idReserva, "idHotel", habitacion.idHotel, "nroHabitacion", habitacion.nroHabitacion);
            }
        }
    }
}
