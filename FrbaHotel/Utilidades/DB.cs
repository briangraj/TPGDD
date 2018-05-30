using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FrbaHotel.Utilidades
{
    class DB
    {
        public static SqlConnection conexionDB = new SqlConnection("Data Source=LOCALHOST\\SQLSERVER2012;Initial Catalog=GD1C2018;User ID=gdHotel2018; Password=gd2018");

        public static void ejecutarProcedimiento(String nombre, params object[] args)
        {
            SqlCommand comando = nuevoComando(nombre, args);

            comando.CommandType = CommandType.StoredProcedure;

            ejecutarProcedimiento(comando);
        }

        private static SqlCommand nuevoComando(String query, params object[] args)
        {
            SqlCommand comando = new SqlCommand(query, conexionDB);

            for (int i = 0; i < args.Length; i += 2)
            {
                comando.Parameters.AddWithValue("@" + args[i].ToString(), args[i + 1]);
            }

            return comando;
        }

        public static void ejecutarProcedimiento(SqlCommand comando)
        {
            try
            {
                conexionDB.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                conexionDB.Close();
                throw ex;
            }

            conexionDB.Close();
        }
    }
}
