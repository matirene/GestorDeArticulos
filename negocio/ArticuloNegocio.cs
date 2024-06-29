using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Articulo> listar()
        {
            List<Articulo> listaArticulos = new List<Articulo>();

            try
            {
                datos.setQuery("SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion AS Marca, M.Id as IdMarca, C.Descripcion AS Categoria, C.Id as IdCategoria, Precio, ImagenUrl FROM ARTICULOS as A INNER JOIN MARCAS as M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS AS C ON A.IdCategoria = C.Id;");
                datos.executeReader();

                while(datos.Reader.Read())
                {
                    Articulo articuloAux = new Articulo();

                    articuloAux.Id = (int)datos.Reader["Id"];
                    articuloAux.Codigo = (string)datos.Reader["Codigo"];
                    articuloAux.Nombre = (string)datos.Reader["Nombre"];
                    articuloAux.Descripcion = (string)datos.Reader["Descripcion"];

                    articuloAux.Marca = new Marca();
                    articuloAux.Marca.Id = (int)datos.Reader["IdMarca"];
                    articuloAux.Marca.Descripcion = (string)datos.Reader["Marca"];

                    articuloAux.Categoria = new Categoria();
                    articuloAux.Categoria.Id = (int)datos.Reader["IdCategoria"];
                    articuloAux.Categoria.Descripcion = (string)datos.Reader["Categoria"];
                    articuloAux.Imagen = (string)datos.Reader["ImagenUrl"];

                    articuloAux.Precio = (decimal)datos.Reader["Precio"];

                    listaArticulos.Add(articuloAux);
                }

                return listaArticulos;
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

        public void agregar(Articulo articulo)
        {

            try
            {
                datos.setQuery("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES (@codigo, @nombre, @descripcion, @marca, @categoria, @imagen, @precio);");
                datos.setParameter("@codigo", articulo.Codigo);
                datos.setParameter("@nombre", articulo.Nombre);
                datos.setParameter("@descripcion", articulo.Descripcion);
                datos.setParameter("@marca", articulo.Marca.Id);
                datos.setParameter("@categoria", articulo.Categoria.Id);
                datos.setParameter("@imagen", articulo.Imagen);
                datos.setParameter("@precio", articulo.Precio);

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

        public void modificar(Articulo articulo)
        {
            try
            {
                datos.setQuery("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @marca, IdCategoria = @categoria, ImagenUrl = @imagen, Precio = @precio WHERE Id = @id;");
                datos.setParameter("@codigo", articulo.Codigo);
                datos.setParameter("@nombre", articulo.Nombre);
                datos.setParameter("@descripcion", articulo.Descripcion);
                datos.setParameter("@marca", articulo.Marca.Id);
                datos.setParameter("@categoria", articulo.Categoria.Id);
                datos.setParameter("@imagen", articulo.Imagen);
                datos.setParameter("@precio", articulo.Precio);
                datos.setParameter("@id", articulo.Id);

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

        public void eliminar(Articulo articulo)
        {
            try
            {
                datos.setQuery("DELETE FROM ARTICULOS WHERE Id = @id;");
                datos.setParameter("@id", articulo.Id);

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

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();

            try
            {
                string query = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion AS Marca, M.Id as IdMarca, C.Descripcion AS Categoria, C.Id as IdCategoria, Precio, ImagenUrl FROM ARTICULOS as A INNER JOIN MARCAS as M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS AS C ON A.IdCategoria = C.Id WHERE ";

                switch (campo)
                {
                    case "Código":

                        switch (criterio)
                        {
                            case "Contiene":
                                query += "Codigo LIKE '%" + filtro + "%'";
                                break;

                            case "Empieza con":
                                query += "Codigo LIKE '" + filtro + "%'";
                                break;

                            case "Termina con":
                                query += "Codigo LIKE '%" + filtro + "'";
                                break;
                        }
                        break;

                    case "Nombre":

                        switch (criterio)
                        {
                            case "Contiene":
                                query += "Nombre LIKE '%" + filtro + "%'";
                                break;

                            case "Empieza con":
                                query += "Nombre LIKE '" + filtro + "%'";
                                break;

                            case "Termina con":
                                query += "Nombre LIKE '%" + filtro + "'";
                                break;
                        }
                        break;

                    case "Marca":

                        switch (criterio)
                        {
                            case "Contiene":
                                query += "M.Descripcion LIKE '%" + filtro + "%'";
                                break;

                            case "Empieza con":
                                query += "M.Descripcion LIKE '" + filtro + "%'";
                                break;

                            case "Termina con":
                                query += "M.Descripcion LIKE '%" + filtro + "'";
                                break;
                        }
                        break;

                    case "Categoria":

                        switch (criterio)
                        {
                            case "Contiene":
                                query += "C.Descripcion LIKE '%" + filtro + "%'";
                                break;

                            case "Empieza con":
                                query += "C.Descripcion LIKE '" + filtro + "%'";
                                break;

                            case "Termina con":
                                query += "C.Descripcion LIKE '%" + filtro + "'";
                                break;
                        }
                        break;

                }

                datos.setQuery(query);
                datos.executeReader();

                while (datos.Reader.Read())
                {
                    Articulo articuloAux =  new Articulo();

                    articuloAux.Id = (int)datos.Reader["Id"];
                    articuloAux.Codigo = (string)datos.Reader["Codigo"];
                    articuloAux.Nombre = (string)datos.Reader["Nombre"];
                    articuloAux.Descripcion = (string)datos.Reader["Descripcion"];

                    articuloAux.Marca = new Marca();
                    articuloAux.Marca.Id = (int)datos.Reader["IdMarca"];
                    articuloAux.Marca.Descripcion = (string)datos.Reader["Marca"];

                    articuloAux.Categoria = new Categoria();
                    articuloAux.Categoria.Id = (int)datos.Reader["IdCategoria"];
                    articuloAux.Categoria.Descripcion = (string)datos.Reader["Categoria"];
                    articuloAux.Imagen = (string)datos.Reader["ImagenUrl"];

                    articuloAux.Precio = (decimal)datos.Reader["Precio"];

                    listaFiltrada.Add(articuloAux);
                }

                return listaFiltrada;
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
