using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Cliente
    {
        public string tipoDocumento;
        public int nroDocumento;

        public Cliente(string tipoDocumento, int nroDocumento)
        {
            this.tipoDocumento = tipoDocumento;
            this.nroDocumento = nroDocumento;
        }
    }
}
