using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Login;

using FrbaHotel.Utilidades;
using System.Data.SqlClient;
using System.Configuration;

namespace FrbaHotel
{
    static class Program
    {
        public static DateTime fechaActual = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["Fecha"]);
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DB.conexionDB = new SqlConnection(ConfigurationManager.ConnectionStrings["FrbaHotel.Properties.Settings.GD1C2018ConnectionString"].ConnectionString);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Inicio());
        }
    }
}
