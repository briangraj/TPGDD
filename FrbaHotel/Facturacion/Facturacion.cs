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

namespace FrbaHotel.Facturacion
{
    public partial class Facturacion : Form
    {
        Reserva reserva;
        List<Item> items;
        string medioDePago;

        public Facturacion(Reserva reserva, List<Item> items, string medioDePago)
        {
            InitializeComponent();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            int nroFactura = Convert.ToInt32(DB.correrFuncion("LA_QUERY_DE_PAPEL.generar_factura", "nroReserva", reserva.id, "medioDePago", medioDePago, "fechaActual", Program.fechaActual));
        }
    }
}
