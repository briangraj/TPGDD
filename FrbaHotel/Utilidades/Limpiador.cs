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

        public static void LimpiarTextBox(Control.ControlCollection controls)
        {

            foreach (Control control in controls)
            {
                if (control is TextBox)
                    ((TextBox)control).Clear();
            }
        }

        public static void LimpiarCheckBox(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
            }
        }

        public static void LimpiarComboBox(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is ComboBox)
                    ((ComboBox)control).SelectedIndex = -1;
            }
        }

        public static void LimpiarCheckBoxList(CheckedListBox lista) 
        {
            foreach (int i in lista.CheckedIndices)
            {
                lista.SetItemCheckState(i, CheckState.Unchecked);
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
