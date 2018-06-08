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

        public static void textBoxsVacios(ErrorProvider errorProvider, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox)
                    if(((TextBox)control).Text == "")
                        errorProvider.SetError(control, "No puede estar vacio");

                textBoxsVacios(errorProvider, control.Controls);
            }
        }
    }
}
