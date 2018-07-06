using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;

namespace FrbaHotel.GenerarModificacionReserva
{
    public class Parche : DatosReserva
    {
        public Parche() { }

        public Parche(Usuario usuario) : base(usuario) { }

        protected override System.Windows.Forms.ComboBox ComboBoxTipoHab()
        {
            throw new NotImplementedException();
        }

        protected override System.Windows.Forms.ComboBox ComboBoxTipoReg()
        {
            throw new NotImplementedException();
        }

        protected override System.Windows.Forms.DataGridView DataGridViewReserva()
        {
            throw new NotImplementedException();
        }

        protected override System.Windows.Forms.ErrorProvider ErrorProviderReserva()
        {
            throw new NotImplementedException();
        }

        protected override System.Windows.Forms.DateTimePicker DateTimePickerDesde()
        {
            throw new NotImplementedException();
        }

        protected override System.Windows.Forms.DateTimePicker DateTimePickerHasta()
        {
            throw new NotImplementedException();
        }

        protected override System.Data.DataTable tablaHabitacionesSeleccionadas()
        {
            throw new NotImplementedException();
        }
    }
}
