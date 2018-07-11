using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    class ListadoHabitacionBaja : ListadoHabitacion
    {
        public ListadoHabitacionBaja(Usuario usuario) : base(usuario) {}
        
        protected override string queryTabla()
        {
            return 
                "SELECT Nro_Habitacion, Piso, Ubicacion, th.Descripcion AS Tipo_Habitacion, h.Descripcion, Habilitada " +
                "FROM LA_QUERY_DE_PAPEL.Habitacion h " +
                "JOIN LA_QUERY_DE_PAPEL.Tipo_Habitacion th ON h.Tipo_Hab = th.Id_tipo " +
                    "WHERE Nro_Habitacion LIKE @nroHab " +
                        "AND Piso LIKE @piso " +
                        "AND Id_Hotel = @idHotel " +
                        "AND Habilitada = 1";
        }

        protected override string textoBoton()
        {
            return "Eliminar";
        }

        protected override void accionBoton(DataGridViewCellEventArgs e)
        {
            DB.ejecutarQuery(
                "UPDATE LA_QUERY_DE_PAPEL.Habitacion " +
                "SET Habilitada = 0 " +
                    "WHERE Id_Hotel = @idHotel " +
                    "AND Nro_Habitacion = @nroHabitacion",
                "idHotel", usuario.idHotel, "nroHabitacion", Convert.ToInt32(dataGridViewHabitaciones.CurrentRow.Cells["Nro_Habitacion"].Value));

            llenarTabla();
            MessageBox.Show("Habitacion eliminada");
        }
    }
}
