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

        public DatosHotel(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.alta = true;
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
            regimenes.Add(new Regimen(reader.GetString(0), reader.GetInt32(1)));
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
            Validaciones.validarControles(errorProviderHoteles, Controls);
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

        }
    }
}
