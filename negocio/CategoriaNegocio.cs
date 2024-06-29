using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriaNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                datos.setQuery("SELECT Id, Descripcion FROM CATEGORIAS;");
                datos.executeReader();

                while (datos.Reader.Read())
                {
                    Categoria categoriaAux = new Categoria();

                    categoriaAux.Id = (int)datos.Reader["Id"];
                    categoriaAux.Descripcion = (string)datos.Reader["Descripcion"];

                    lista.Add(categoriaAux);
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

        public void agregar(Categoria categoria)
        {
            try
            {
                datos.setQuery("INSERT INTO CATEGORIAS (Descripcion) VALUES (@categoria)");
                datos.setParameter("@categoria", categoria.Descripcion);
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

        public void eliminar(Categoria categoria)
        {
            try
            {
                datos.setQuery("DELETE FROM CATEGORIAS WHERE Id = @id");
                datos.setParameter("@id", categoria.Id);
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
