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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class RegistrarConsumibles : Form
    {
        private Reserva reserva;
        private List<Item> items;
        protected DataTable tablaConsumiblesSeleccionados = new DataTable();
        
        public RegistrarConsumibles(Reserva reserva, List<Item> items)
        {
            InitializeComponent();
            this.reserva = reserva;
            this.items = items;
        }

        private void RegistrarConsumibles_Load(object sender, EventArgs e)
        {
            DataTable tabla = DB.ejecutarQueryDeTabla(
                "SELECT Id_Consumible, Descripcion, Precio " +
                "FROM LA_QUERY_DE_PAPEL.Consumible");

            dataGridViewConsumibles.DataSource = tabla;

            tablaConsumiblesSeleccionados = tabla.Clone();
            tablaConsumiblesSeleccionados.Clear();
            dataGridViewConsumiblesSeleccionados.DataSource = tablaConsumiblesSeleccionados;
        }

        private void dataGridViewConsumibles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            DataGridViewRow fila = dataGridViewConsumibles.Rows[e.RowIndex];

            tablaConsumiblesSeleccionados.Rows.Add(
                fila.Cells["Id_Consumible"].Value,
                fila.Cells["Descripcion"].Value,
                fila.Cells["Precio"].Value);
        }

        private void dataGridViewConsumiblesSeleccionados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            string idConsumible = dataGridViewConsumiblesSeleccionados.CurrentRow.Cells["Id_Consumible"].Value.ToString();

            tablaConsumiblesSeleccionados.Rows.Remove(tablaConsumiblesSeleccionados.Select("Id_Consumible = " + idConsumible)[0]);
        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            decimal totalConsumibles = 0;

            foreach (DataRow fila in tablaConsumiblesSeleccionados.Rows)
            {
                if(existeConsumible(fila["Descripcion"].ToString())){
                    items.Find(item => item.descripcion == fila["Descripcion"].ToString()).cantidad++;
                }
                else
                {
                    Item item = new Item(fila["Descripcion"].ToString(), Convert.ToDecimal(fila["Precio"]), 1);
                    items.Add(item);
                }

                totalConsumibles -= Convert.ToDecimal(fila["Precio"]);
            }

            if (reserva.descRegimen.Contains("All"))
            {
                Item item = new Item("Descuento por regimen de estadia: " + reserva.descRegimen, totalConsumibles, 1);
                items.Add(item);
            }

            Facturacion.MedioDePago medioDePago = new Facturacion.MedioDePago(reserva, items);
            Hide();
            medioDePago.Show();
        }

        private bool existeConsumible(string descripcion)
        {
            return items.Any(item => item.descripcion == descripcion);
        }
    }
}
