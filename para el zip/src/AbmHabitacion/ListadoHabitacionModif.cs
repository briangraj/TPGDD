using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;

namespace FrbaHotel.AbmHabitacion
{
    class ListadoHabitacionModif : ListadoHabitacion
    {
        public ListadoHabitacionModif(Usuario usuario) : base(usuario) { }

        protected override string queryTabla()
        {
            return
                "SELECT Nro_Habitacion, Piso, Ubicacion, th.Descripcion AS Tipo_Habitacion, h.Descripcion, Habilitada " +
                "FROM LA_QUERY_DE_PAPEL.Habitacion h " +
                "JOIN LA_QUERY_DE_PAPEL.Tipo_Habitacion th ON h.Tipo_Hab = th.Id_tipo " +
                    "WHERE Nro_Habitacion LIKE @nroHab " +
                        "AND Piso LIKE @piso " +
                        "AND Id_Hotel = @idHotel";
        }

        protected override string textoBoton()
        {
            return "Modificar";
        }

        protected override void accionBoton(System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            DatosHabitacionModif datosHabitacion = new DatosHabitacionModif(dataGridViewHabitaciones.CurrentRow, usuario);
            Hide();
            datosHabitacion.Show();
        }
    }
}
