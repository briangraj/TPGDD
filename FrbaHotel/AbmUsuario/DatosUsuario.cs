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
using System.Data.SqlClient;
using FrbaHotel.Utilidades;

namespace FrbaHotel.AbmUsuario
{
    public partial class DatosUsuario : Form
    {
        private Usuario usuario;
        private bool alta;
        private List<Hotel> hoteles = new List<Hotel>();

        public DatosUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            alta = true;
            cargarHoteles();
            cargarRoles();
        }

        private void cargarHoteles()
        {
            DB.ejecutarReader(
                "SELECT Nombre, Id_Hotel " +
                "FROM LA_QUERY_DE_PAPEL.Hotel",
            cargarCheckBoxs);
        }

        public void cargarCheckBoxs(SqlDataReader reader)
        {
            hoteles.Add(new Hotel(reader.GetString(0), reader.GetInt32(1).ToString()));
            checkedListBoxHoteles.Items.Add(reader.GetString(0));
        }

        private void cargarRoles()
        {
            DB.ejecutarReader(
                "SELECT Nombre " +
                "FROM LA_QUERY_DE_PAPEL.Rol", 
            cargarComboBox);
        }

        public void cargarComboBox(SqlDataReader reader)
        {
            comboBoxRoles.Items.Add(reader.GetString(0));
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            errorProviderDatosUsuario.Clear();
            validarDatos();
            if (Validaciones.errorProviderConError(errorProviderDatosUsuario, Controls))
                return;

            if (alta)
                atenderAlta();
            else
                atenderModificacion();
        }

        private void validarDatos()
        {
            Validaciones.textBoxsVacios(errorProviderDatosUsuario, Controls);
            /*if (checkedListBoxHoteles.CheckedItems.Count == 0)
                errorProviderDatosUsuario.SetError(checkedListBoxHoteles, "Debe elegir al menos un hotel");
             */
        }

        /////////////////////ALTA///////////////////////////
        private void atenderAlta()
        {
            insertarUsuario();

            insertUsuarioxHotel();

            MessageBox.Show("Se creo el usuario");
        }

        private void insertarUsuario()
        {
            int idRol = DB.buscarIdRol(comboBoxRoles.SelectedItem.ToString());
            DB.correrQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.usuarios (Username, Password , Id_Rol, Nombre, Apellido, Tipo_Documento, Nro_Documento, Mail, Telefono, Direccion, Fecha_Nacimiento) " +
                    "VALUES ('@username', '@password', @idRol, '@nombre', '@apellido', '@tipoDocumento', @nroDocumento, '@mail', '@telefono', '@direccion', @fechaNacimiento)",
                    "username", textBoxUsername.Text, "password", Usuario.encriptar(textBoxPassword.Text), "idRol", idRol,
                    "nombre", textBoxNombre.Text, "apellido", textBoxApellido.Text, "tipoDocumento", textBoxTipoDocumento.Text, "nroDocumento", textBoxNroDocumento.Text,
                    "mail", textBoxMail.Text, "telefono", textBoxTelefono.Text, "direccion", textBoxDireccion.Text, "fechaNacimiento", dateTimePickerFechaNac.Value);
        }

        private void insertUsuarioxHotel()
        {
            int idUsuario = DB.buscarIdUsuario(textBoxUsername.Text);
            string id;

            foreach (string desc in checkedListBoxHoteles.CheckedItems)
            {
                id = hoteles.Find(hotel => hotel.nombre == desc).id;

                DB.correrQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.UsuarioxHotel (Id_Hotel, Id_Usuario) " +
                    "VALUES (@idHotel, @idUsuario)",
                    "idHotel", id, "idUsuario", idUsuario);
            }
        }

        /////////////////////MODIFICACION///////////////////////////
        private void atenderModificacion()
        {

        }
    }
}
