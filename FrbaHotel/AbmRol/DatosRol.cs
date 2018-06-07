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
            checkBoxHabilitado.Checked = true;
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

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            errorProviderDatos.Clear();
            validarDatos();
            if (Validaciones.errorProviderConError(errorProviderDatos, Controls))
                return;
            try
            {
                insertarRol();

                insertarFuncionalidadxRol();

                MessageBox.Show("Se creo el rol");
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void validarDatos()
        {
            if (textBoxNombreRol.Text == "")
                errorProviderDatos.SetError(textBoxNombreRol, "No debe estar vacio");

            if (checkedListBoxFuncionalidades.CheckedItems.Count == 0)
                errorProviderDatos.SetError(checkedListBoxFuncionalidades, "Debe elegir al menos una funcionalidad");
        }

        private int insertarRol()
        {
            int habilitado = checkBoxHabilitado.Checked ? 1 : 0;
            return DB.correrQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.Rol (Nombre, Habilitado) " +
                    "VALUES ('" + textBoxNombreRol.Text + "', " + habilitado.ToString() + ")");
        }

        private void insertarFuncionalidadxRol()
        {
            int idRol = buscarIdRol();
            string id;

            foreach(string desc in checkedListBoxFuncionalidades.CheckedItems)
            {
                id = funcionalidades.Find(funcionalidad => funcionalidad.descripcion == desc).id;

                DB.correrQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.FuncionalidadxRol (Id_Rol, Id_Funcion) " +
                    "VALUES (" + idRol.ToString() + ", " + id + ")");
            }
        }

        private int buscarIdRol()
        {
            return (int)DB.correrQueryEscalar(
                "SELECT Id_Rol " +
                "FROM LA_QUERY_DE_PAPEL.Rol " +
                "WHERE Nombre = '" + textBoxNombreRol.Text + "'");
        }
    }
}
