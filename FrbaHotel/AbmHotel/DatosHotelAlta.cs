using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    class DatosHotelAlta : DatosHotel
    {
        private Usuario usuario;

        public DatosHotelAlta(Usuario usuario) : base()
        {
            this.usuario = usuario;
        }

        protected override void accionAceptar()
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
    }
}
