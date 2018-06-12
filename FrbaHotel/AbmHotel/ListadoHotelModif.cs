using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    class ListadoHotelModif : ListadoHotel
    {
        protected override String queryTabla()
        {
            return "SELECT Id_Hotel, Nombre, Mail, Telefono, Direccion, Cant_Estrellas, Ciudad, Pais, Fecha_Creacion " +
                    "FROM LA_QUERY_DE_PAPEL.Hotel " +
                        "WHERE Nombre LIKE @nombre " +
                            "AND Cant_Estrellas LIKE @cantEstrellas " +
                            "AND Ciudad LIKE @ciudad " +
                            "AND Pais LIKE @pais";
        }

        protected override String textoBoton()
        {
            return "Modificar";
        }

        protected override void accionBoton(DataGridViewCellEventArgs e)
        {
            DatosHotel datosHotel = new DatosHotel(dataGridViewHoteles.CurrentRow);
            Hide();
            datosHotel.Show();
        }
    }
}
