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
            this.reserva = reserva;
            this.items = items;
            this.medioDePago = medioDePago;
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            decimal total = items.Sum(item => item.precio * item.cantidad);

            int nroFactura = Convert.ToInt32(DB.ejecutarProcedimientoEscalar("LA_QUERY_DE_PAPEL.generar_factura", "Nro_Factura",
                "nroReserva", reserva.id, "medioDePago", medioDePago, "fechaActual", Program.fechaActual, "Total_a_pagar", total));

            foreach (Item item in items)
            {
                DB.ejecutarQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.Item (Nro_Factura, Descripcion, Precio, Cantidad) " +
                    "VALUES (@nroFactura, @descripcion, @precio, @cantidad)",
                    "nroFactura", nroFactura, "descripcion", item.descripcion, "precio", item.precio, "cantidad", item.cantidad);
            }

            DB.ejecutarQuery(
                    "UPDATE LA_QUERY_DE_PAPEL.Estadia " +
                    "SET Fecha_egreso = @fechaActual, Usuario_egreso_id = @idUsuario " +
                        "WHERE Id_Reserva = @nroReserva",
                    "fechaActual", Program.fechaActual, "idUsuario", reserva.usuario.id, "nroReserva", reserva.id);

            dataGridViewItems.DataSource = DB.ejecutarQueryDeTabla(
                "SELECT Descripcion, Precio AS Precio_Unitario, Cantidad " +
                "FROM LA_QUERY_DE_PAPEL.Item " +
                    "WHERE Nro_Factura = @nroFactura",
                "nroFactura", nroFactura);

            textBoxNroFactura.Text = nroFactura.ToString();
            textBoxNroReserva.Text = reserva.id.ToString();
            textBoxMontoTotal.Text = total.ToString();
            textBoxMedioDePago.Text = medioDePago;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
