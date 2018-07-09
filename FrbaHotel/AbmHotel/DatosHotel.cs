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
    public abstract partial class DatosHotel : Form
    {
        protected List<Regimen> regimenes = new List<Regimen>();

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

                accionAceptar();
            }
            catch (SqlException) { }
        }

        protected abstract void accionAceptar();

        private void validarDatos()
        {
            Validaciones.validarControles(errorProviderHoteles, Controls);
            Validaciones.validarFechasPosteriores(errorProviderHoteles, Controls);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.limpiarControles(Controls);
        }

        protected void insertarRegimenxHotel(int idHotel)
        {
            int id;

            foreach (string desc in checkedListBoxRegimenes.CheckedItems)
            {
                id = regimenes.Find(regimen => regimen.descripcion == desc).id;

                insertarRegimen(idHotel, id);
            }
        }

        protected void insertarRegimen(int idHotel, int idRegimen)
        {
            DB.ejecutarQuery(
                    "INSERT INTO LA_QUERY_DE_PAPEL.RegimenxHotel (Id_Hotel, Id_Regimen) " +
                    "VALUES (@idHotel, @idRegimen)",
                    "idHotel", idHotel, "idRegimen", idRegimen);
        }
    }
}
