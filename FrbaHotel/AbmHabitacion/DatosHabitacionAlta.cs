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
            string ubicacion = "N";
            if(checkBoxVistaExterior.Checked)
                ubicacion = "S";

            int idTipoHab = (int)DB.correrQueryEscalar(
                "SELECT Id_tipo " +
                "FROM LA_QUERY_DE_PAPEL.Tipo_Habitacion " +
                    "WHERE Descripcion = @descripcion",
                "descripcion", comboBoxTipoHab.SelectedItem);

            DB.correrQuery(
                "INSERT INTO LA_QUERY_DE_PAPEL.Habitacion(Nro_Habitacion, Id_Hotel, Piso, Ubicacion, Tipo_Hab, Habilitada) " +
                "VALUES (@nroHabitacion, @idHotel, @piso, @ubicacion, @tipoHab, @habilitada)",
                "nroHabitacion", numericUpDownNroHab.Value, "idHotel", usuario.idHotel, "piso", numericUpDownPiso.Value, "ubicacion", ubicacion, "tipoHab", idTipoHab,
                "habilitada", checkBoxHabilitada.Checked);

            MessageBox.Show("Se creo la habitacion");
        }
    }
}
