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
        private bool alta;
        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
        private int idRolModif;

        public DatosRol()
        {
            InitializeComponent();
            alta = true;
            cargarFuncionalidades();
            checkBoxHabilitado.Checked = true;
        }

        public DatosRol(String nombre)
        {
            InitializeComponent();
            alta = false;
            textBoxNombreRol.Text = nombre;
            idRolModif = DB.buscarIdRol(textBoxNombreRol.Text);
            cargarFuncionalidades();
            cargarRol();
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

            if (alta)
                atenderAlta();
            else
                atenderModificacion();
        }

        private void validarDatos()
        {
            Validaciones.textBoxsVacios(errorProviderDatos, Controls);
            if (checkedListBoxFuncionalidades.CheckedItems.Count == 0)
                errorProviderDatos.SetError(checkedListBoxFuncionalidades, "Debe elegir al menos una funcionalidad");
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.LimpiarTextBox(Controls);
            Limpiador.LimpiarCheckBox(Controls);
            Limpiador.LimpiarCheckBoxList(checkedListBoxFuncionalidades);
        }

        /////////////////////ALTA///////////////////////////
        private void atenderAlta()
        {
            insertarRol();

            insertarFuncionalidadxRol();

            MessageBox.Show("Se creo el rol");
        }

        private int insertarRol()
        {
            return DB.correrQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.Rol (Nombre, Habilitado) " +
                    "VALUES (@nombre, @habilitado)",
                    "nombre", textBoxNombreRol.Text, "habilitado", checkBoxHabilitado.Checked);
        }

        private void insertarFuncionalidadxRol()
        {
            int idRol = DB.buscarIdRol(textBoxNombreRol.Text);
            string id;

            foreach(string desc in checkedListBoxFuncionalidades.CheckedItems)
            {
                id = funcionalidades.Find(funcionalidad => funcionalidad.descripcion == desc).id;

                DB.correrQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.FuncionalidadxRol (Id_Rol, Id_Funcion) " +
                    "VALUES (@idRol, @idFuncion)",
                    "idRol", idRol, "idFuncion", Convert.ToInt32(id));
            }
        }

        /////////////////////MODIFICACION///////////////////////////
        private void atenderModificacion()
        {
            //actualizo rol
            DB.correrQuery(
                "UPDATE LA_QUERY_DE_PAPEL.Rol " +
                "SET Nombre = @nombre, " +
                    "Habilitado = @habilitado " +
                "WHERE Id_Rol = @idRol",
                "nombre", textBoxNombreRol.Text, "habilitado", checkBoxHabilitado.Checked, "idRol", idRolModif);

            //borro funcionalidades anteriores
            DB.correrQuery(
                "DELETE FROM LA_QUERY_DE_PAPEL.FuncionalidadxRol " +
                "WHERE Id_Rol = @idRol",
                "idRol", idRolModif);

            insertarFuncionalidadxRol();

            MessageBox.Show("Se modifico el rol");
        }

        private void cargarRol()
        {
            checkBoxHabilitado.Checked = (bool)DB.correrQueryEscalar(
                "SELECT Habilitado " +
                "FROM LA_QUERY_DE_PAPEL.Rol " +
                    "WHERE Nombre = @nombre",
                "nombre", textBoxNombreRol.Text);

            DB.ejecutarReader(
                "SELECT Id_Funcion " +
                "FROM LA_QUERY_DE_PAPEL.FuncionalidadxRol " +
                    "WHERE Id_Rol = @idRol", cargarFuncionalidad, "idRol", idRolModif);
        }

        public void cargarFuncionalidad(SqlDataReader reader)
        {
            string descripcion = funcionalidades.Find(funcionalidad => funcionalidad.id == reader.GetInt32(0).ToString()).descripcion;

            int indice = checkedListBoxFuncionalidades.Items.IndexOf(descripcion);

            checkedListBoxFuncionalidades.SetItemChecked(indice, true);
        }
    }
}
