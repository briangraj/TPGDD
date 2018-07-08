using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Utilidades;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.AbmHotel
{
    class DatosHotelModif : DatosHotel
    {
        private int idHotelAModif;

        public DatosHotelModif(DataGridViewRow filaHotel)
            : base()
        {
            cargarHotel(filaHotel);
        }

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
