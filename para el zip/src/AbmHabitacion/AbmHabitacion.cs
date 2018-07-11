using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrbaHotel.Entidades;

namespace FrbaHotel.AbmHabitacion
{
    public partial class AbmHabitacion : Form
    {
        private Usuario usuario;

        public AbmHabitacion(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            DatosHabitacionAlta datos = new DatosHabitacionAlta(usuario);
            datos.Show();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            ListadoHabitacionBaja listadoBaja = new ListadoHabitacionBaja(usuario);
            listadoBaja.Show();
        }

        private void buttonModificacion_Click(object sender, EventArgs e)
        {
            ListadoHabitacionModif listadoModif = new ListadoHabitacionModif(usuario);
            listadoModif.Show();
        }
    }
}
