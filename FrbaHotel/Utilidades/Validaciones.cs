using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace FrbaHotel.Utilidades
{
    class Validaciones
    {
        public static bool errorProviderConError(ErrorProvider errorProvider, Control.ControlCollection controlCollection)
        {
            foreach (Control c in controlCollection)
                if (errorProvider.GetError(c) != "" || Validaciones.errorProviderConError(errorProvider, c.Controls))
                    return true;
            return false;
        }
        
        public static void validarControles(ErrorProvider errorProvider, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    if (((TextBox)control).Text == "")
                        errorProvider.SetError(control, "No puede estar vacio");
                }
                else if (control is ComboBox)
                {
                    if (((ComboBox)control).SelectedIndex == -1)
                        errorProvider.SetError(control, "Debe seleccionar una opcion");
                }
                else if (control is CheckedListBox)
                {
                    if (((CheckedListBox)control).CheckedItems.Count == 0)
                        errorProvider.SetError(control, "Debe elegir al menos una opcion");
                }
                    
                validarControles(errorProvider, control.Controls);
            }
        }

        public static void validarFechasPosteriores(ErrorProvider errorProvider, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is DateTimePicker)
                {
                    if (((DateTimePicker)control).Value > Program.fechaActual)
                        errorProvider.SetError(control, "La fecha no puede ser posterior al dia hoy");
                }

                validarFechasPosteriores(errorProvider, control.Controls);
            }
        }

        public static void validarFechasAnteriores(ErrorProvider errorProvider, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is DateTimePicker)
                {
                    if (((DateTimePicker)control).Value < Program.fechaActual)
                        errorProvider.SetError(control, "La fecha no puede ser anterior al dia hoy");
                }

                validarFechasAnteriores(errorProvider, control.Controls);
            }
        }
    }
}
