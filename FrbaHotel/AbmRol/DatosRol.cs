using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Utilidades;
using System.Data.SqlClient;
using FrbaHotel.Entidades;

namespace FrbaHotel.AbmRol
{
    public partial class DatosRol : Form
    {
        private bool modificacion;
        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

        public DatosRol()
        {
            InitializeComponent();
            modificacion = false;
            cargarFuncionalidades();
        }

        private void cargarFuncionalidades()
        {
            DB.ejecutarReader(
                "SELECT Descripcion, Id_Funcion " +
                "FROM LA_QUERY_DE_PAPEL.Funcionalidad",
            cargarCheckBoxs);
        }

        public void cargarCheckBoxs(SqlDataReader reader)
        {            
            funcionalidades.Add(new Funcionalidad(reader.GetString(0), reader.GetInt32(1).ToString()));
            checkedListBoxFuncionalidades.Items.Add(reader.GetString(0));
        }
    }
}
