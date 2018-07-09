using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    class DatosHabitacionAlta : DatosHabitacion
    {
        public DatosHabitacionAlta(Usuario usuario) : base(usuario) { }

        protected override void accionAceptar()
        {
            int idTipoHab = (int)DB.correrQueryEscalar(
                "SELECT Id_tipo " +
                "FROM LA_QUERY_DE_PAPEL.Tipo_Habitacion " +
                    "WHERE Descripcion = @descripcion",
                "descripcion", comboBoxTipoHab.SelectedItem);

            DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.procedure_alta_habitacion",
                "nroHabitacion", numericUpDownNroHab.Value, "idHotel", usuario.idHotel, "piso", numericUpDownPiso.Value, "ubicacion", ubicacion(), "idTipoHab", idTipoHab,
                "descripcion", textBoxDescripcion.Text, "habilitada", checkBoxHabilitada.Checked);

            MessageBox.Show("Se creo la habitacion");
        }
    }
}
