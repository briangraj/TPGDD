using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;

namespace FrbaHotel.GenerarModificacionReserva
{
    class ModificarReserva : InfoReserva
    {
        public ModificarReserva(Reserva reserva) : base(reserva) { }

        protected override void generarInfoReserva()
        {
           DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.actualizar_reserva",
                "nroReserva", reserva.id, "idRegimen", idRegimen(), "fechaDeModificacion", Program.fechaActual, "cantNoches", cantNoches(), "fechaInicio", reserva.fechaInicio,
                "fechaFin", reserva.fechaFin, "idUsuario", reserva.usuario.id);

            DB.ejecutarQuery(
                "DELETE FROM LA_QUERY_DE_PAPEL.ReservaxHabitacion " +
                "WHERE Id_Reserva = @idReserva",
                "idReserva", reserva.id);

            insertarReservaxHabitacion(reserva.id);

            labelMensaje.Text = "Su reserva se modifico correctamente";
            textBoxNroReserva.Text = reserva.id.ToString();
        }
    }
}
