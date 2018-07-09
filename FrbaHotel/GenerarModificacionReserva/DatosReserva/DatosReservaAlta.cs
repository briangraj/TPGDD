using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;

namespace FrbaHotel.GenerarModificacionReserva.DatosReserva
{
    class DatosReservaAlta : DatosReserva
    {
        public DatosReservaAlta(Usuario usuario) : base(usuario) { }

        protected override System.Data.DataTable tablaDeHabitaciones(int idRegimen, string tipoHab)
        {
            return DB.ejecutarFuncionDeTabla(
                "LA_QUERY_DE_PAPEL.habitaciones_libres",
                "idHotel", usuario.idHotel, "idRegimen", idRegimen, "tipoHab", "%" + tipoHab + "%", "fechaDesde", dateTimePickerDesde.Value, "fechaHasta", dateTimePickerHasta.Value);
        }

        protected override void accionBotonSiguiente()
        {
            Reserva reserva = new Reserva(dateTimePickerDesde.Value, dateTimePickerHasta.Value, comboBoxTipoHab.SelectedItem.ToString(), comboBoxTipoReg.SelectedItem.ToString(), usuario);

            abrirConfirmacion(reserva);
        }
    }
}
