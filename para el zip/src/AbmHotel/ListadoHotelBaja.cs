using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmHotel
{
    class ListadoHotelBaja : ListadoHotel
    {
        protected override string textoBoton()
        {
            return "Dar de baja";
        }

        protected override void accionBoton(System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            BajaHotel bajaHotel = new BajaHotel(Convert.ToInt32(dataGridViewHoteles.Rows[e.RowIndex].Cells["Id_Hotel"].Value));
            Hide();
            bajaHotel.Show();
        }
    }
}
