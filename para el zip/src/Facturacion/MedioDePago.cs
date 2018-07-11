using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;
using System.Data.SqlClient;

namespace FrbaHotel.Facturacion
{
    public partial class MedioDePago : Form
    {
        Reserva reserva;
        List<Item> items;

        public MedioDePago(Reserva reserva, List<Item> items)
        {
            InitializeComponent();
            this.reserva = reserva;
            this.items = items;
        }

        private void MedioDePago_Load(object sender, EventArgs e)
        {
            DB.ejecutarReader(
                "SELECT Desc_medio_pago " +
                "FROM LA_QUERY_DE_PAPEL.MedioPago",
                cargarMedioDePago);
        }

        public void cargarMedioDePago(SqlDataReader reader)
        {
            while (reader.Read())
            {
                comboBoxMedioDePago.Items.Add(reader.GetString(0));
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (comboBoxMedioDePago.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir un medio de pago");
                return;
            }

            Facturacion facturacion = new Facturacion(reserva, items, comboBoxMedioDePago.SelectedItem.ToString());
            Hide();
            facturacion.Show();
        }
    }
}
