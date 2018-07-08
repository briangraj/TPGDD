using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Entidades;
using FrbaHotel.Utilidades;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.AbmHotel
{
    class DatosHotelModif : DatosHotel
    {
        private int idHotelAModif;
        private List<Regimen> regimenesOriginales;

        public DatosHotelModif(DataGridViewRow filaHotel)
            : base()
        {
            cargarHotel(filaHotel);
        }

        protected override void accionAceptar()
        {
            recorrerRegimenesOriginales(validarRegimen);

            recorrerRegimenesOriginales(borrarRegimen);

            insertarNuevosRegimenes();

            DB.correrQuery(
                "UPDATE LA_QUERY_DE_PAPEL.Hotel " +
                "SET Nombre = @nombre, Mail = @mail, Telefono = @telefono, Direccion = @direccion, Cant_Estrellas = @cantEstrellas, Recarga_Estrella = @recarga, Ciudad = @ciudad, " +
                "Pais = @pais, Fecha_Creacion = @fechaCreacion " +
                    "WHERE Id_Hotel = @idHotel",
                "nombre", textBoxNombre.Text, "mail", textBoxMail.Text, "telefono", textBoxTelefono.Text, "direccion", textBoxDireccion.Text,
                "cantEstrellas", Convert.ToInt32(comboBoxCantEstrellas.SelectedItem), "recarga", Convert.ToInt32(textBoxRecarga.Text), "ciudad", textBoxCiudad.Text,
                "pais", textBoxPais.Text, "fechaCreacion", dateTimePickerFechaCreacion.Value, "idHotel", idHotelAModif);

            MessageBox.Show("Se modifico el hotel");
        }

        private void recorrerRegimenesOriginales(Action<Regimen> accion)
        {
            foreach (Regimen regimen in regimenesOriginales)
            {
                if (!estaCheckeado(regimen))
                    accion(regimen);
            }
        }

        private bool estaCheckeado(Regimen regimen)
        {
            int indiceRegimen = checkedListBoxRegimenes.Items.IndexOf(regimen.descripcion);
            return checkedListBoxRegimenes.GetItemChecked(indiceRegimen);
        }

        private void validarRegimen(Regimen regimen)
        {
            DB.ejecutarProcedimiento("LA_QUERY_DE_PAPEL.validar_regimen", "idHotel", idHotelAModif, "idRegimen", regimen.id, "fechaActual", Program.fechaActual);
        }

        private void borrarRegimen(Regimen regimen)
        {
            DB.correrQuery(
                "DELETE FROM LA_QUERY_DE_PAPEL.RegimenxHotel " +
                "WHERE Id_Hotel = @idHotel " +
                    "AND Id_Regimen = @idRegimen",
                "idHotel", idHotelAModif, "idRegimen", regimen.id);
        }

        private void insertarNuevosRegimenes()
        {
            foreach (Regimen regimen in regimenes)
            {
                if (estaCheckeado(regimen) && !regimenesOriginales.Contains(regimen))
                    insertarRegimen(idHotelAModif, regimen.id);
            }
        }

        private void cargarHotel(DataGridViewRow filaHotel)
        {
            textBoxNombre.Text = filaHotel.Cells["Nombre"].Value.ToString();
            textBoxMail.Text = filaHotel.Cells["Mail"].Value.ToString();
            textBoxTelefono.Text = filaHotel.Cells["Telefono"].Value.ToString();
            textBoxDireccion.Text = filaHotel.Cells["Direccion"].Value.ToString();
            comboBoxCantEstrellas.SelectedIndex = Convert.ToInt32(filaHotel.Cells["Cant_Estrellas"].Value) - 1;
            textBoxRecarga.Text = filaHotel.Cells["Recarga_Estrella"].Value.ToString();
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
            Regimen regimenOriginal = regimenes.Find(regimen => regimen.id == reader.GetInt32(0));

            regimenesOriginales.Add(regimenOriginal);

            int indice = checkedListBoxRegimenes.Items.IndexOf(regimenOriginal.descripcion);

            checkedListBoxRegimenes.SetItemChecked(indice, true);
        }
    }
}
