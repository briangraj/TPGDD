using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;

namespace FrbaHotel.GenerarModificacionReserva
{
    class GenerarReserva : InfoReserva
    {
        private Cliente cliente;

        public GenerarReserva(Reserva reserva, Cliente cliente)
            : base(reserva)
        {
            this.cliente = cliente;
        }

        protected override void generarInfoReserva()
        {
            int idReserva = insertarReserva();

            insertarReservaxHabitacion(idReserva);

            textBoxNroReserva.Text = idReserva.ToString();
        }

        private int insertarReserva()
        {
            return (int)DB.ejecutarQueryEscalar(
                "INSERT INTO LA_QUERY_DE_PAPEL.Reserva (Id_Regimen, Fecha_Reserva, Cant_Noches, Fecha_Inicio, Fecha_Fin, Estado, Tipo_Documento, Nro_Documento) output INSERTED.Id_Reserva " +
                "VALUES (@idRegimen, @fechaDeReserva, @cantNoches, @fechaInicio, @fechaFin, 'Reserva correcta', @tipoDoc, @nroDoc)",
                "idRegimen", idRegimen(), "fechaDeReserva", Program.fechaActual, "cantNoches", cantNoches(), "fechaInicio", reserva.fechaInicio, "fechaFin", reserva.fechaFin,
                "tipoDoc", cliente.tipoDocumento, "nroDoc", cliente.nroDocumento);
        }
    }
}
