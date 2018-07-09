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
    class DatosHabitacionModif : DatosHabitacion
    {
        private int nroHabitacionAModif;

        public DatosHabitacionModif(DataGridViewRow filaSeleccionada, Usuario usuario) : base(usuario)
        {
            cargarHabitacion(filaSeleccionada);
            comboBoxTipoHab.Enabled = false;
        }

        private void cargarHabitacion(DataGridViewRow filaSeleccionada)
        {
            nroHabitacionAModif = Convert.ToInt32(filaSeleccionada.Cells["Nro_Habitacion"].Value);

            numericUpDownNroHab.Value = Convert.ToInt32(filaSeleccionada.Cells["Nro_Habitacion"].Value);
            numericUpDownPiso.Value = Convert.ToInt32(filaSeleccionada.Cells["Piso"].Value);
            checkBoxVistaExterior.Checked = filaSeleccionada.Cells["Ubicacion"].Value.ToString() == "S";
            comboBoxTipoHab.SelectedIndex = comboBoxTipoHab.Items.IndexOf(filaSeleccionada.Cells["Tipo_Habitacion"].Value);
            textBoxDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value.ToString();
            checkBoxHabilitada.Checked = Convert.ToBoolean(filaSeleccionada.Cells["Habilitada"].Value);
        }

        protected override void accionAceptar()
        {
            DB.ejecutarQuery(
                "UPDATE LA_QUERY_DE_PAPEL.Habitacion (Nro_Habitacion, Piso, Ubicacion, Descripcion, Habilitada) " +
                "VALUES (@nroHabitacion, @piso, @ubicacion, @descripcion, @habilitada) " +
                    "WHERE Id_Hotel = @idHotel " +
                        "AND Nro_Habitacion = @nroHabitacionOriginal",
                "nroHabitacion", numericUpDownNroHab.Value, "piso", numericUpDownPiso.Value, "ubicacion", ubicacion(), "descdescripcion", textBoxDescripcion.Text,
                "habilitada", checkBoxHabilitada.Checked, "idHotel", usuario.idHotel, "nroHabitacionOriginal", nroHabitacionAModif);
        }
    }
}
