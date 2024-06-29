using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class MarcaNegocio
    {

        private AccesoDatos datos = new AccesoDatos();

        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();

            try
            {
                datos.setQuery("SELECT Id, Descripcion FROM MARCAS;");
                datos.executeReader();

                while(datos.Reader.Read())
                {
                    Marca marcaAux = new Marca();

                    marcaAux.Id =(int)datos.Reader["Id"];
                    marcaAux.Descripcion = (string)datos.Reader["Descripcion"];

                    lista.Add(marcaAux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.closeConexion();
            }
        }

        public void agregar(Marca marca)
        {
            try
            {
                datos.setQuery("INSERT INTO MARCAS (Descripcion) VALUES (@marca);");
                datos.setParameter("@marca", marca.Descripcion);
                datos.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            { 
                datos.closeConexion(); 
            }
        }

        public void eliminar(Marca marca)
        {
            try
            {
                datos.setQuery("DELETE FROM MARCAS WHERE Id = @id;");
                datos.setParameter("@id", marca.Id);
                datos.executeAction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.closeConexion();
            }
        }

    }
}
