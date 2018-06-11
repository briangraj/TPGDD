using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace FrbaHotel.Utilidades
{
    public class Limpiador
    {
        //static DateTime fechaActual = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["Fecha"]);

        public static void limpiarControles(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox)
                    ((TextBox)control).Clear();

                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;

                else if (control is ComboBox)
                    ((ComboBox)control).SelectedIndex = -1;

                else if (control is CheckedListBox)
                {
                    foreach (int i in ((CheckedListBox)control).CheckedIndices)
                    {
                        ((CheckedListBox)control).SetItemCheckState(i, CheckState.Unchecked);
                    }
                }

                limpiarControles(control.Controls);
            }
        }
        /*
        public static void LimpiarDateTimePicker(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is DateTimePicker)
                    ((DateTimePicker)control).Value = fechaActual;
            }
        }
         */
    }
}
