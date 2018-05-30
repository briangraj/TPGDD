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

namespace FrbaHotel.Login
{
    public partial class SeleccionarFuncionalidad : Form
    {
        Usuario user;

        public SeleccionarFuncionalidad(Usuario usuario)
        {
            this.user = usuario;
            InitializeComponent();
        }
    }
}
