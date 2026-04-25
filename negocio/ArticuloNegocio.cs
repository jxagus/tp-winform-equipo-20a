using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                /*datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, " +
                             "M.Descripcion AS DescripcionMarca, " +
                             "C.Descripcion AS DescripcionCategoria, " +
                             "M.Id AS IdMarca, C.Id AS IdCategoria "+
                             "FROM ARTICULOS A, MARCAS M, CATEGORIAS C " +
                             "WHERE A.IdMarca = M.Id " +
                             "AND A.IdCategoria = C.Id ");*/
                datos.setearConsulta(
                "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio," +
                "(SELECT TOP 1 I.ImagenUrl FROM IMAGENES I WHERE I.IdArticulo = A.Id ORDER BY I.Id) AS ImagenUrl," +
                "M.Descripcion AS DescripcionMarca," +
                "C.Descripcion AS DescripcionCategoria," +
                "M.Id AS IdMarca, C.Id AS IdCategoria " +
                "FROM ARTICULOS A " +
                "INNER JOIN MARCAS M ON A.IdMarca = M.Id " +
                "INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = Convert.ToDecimal(datos.Lector["Precio"]);

                    aux.Imagenes = new List<Imagen>();

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        Imagen img = new Imagen();
                        img.UrlImagen = datos.Lector["ImagenUrl"].ToString();

                        aux.Imagenes.Add(img);
                    }
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
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) " + "output inserted.id " + "values('" + nuevo.Codigo + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', @idMarca, @idCategoria, @Precio)");
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@Precio", nuevo.Precio);
                int idArticulo = datos.leerUltimoId();
                foreach (Imagen img in nuevo.Imagenes)
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

        public void modificar(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Desc, IdMarca = @IdMarca, IdCategoria = @IdCat, Precio = @Precio where Id = @id");
                datos.setearParametro("@Codigo", modificar.Codigo);
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Desc", modificar.Descripcion);
                datos.setearParametro("@IdMarca", modificar.Marca.Id);
                datos.setearParametro("@IdCat", modificar.Categoria.Id);
                datos.setearParametro("@Precio", modificar.Precio);
                datos.setearParametro("@id", modificar.Id);
                datos.ejecutarAccion();

                datos.limpiarParametros();
                datos.setearConsulta("delete from IMAGENES where IdArticulo = @idArt");
                datos.setearParametro("@idArt", modificar.Id);
                datos.ejecutarAccion();

                foreach (Imagen img in modificar.Imagenes)
                {
                    datos.limpiarParametros();
                    datos.setearConsulta("insert into IMAGENES (IdArticulo, ImagenUrl) values (@idArt, @urlImagen)");
                    datos.setearParametro("@idArt", modificar.Id);
                    datos.setearParametro("@urlImagen", img.UrlImagen);

                    datos.ejecutarAccion();
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> listaArticulo = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio," +
                "(SELECT TOP 1 I.ImagenUrl FROM IMAGENES I WHERE I.IdArticulo = A.Id ORDER BY I.Id) AS ImagenUrl," +
                "M.Descripcion AS DescripcionMarca," +
                "C.Descripcion AS DescripcionCategoria," +
                "M.Id AS IdMarca, C.Id AS IdCategoria " +
                "FROM ARTICULOS A " +
                "INNER JOIN MARCAS M ON A.IdMarca = M.Id " +
                "INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id AND ";

                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Precio > " + filtro;
                                break;
                            default:
                                consulta += "Precio < " + filtro;
                                break;

                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "' ";
                                break;
                            default:
                                consulta += "Nombre like '%" + filtro + "%' ";
                                break;
                        }
                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Categoria like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "Categoria like '%" + filtro + "' ";
                                break;
                            default:
                                consulta += "Categoria like '%" + filtro + "%' ";
                                break;
                        }
                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Marca like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "Marca like '%" + filtro + "' ";
                                break;
                            default:
                                consulta += "Marca like '%" + filtro + "%' ";
                                break;
                        }
                        break;

                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = Convert.ToDecimal(datos.Lector["Precio"]);

                    aux.Imagenes = new List<Imagen>();

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        Imagen img = new Imagen();
                        img.UrlImagen = datos.Lector["ImagenUrl"].ToString();

                        aux.Imagenes.Add(img);
                    }
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["DescripcionMarca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["DescripcionCategoria"];

                    listaArticulo.Add(aux);
                }
                return listaArticulo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
