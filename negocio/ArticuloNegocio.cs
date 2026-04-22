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
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, " +
                             "M.Descripcion AS DescripcionMarca, " +
                             "C.Descripcion AS DescripcionCategoria, " +"M.Id AS IdMarca, C.Id AS IdCategoria "+
                             "FROM ARTICULOS A, MARCAS M, CATEGORIAS C " +
                             "WHERE A.IdMarca = M.Id " +
                             "AND A.IdCategoria = C.Id ");

                //Nota: Arregle la consulta para que no aparezcan repetidos los que tengan mas de una imagen pero los que tienen
                //categoria inexistente no aparecen, falta arreglar eso
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = Convert.ToDecimal(datos.Lector["Precio"]); 

                    //aux.ImagenUrl = (string)datos.Lector["ImagenUrl"]; //fijar
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["DescripcionMarca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
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

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) " + "output inserted.id "+"values('" + nuevo.Codigo + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', @idMarca, @idCategoria, @Precio)");
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@Precio", nuevo.Precio);
                int idArticulo = datos.leerUltimoId();
                foreach(Imagen img in nuevo.Imagenes)
                {
                    datos.limpiarParametros();
                    datos.setearConsulta("insert into IMAGENES (IdArticulo, ImagenUrl) values (@idArt, @urlImagen)");
                    datos.setearParametro("@idArt", idArticulo);
                    datos.setearParametro("@urlImagen", img.UrlImagen);

                    datos.ejecutarAccion();
                }

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
}
