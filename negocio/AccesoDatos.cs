using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;

        private SqlCommand comando;

        private SqlDataReader reader;

        public SqlDataReader Reader { get { return reader; } }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=MATIAS-PC\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true;");
            comando = new SqlCommand();
        }

        public void setQuery(string query)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
            comando.Connection = conexion;
        }

        public void setParameter(string key, object value) 
        {
            comando.Parameters.AddWithValue(key, value);
        }

        public void executeReader()
        {
            try
            {
                conexion.Open();
                reader = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void executeAction()
        {
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void closeConexion()
        {
            if(reader != null)
                reader.Close();

            conexion.Close();
        }
    }
}
