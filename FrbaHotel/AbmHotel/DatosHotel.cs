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
        private Usuario usuario;
        private int idHotelAModif;

        public DatosHotel(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.alta = true;
            cargarRegimenes();
        }

        public DatosHotel(DataGridViewRow filaHotel)
        {
            InitializeComponent();
            this.alta = false;
            cargarRegimenes();
            cargarHotel(filaHotel);
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
            regimenes.Add(new Regimen(reader.GetString(0), reader.GetInt32(1)));
            checkedListBoxRegimenes.Items.Add(reader.GetString(0));
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
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
            catch (SqlException) { }
        }

        private void validarDatos()
        {
            Validaciones.validarControles(errorProviderHoteles, Controls);
            Validaciones.validarFechasPosteriores(errorProviderHoteles, Controls);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.limpiarControles(Controls);
        }
        
        /////////////////////ALTA///////////////////////////
        private void atenderAlta()
        {
            int idHotel = insertarHotel();

            insertarUsuarioxHotel(idHotel);

            insertarRegimenxHotel(idHotel);

            MessageBox.Show("Se creo el hotel");
        }

        private int insertarHotel()
        {
            return (int)DB.correrQueryEscalar(
                "INSERT INTO LA_QUERY_DE_PAPEL.Hotel (Nombre, Mail,	Telefono, Direccion, Cant_Estrellas, Ciudad, Pais, Fecha_Creacion) output INSERTED.Id_Hotel " +
                "VALUES (@nombre, @mail, @telefono, @direccion, @cantEstrellas, @ciudad, @pais, @fechaCreacion)",
                "nombre", textBoxNombre.Text, "mail", textBoxMail.Text, "telefono", textBoxTelefono.Text, "direccion", textBoxDireccion.Text,
                "cantEstrellas", Convert.ToInt32(comboBoxCantEstrellas.SelectedItem), "ciudad", textBoxCiudad.Text, "pais", textBoxPais.Text, "fechaCreacion", dateTimePickerFechaCreacion.Value);
        }

        private void insertarUsuarioxHotel(int idHotel)
        {
            DB.correrQuery(
                "INSERT INTO LA_QUERY_DE_PAPEL.UsuarioxHotel (Id_Hotel, Id_Usuario) " +
                "VALUES (@idHotel, @idUsuario)",
                "idHotel", idHotel, "idUsuario", Convert.ToInt32(usuario.id));
        }

        private void insertarRegimenxHotel(int idHotel)
        {
            int id;

            foreach (string desc in checkedListBoxRegimenes.CheckedItems)
            {
                id = regimenes.Find(regimen => regimen.descripcion == desc).id;

                DB.correrQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.RegimenxHotel (Id_Hotel, Id_Regimen) " +
                    "VALUES (@idHotel, @idRegimen)",
                    "idHotel", idHotel, "idRegimen", id);
            }
        }

        /////////////////////MODIFICACION///////////////////////////
        private void atenderModificacion()
        {
            //todo checkear que no tenga reservas con este regimen
            DB.correrQuery(
                "DELETE FROM LA_QUERY_DE_PAPEL.RegimenxHotel " +
                "WHERE Id_Hotel = @idHotel",
                "idHotel", idHotelAModif);

            DB.correrQuery(
                "UPDATE LA_QUERY_DE_PAPEL.Hotel " +
                "SET Nombre = @nombre, Mail = @mail, Telefono = @telefono, Direccion = @direccion, Cant_Estrellas = @cantEstrellas, Ciudad = @ciudad, " +
                "Pais = @pais, Fecha_Creacion = @fechaCreacion " +
                "WHERE Id_Hotel = @idHotel",
                "nombre", textBoxNombre.Text, "mail", textBoxMail.Text, "telefono", textBoxTelefono.Text, "direccion", textBoxDireccion.Text,
                "cantEstrellas", Convert.ToInt32(comboBoxCantEstrellas.SelectedItem), "ciudad", textBoxCiudad.Text, "pais", textBoxPais.Text,
                "fechaCreacion", dateTimePickerFechaCreacion.Value, "idHotel", idHotelAModif);

            insertarRegimenxHotel(idHotelAModif);

            MessageBox.Show("Se modifico el hotel");
        }

        private void cargarHotel(DataGridViewRow filaHotel)
        {
            textBoxNombre.Text = filaHotel.Cells["Nombre"].Value.ToString();
            textBoxMail.Text = filaHotel.Cells["Mail"].Value.ToString();
            textBoxTelefono.Text = filaHotel.Cells["Telefono"].Value.ToString();
            textBoxDireccion.Text = filaHotel.Cells["Direccion"].Value.ToString();
            comboBoxCantEstrellas.SelectedIndex = Convert.ToInt32(filaHotel.Cells["Cant_Estrellas"].Value) - 1;
            textBoxCiudad.Text = filaHotel.Cells["Ciudad"].Value.ToString();
            textBoxPais.Text = filaHotel.Cells["Pais"].Value.ToString();
            dateTimePickerFechaCreacion.Value = Convert.ToDateTime(filaHotel.Cells["Fecha_Creacion"].Value);

            idHotelAModif = Convert.ToInt32(filaHotel.Cells["Id_Hotel"].Value);

            cargarRegimenesDeHotel();
        }

        private void cargarRegimenesDeHotel()
        {
            DB.ejecutarReader(
                "SELECT Id_Regimen " +
                "FROM LA_QUERY_DE_PAPEL.RegimenxHotel " +
                    "WHERE Id_Hotel = @idHotel",
                cargarHotel, "idHotel", idHotelAModif);
        }

        public void cargarHotel(SqlDataReader reader)
        {
            string descripcion = regimenes.Find(regimen => regimen.id == reader.GetInt32(0)).descripcion;

            int indice = checkedListBoxRegimenes.Items.IndexOf(descripcion);

            checkedListBoxRegimenes.SetItemChecked(indice, true);
        }
    }
}
