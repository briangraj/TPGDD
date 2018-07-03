using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;

namespace FrbaHotel.GenerarModificacionReserva
{
    class DatosReservaModif : DatosReservaAlta
    {
        public DatosReservaModif(Reserva reserva, Usuario usuario) : base(usuario)
        {
            cargarReserva(reserva);
        }

        private void cargarReserva(Reserva reserva)
        {
            dateTimePickerDesde.Value = reserva.fechaInicio;
            dateTimePickerHasta.Value = reserva.fechaFin;
            comboBoxTipoHab.SelectedIndex = comboBoxTipoHab.Items.IndexOf(reserva.tipoHabitacion);
            comboBoxTipoReg.SelectedIndex = comboBoxTipoReg.Items.IndexOf(reserva.descRegimen);
        }

        private void cargarHabitaciones()
        {
            idRegimen = DB.buscarIdRegimen(comboBoxTipoReg.SelectedItem.ToString());
            string tipoHab = "";
            if (comboBoxTipoHab.SelectedItem != null)
                tipoHab = comboBoxTipoHab.SelectedItem.ToString();

            dataGridViewReserva.DataSource = DB.correrQueryTabla(
                "SELECT h.Nro_Habitacion, Piso, Ubicacion, Tipo_Hab, Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Habitacion h " +
                    "JOIN LA_QUERY_DE_PAPEL.RegimenxHotel rho ON h.Id_Hotel = rho.Id_Hotel " +
                    "LEFT JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rha ON h.Id_Hotel = rha.Id_Hotel AND h.Nro_Habitacion = rha.Nro_Habitacion " +
                    "LEFT JOIN LA_QUERY_DE_PAPEL.Reserva r ON rha.Id_Reserva = r.Id_Reserva " +
                        "WHERE rho.Id_Hotel = @idHotel " +
                            "AND rho.Id_Regimen = @idRegimen " +
                            "AND h.Habilitada = 1 " +
                            "AND Tipo_Hab LIKE @tipoHab " +
                            "AND (NOT (Fecha_Inicio BETWEEN @fechaDesde AND @fechaHasta OR Fecha_Fin BETWEEN @fechaDesde AND @fechaHasta) OR Fecha_Inicio IS NULL OR Fecha_Fin IS NULL)",
                "idHotel", usuario.idHotel, "idRegimen", idRegimen, "tipoHab", "%" + tipoHab + "%", "fechaDesde", dateTimePickerDesde.Value, "fechaHasta", dateTimePickerHasta.Value);
        }
    }
}
