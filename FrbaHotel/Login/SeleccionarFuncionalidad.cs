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
using FrbaHotel.Utilidades;
using System.Data.SqlClient;

namespace FrbaHotel.Login
{
    public partial class SeleccionarFuncionalidad : Form
    {
        private Usuario usuario;

        public SeleccionarFuncionalidad(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();

            DB.ejecutarReader(
                "SELECT F.Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Funcionalidad F " +
                    "JOIN LA_QUERY_DE_PAPEL.FuncionalidadxRol FR ON F.Id_Funcion = FR.Id_Funcion " +
                    "JOIN LA_QUERY_DE_PAPEL.Usuario u ON FR.Id_Rol = u.Id_Rol " +
                        "WHERE Id_Usuario = " + usuario.id.ToString(),
            cargarComboBox);
        }

        public void cargarComboBox(SqlDataReader reader)
        {
            comboBoxFuncionalidades.Items.Add(reader.GetString(0));
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            if (comboBoxFuncionalidades.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una funcionalidad");
            }
            else
            {
                Form form;
                switch (comboBoxFuncionalidades.SelectedItem.ToString())
                {
                    case "ABM de rol":
                        form = new AbmRol.AbmRol();
                        break;
                    case "ABM de usuario":
                        form = new AbmUsuario.AbmUsuario(usuario);
                        break;
                    case "ABM de hotel":
                        form = new AbmHotel.AbmHotel(usuario);
                        break;
                    case "ABM de cliente":
                        form = new AbmCliente.AbmCliente();
                        break;
                    case "ABM de habitacion":
                        form = new AbmHabitacion.AbmHabitacion(usuario);
                        break;
                    case "Generar o modificar reserva":
                        form = new GenerarModificacionReserva.GenerarModificarReserva(usuario);
                        break;
                    case "Cancelar reserva":
                        form = new CancelarReserva.CancelarReserva(usuario);
                        break;
                    case "Listado estadistico":
                        form = new ListadoEstadistico.ListadoEstadistico();
                        break;
                    default:
                        return;
                }
                //form = new GenerarModificacionReserva.DatosReserva(usuario);
                form.Show();
            }
        }
    }
}
