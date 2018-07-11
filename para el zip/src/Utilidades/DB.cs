using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using System.Windows.Forms;

namespace FrbaHotel.Utilidades
{
    class DB
    {
        public static SqlConnection conexionDB = new SqlConnection("Data Source=LOCALHOST\\SQLSERVER2012;Initial Catalog=GD1C2018;User ID=gdHotel2018; Password=gd2018");

        private static SqlCommand nuevoComando(string query, params object[] args)
        {
            SqlCommand comando = new SqlCommand(query, conexionDB);

            for (int i = 0; i < args.Length; i += 2)
            {
                comando.Parameters.AddWithValue("@" + args[i].ToString(), args[i + 1]);
            }

            return comando;
        }

        private static string queryFuncion(string prefijo, string nombre, params object[] args)
        {
            string query = prefijo + nombre + "(";

            for (int i = 0; i < args.Length; i += 2)
            {
                query += (i == 0 ? "" : ",") + "@" + (string)args[i];
            }

            return query += ")";
        }

        public static object ejecutarFuncion(string nombre, params object[] args)
        {
            string query = queryFuncion("SELECT ", nombre, args);

            return ejecutarQueryEscalar(query, args);
        }

        public static DataTable ejecutarFuncionDeTabla(string nombre, params object[] args)
        {
            string query = queryFuncion("SELECT * FROM ", nombre, args);

            return ejecutarQueryDeTabla(query, args);
        }

        public static void ejecutarProcedimiento(string nombre, params object[] args)
        {
            SqlCommand comando = nuevoComando(nombre, args);

            comando.CommandType = CommandType.StoredProcedure;

            ejecutarComandoProcedimiento(comando); 
        }

        public static object ejecutarProcedimientoEscalar(string nombre, string nombreOutput, params object[] args)
        {
            SqlCommand comando = nuevoComando(nombre, args);

            comando.Parameters.Add("@" + nombreOutput, SqlDbType.Int).Direction = ParameterDirection.Output;

            comando.CommandType = CommandType.StoredProcedure;

            object output = null;

            try
            {
                conexionDB.Open();
                comando.ExecuteNonQuery();
                output = comando.Parameters["@" + nombreOutput].Value;
            }
            catch (SqlException ex)
            {
                conexionDB.Close();
                MessageBox.Show(ex.Message);
                throw ex;
            }

            conexionDB.Close();
            return output;
        }

        public static void ejecutarComandoProcedimiento(SqlCommand comando)
        {
            try
            {
                conexionDB.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                conexionDB.Close();
                MessageBox.Show(ex.Message);
                throw ex;
            }

            conexionDB.Close();
        }

        public static void ejecutarReader(string query, Action<SqlDataReader> usarReader, params object[] args)
        {
            SqlCommand comando = nuevoComando(query, args);

            comando.CommandType = CommandType.Text;

            conexionDB.Open();
            SqlDataReader reader = comando.ExecuteReader();

            usarReader(reader);

            conexionDB.Close();
        }

        public static int ejecutarQuery(string query, params object[] args)
        {
            SqlCommand comando = nuevoComando(query, args);
            int filasAfectadas = 0;
            try
            {
                conexionDB.Open();
                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                conexionDB.Close();
                MessageBox.Show(ex.Message);
                throw;
            }

            conexionDB.Close();
            return filasAfectadas;
        }

        public static Object ejecutarQueryEscalar(string query, params object[] args)
        {
            SqlCommand comando = nuevoComando(query, args);
            Object retorno = null;
            try
            {
                conexionDB.Open();
                retorno = comando.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                conexionDB.Close();
                MessageBox.Show(ex.Message);
                throw;
            }

            conexionDB.Close();
            return retorno;
        }

        public static DataTable ejecutarQueryDeTabla(string query, params object[] args)
        {
            SqlCommand comando = nuevoComando(query, args);
            DataTable tabla = new DataTable();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    conexionDB.Open();
                    adapter.Fill(tabla);
                }
            }
            catch (SqlException ex)
            {
                conexionDB.Close();
                MessageBox.Show(ex.Message);
                throw;
            }

            conexionDB.Close();
            return tabla;
        }

        public static int buscarIdRol(string nombre)
        {
            return (int)DB.ejecutarQueryEscalar(
                "SELECT Id_Rol " +
                "FROM LA_QUERY_DE_PAPEL.Rol " +
                "WHERE Nombre = @nombre", "nombre", nombre);
        }

        public static int buscarIdUsuario(string username)
        {
            return (int)DB.ejecutarQueryEscalar(
                "SELECT Id_Usuario " +
                "FROM LA_QUERY_DE_PAPEL.Usuario " +
                "WHERE Username = @username", "username", username);
        }

        public static int buscarIdRegimen(string descripcion)
        {
            return (int)DB.ejecutarQueryEscalar(
                "SELECT Id_Regimen " +
                "FROM LA_QUERY_DE_PAPEL.Regimen " +
                "WHERE Descripcion = @descripcion", "descripcion", descripcion);
        }
    }
}
