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

namespace FrbaHotel.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProviderEstadisticas.Clear();
                validarDatos();
                if (Validaciones.errorProviderConError(errorProviderEstadisticas, Controls))
                    return;

                switch(comboBoxListado.SelectedIndex){
                    case 0:
                        dataGridViewEstadistica.DataSource = DB.ejecutarFuncionDeTabla("LA_QUERY_DE_PAPEL.HotelesMayoresCancelaciones", "anio", Convert.ToInt32(textBoxAnio.Text), "Trimestre", Convert.ToInt32(comboBoxTrimestre.SelectedItem));
                        break;
                    case 1:
                        dataGridViewEstadistica.DataSource = DB.ejecutarFuncionDeTabla("LA_QUERY_DE_PAPEL.HotelesMayoresConsumibles", "anio", Convert.ToInt32(textBoxAnio.Text), "Trimestre", Convert.ToInt32(comboBoxTrimestre.SelectedItem));
                        break;
                    case 2:
                        dataGridViewEstadistica.DataSource = DB.ejecutarFuncionDeTabla("LA_QUERY_DE_PAPEL.HotelesMasDiasFueraDeServicio", "anio", Convert.ToInt32(textBoxAnio.Text), "Trimestre", Convert.ToInt32(comboBoxTrimestre.SelectedItem));
                        break;
                    case 3:
                        dataGridViewEstadistica.DataSource = DB.ejecutarFuncionDeTabla("LA_QUERY_DE_PAPEL.habitacionesMasOcupadas", "anio", Convert.ToInt32(textBoxAnio.Text), "Trimestre", Convert.ToInt32(comboBoxTrimestre.SelectedItem));
                        break;
                    case 4:
                        dataGridViewEstadistica.DataSource = DB.ejecutarFuncionDeTabla("LA_QUERY_DE_PAPEL.ClientesConMasPuntos", "anio", Convert.ToInt32(textBoxAnio.Text), "Trimestre", Convert.ToInt32(comboBoxTrimestre.SelectedItem));
                        break;
                }
            }
            catch (SqlException) { }
        }

        private void validarDatos()
        {
            Validaciones.validarControles(errorProviderEstadisticas, Controls);
        }
    }
}
