using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Utilidades;
using FrbaHotel.Entidades;

namespace FrbaHotel.GenerarModificacionReserva.SobreCliente
{
    public class SeleccionarHotelCliente : Login.SeleccionarHotel
    {
        public SeleccionarHotelCliente(Usuario usuario) : base(usuario) { }

        protected override void cargarHoteles()
        {
            DB.ejecutarReader(
                "SELECT H.Nombre, H.Id_Hotel " +
                "FROM LA_QUERY_DE_PAPEL.Hotel H ",
                cargarComboBox);
        }
    }
}
