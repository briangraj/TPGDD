using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmHabitacion
{
    class ListadoHabitacionBaja : ListadoHabitacion
    {
        protected override string queryTabla()
        {
            return 
                "SELECT Nro_Habitacion, Id_Hotel, Piso, Ubicacion, Tipo_Hab, Descripcion, Habilitada " +
                "FROM LA_QUERY_DE_PAPEL.Habitacion " +
                    "WHERE Nro_Habitacion LIKE @nroHab " +
                        "AND Piso LIKE @piso " +
                        "AND Habilitada = 1";
        }

        protected override string textoBoton()
        {
            return "Eliminar";
        }
    }
}
