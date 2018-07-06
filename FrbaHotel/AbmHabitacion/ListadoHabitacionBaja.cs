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
                "SELECT Nro_Habitacion, Id_Hotel, Piso, Ubicacion, Tipo_Hab, Descripcion, Habilitada " +
                "FROM LA_QUERY_DE_PAPEL.Habitacion " +
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
            //todo falta trigger para hacer baja logica
            DB.correrQuery(
                "DELETE FROM LA_QUERY_DE_PAPEL.Habitacion " +
                "WHERE Id_Hotel = @idHotel " +
                    "AND Nro_Habitacion = @nroHabitacion",
                "idHotel", usuario.idHotel, "nroHabitacion", dataGridViewHabitaciones.CurrentRow.Cells["Nro_Habitacion"].Value.ToString());

            llenarTabla();
            MessageBox.Show("Habitacion eliminada");
        }
    }
}
