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
        Usuario user;

        public SeleccionarFuncionalidad(Usuario usuario)
        {
            this.user = usuario;
            InitializeComponent();

            DB.ejecutarReader(
                "SELECT F.descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Funcionalidad F " +
                    "JOIN LA_QUERY_DE_PAPEL.FuncionalidadxRol FR " +
                    "ON F.Id_Funcion = FR.Id_Funcion " +
                        "AND FR.Id_Rol = " + "1" //TODO hay que ver que rol tiene el usuario
            , this.cargarComboBox);

            
        }

        public void cargarComboBox(SqlDataReader reader)
        {
            while (reader.Read())
            {
                comboBoxFuncionalidades.Items.Add(reader.GetString(0));
            }
        }
    }
}
