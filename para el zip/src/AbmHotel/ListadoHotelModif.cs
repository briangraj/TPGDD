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
        protected override String textoBoton()
        {
            return "Modificar";
        }

        protected override void accionBoton(DataGridViewCellEventArgs e)
        {
            DatosHotelModif datosHotel = new DatosHotelModif(dataGridViewHoteles.CurrentRow);
            Hide();
            datosHotel.Show();
        }
    }
}
