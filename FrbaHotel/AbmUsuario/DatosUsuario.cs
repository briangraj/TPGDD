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
        private bool alta;
        private List<Hotel> hoteles = new List<Hotel>();
        private int idUsuarioAModificar;

        public DatosUsuario()
        {
            InitializeComponent();
            alta = true;
            cargarHoteles();
            cargarRoles();
        }

        public DatosUsuario(DataGridViewRow filaSeleccionada)
        {
            InitializeComponent();
            alta = false;
            cargarHoteles();
            cargarRoles();
            cargarUsuario(filaSeleccionada);
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
            if (checkedListBoxHoteles.CheckedItems.Count == 0)
                errorProviderDatosUsuario.SetError(checkedListBoxHoteles, "Debe elegir al menos un hotel");
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
                    "INSERT INTO LA_QUERY_DE_PAPEL.usuarios (Username, Password , Id_Rol, Nombre, Apellido, Tipo_Documento, Nro_Documento, Mail, Telefono, Direccion, Fecha_Nacimiento, Habilitado) " +
                    "VALUES (@username, @password, @idRol, @nombre, @apellido, @tipoDocumento, @nroDocumento, @mail, @telefono, @direccion, @fechaNacimiento, @habilitado)",
                    "username", textBoxUsername.Text, "password", Usuario.encriptar(textBoxPassword.Text), "idRol", idRol,
                    "nombre", textBoxNombre.Text, "apellido", textBoxApellido.Text, "tipoDocumento", textBoxTipoDocumento.Text, "nroDocumento", textBoxNroDocumento.Text,
                    "mail", textBoxMail.Text, "telefono", textBoxTelefono.Text, "direccion", textBoxDireccion.Text, "fechaNacimiento", dateTimePickerFechaNac.Value,
                    "habilitado", checkBoxHabilitado.Checked);
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
            int idRol = DB.buscarIdRol(comboBoxRoles.SelectedItem.ToString());
            
            DB.correrQuery(
                "UPDATE LA_QUERY_DE_PAPEL.usuarios " +
                "SET Username = @username, Password = @password, Id_Rol = @idRol, Nombre = @nombre, Apellido = @apellido, Tipo_Documento = @tipoDoc, " +
                "Nro_Documento = @nroDoc, Mail = @mail, Telefono = @telefono, Direccion = @direccion, Fecha_Nacimiento = @fechaNac, Habilitado = @habilitado " +
                "WHERE Id_Usuario = @idUsuario",
                "username", textBoxUsername.Text, "password", Usuario.encriptar(textBoxPassword.Text), "idRol", idRol,
                "nombre", textBoxNombre.Text, "apellido", textBoxApellido.Text, "tipoDoc", textBoxTipoDocumento.Text, "nroDoc", textBoxNroDocumento.Text,
                "mail", textBoxMail.Text, "telefono", textBoxTelefono.Text, "direccion", textBoxDireccion.Text, "fechaNac", dateTimePickerFechaNac.Value,
                "habilitado", checkBoxHabilitado.Checked, "idUsuario", idUsuarioAModificar);

            DB.correrQuery(
                "DELETE FROM LA_QUERY_DE_PAPEL.UsuarioxHotel " +
                "WHERE Id_Usuario = @idUsuario",
                "idUsuario", idUsuarioAModificar);

            insertUsuarioxHotel();

            MessageBox.Show("Se modifico el rol");
        }

        private void cargarUsuario(DataGridViewRow filaSeleccionada)
        {
            textBoxUsername.Text = filaSeleccionada.Cells["Username"].Value.ToString();
            textBoxNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
            textBoxApellido.Text = filaSeleccionada.Cells["Apellido"].Value.ToString();
            textBoxTipoDocumento.Text = filaSeleccionada.Cells["Tipo_Documento"].Value.ToString();
            textBoxNroDocumento.Text = filaSeleccionada.Cells["Nro_Documento"].Value.ToString();
            textBoxMail.Text = filaSeleccionada.Cells["Mail"].Value.ToString();
            textBoxTelefono.Text = filaSeleccionada.Cells["Telefono"].Value.ToString();
            textBoxDireccion.Text = filaSeleccionada.Cells["Direccion"].Value.ToString();
            dateTimePickerFechaNac.Value = Convert.ToDateTime(filaSeleccionada.Cells["Fecha_Nacimiento"].Value.ToString());
            checkBoxHabilitado.Checked = (bool)filaSeleccionada.Cells["Habilitado"].Value;
            idUsuarioAModificar = (int)filaSeleccionada.Cells["Id_Usuario"].Value;

            cargarHotelesDondeTrabaja();
        }

        private void cargarHotelesDondeTrabaja()
        {
            DB.ejecutarReader(
                "SELECT Id_Hotel " +
                "FROM LA_QUERY_DE_PAPEL.UsuarioxHotel " +
                    "WHERE Id_Usuario = @idUsuario",
                cargarHotel, "idUsuario", idUsuarioAModificar);
        }

        public void cargarHotel(SqlDataReader reader)
        {
            string nombre = hoteles.Find(hotel => hotel.id == reader.GetInt32(0).ToString()).nombre;

            int indice = checkedListBoxHoteles.Items.IndexOf(nombre);

            checkedListBoxHoteles.SetItemChecked(indice, true);
        }
    }
}
