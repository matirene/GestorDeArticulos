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
                datos.setQuery("SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, Precio, ImagenUrl FROM ARTICULOS as A INNER JOIN MARCAS as M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS AS C ON A.IdCategoria = C.Id\r\n");
                datos.executeReader();

                while(datos.Reader.Read())
                {
                    Articulo articuloAux = new Articulo();

                    articuloAux.Id = (int)datos.Reader["Id"];
                    articuloAux.Codigo = (string)datos.Reader["Codigo"];
                    articuloAux.Nombre = (string)datos.Reader["Nombre"];
                    articuloAux.Descripcion = (string)datos.Reader["Descripcion"];
                    articuloAux.Marca = new Marca();
                    articuloAux.Marca.Descripcion = (string)datos.Reader["Marca"];
                    articuloAux.Categoria = new Categoria();
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
    }
}
