using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;

namespace FrbaHotel.AbmHabitacion
{
    class DatosHabitacionAlta : DatosHabitacion
    {
        public DatosHabitacionAlta(Usuario usuario) : base(usuario)
        {
        }

        protected override void accionAceptar()
        {
            throw new NotImplementedException();
        }
    }
}
