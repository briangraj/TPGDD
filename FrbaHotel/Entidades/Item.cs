using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Item
    {
        public string descripcion;
        public decimal precio;
        public int cantidad;

        public Item(string descripcion, decimal precio, int cantidad)
        {
            this.descripcion = descripcion;
            this.precio = precio;
            this.cantidad = cantidad;
        }
    }
}
