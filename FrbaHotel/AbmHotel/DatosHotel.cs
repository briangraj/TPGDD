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
using FrbaHotel.Entidades;
using System.Data.SqlClient;

namespace FrbaHotel.AbmHotel
{
    public partial class DatosHotel : Form
    {
        private List<Regimen> regimenes = new List<Regimen>();
        private bool alta;

        public DatosHotel()
        {
            InitializeComponent();
            cargarRegimenes();
        }

        private void cargarRegimenes()
        {
            DB.ejecutarReader(
                "SELECT Descripcion, Id_Regimen " +
                "FROM LA_QUERY_DE_PAPEL.Regimen",
            cargarCheckBoxs);
        }

        public void cargarCheckBoxs(SqlDataReader reader)
        {
            regimenes.Add(new Regimen(reader.GetString(0), reader.GetInt32(1).ToString()));
            checkedListBoxRegimenes.Items.Add(reader.GetString(0));
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            errorProviderHoteles.Clear();
            validarDatos();
            if (Validaciones.errorProviderConError(errorProviderHoteles, Controls))
                return;

            if (alta)
                atenderAlta();
            else
                atenderModificacion();
        }

        private void validarDatos()
        {
            Validaciones.textBoxsVacios(errorProviderHoteles, Controls);
            if (checkedListBoxRegimenes.CheckedItems.Count == 0)
                errorProviderHoteles.SetError(checkedListBoxRegimenes, "Debe elegir al menos un regimen");
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.LimpiarTextBox(Controls);
            Limpiador.LimpiarCheckBoxList(checkedListBoxRegimenes);
        }
        
        /////////////////////ALTA///////////////////////////
        private void atenderAlta()
        {
            insertarHotel();
        }

        private void insertarHotel()
        {
            DB.correrQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.Hotel (Nombre, Mail,	Telefono, Direccion, Cant_Estrellas, Ciudad, Pais, Fecha_Creacion) " +
                    "VALUES (@nombre, @mail, @telefono, @direccion, @cantEstrellas, @ciudad, @pais, @fechaCreacion)",
                    "nombre", textBoxNombre.Text, "mail", textBoxMail.Text, "telefono", textBoxTelefono.Text, "direccion", textBoxDireccion.Text,
                    "cantEstrellas", textBoxCantEstrellas.Text, "ciudad", textBoxCiudad.Text, "pais", textBoxPais.Text, "fechaCreacion", dateTimePickerFechaCreacion.Value);
        }

        /////////////////////MODIFICACION///////////////////////////
        private void atenderModificacion()
        {

        }
    }
}
