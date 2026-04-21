using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Codigo, A.Nombre, A.Descripcion, A.Precio, " +
                             "M.Descripcion AS DescripcionMarca, " +
                             "C.Descripcion AS DescripcionCategoria, " +
                             "I.ImagenUrl " +
                             "FROM ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I " +
                             "WHERE A.IdMarca = M.Id " +
                             "AND A.IdCategoria = C.Id " +
                             "AND A.Id = I.IdArticulo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = Convert.ToDecimal(datos.Lector["Precio"]); 

                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"]; //fijar
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["DescripcionMarca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["DescripcionCategoria"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
    //asdasd
}
