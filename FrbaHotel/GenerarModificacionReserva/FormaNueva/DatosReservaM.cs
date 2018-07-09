using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;

namespace FrbaHotel.GenerarModificacionReserva.FormaNueva
{
    class DatosReservaM : DatosReserv
    {
        private Reserva reserva;

        public DatosReservaM(Reserva reserva, Usuario usuario)
            : base(usuario)
        {
            this.reserva = reserva;
            cargarReserva();
            cargarHabitaciones();
        }

        private void cargarReserva()
        {
            dateTimePickerDesde.Value = reserva.fechaInicio;
            dateTimePickerHasta.Value = reserva.fechaFin;
            comboBoxTipoHab.SelectedIndex = comboBoxTipoHab.Items.IndexOf(reserva.tipoHabitacion);
            comboBoxTipoReg.SelectedIndex = comboBoxTipoReg.Items.IndexOf(reserva.descRegimen);
        }

        protected override System.Data.DataTable tablaDeHabitaciones(int idRegimen, string tipoHab)
        {
            //todo ver que el hotel no este en baja
            return DB.ejecutarQueryDeTabla(
                "SELECT  h.Nro_Habitacion, Piso, Ubicacion, th.Descripcion AS Tipo_Habitacion, h.Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Habitacion h " +
                //"LEFT JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rha ON h.Id_Hotel = rha.Id_Hotel AND h.Nro_Habitacion = rha.Nro_Habitacion " +
                //"LEFT JOIN LA_QUERY_DE_PAPEL.reservas_sin_cancelar r ON rha.Id_Reserva = r.Id_Reserva " +
                    "JOIN LA_QUERY_DE_PAPEL.Tipo_Habitacion th ON h.Tipo_Hab = th.Id_tipo " +
                    "JOIN LA_QUERY_DE_PAPEL.RegimenxHotel rho ON h.Id_Hotel = rho.Id_Hotel " +
                        "WHERE rho.Id_Hotel = @idHotel " +
                            "AND rho.Id_Regimen = @idRegimen " +
                            "AND h.Habilitada = 1 " +
                            "AND th.Descripcion LIKE @tipoHab " +
                            "AND h.Nro_Habitacion NOT IN ( " +
                                    "SELECT distinct Nro_Habitacion FROM LA_QUERY_DE_PAPEL.reservas_sin_cancelar r " +
                                    "JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rh ON r.Id_Reserva = rh.Id_Reserva " +
                                        "WHERE Id_Hotel = @idHotel " +
                                            "AND Fecha_Inicio < @fechaHasta  AND Fecha_Fin > @fechaDesde)",
                "idHotel", usuario.idHotel, "idRegimen", idRegimen, "tipoHab", "%" + tipoHab + "%", "fechaDesde", dateTimePickerDesde.Value, "fechaHasta", dateTimePickerHasta.Value); ;
        }

        protected override void accionBotonSiguiente()
        {
            throw new NotImplementedException();
        }
    }
}
