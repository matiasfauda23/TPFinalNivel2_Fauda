using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            //Creo una nueva lista de articulos
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Traigo los datos de la tabla articulos
                datos.SetearConsulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria, M.Descripcion as Marca, C.Descripcion as Categoria From ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id And A.IdCategoria = C.Id");
                datos.EjecutarLectura();

                //Mientras haya datos para leer los recorro
                while (datos.Lector.Read())
                {
                    Articulo aux = mapear(datos);
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
                datos.CerrarConexion();
            }
        }
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@codigo, @nombre, @desc, @idMarca, @idCategoria, @img, @precio)");
                datos.SetearParametro("@codigo", nuevo.Codigo);
                datos.SetearParametro("@nombre", nuevo.Nombre);
                datos.SetearParametro("@desc", nuevo.Descripcion);
                datos.SetearParametro("@idMarca", nuevo.Marca.Id);
                datos.SetearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.SetearParametro("@img", nuevo.ImagenUrl);
                datos.SetearParametro("@precio", nuevo.Precio);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @img, Precio = @precio where Id = @id");
                datos.SetearParametro("@codigo", articulo.Codigo);
                datos.SetearParametro("@nombre", articulo.Nombre);
                datos.SetearParametro("@desc", articulo.Descripcion);
                datos.SetearParametro("@idMarca", articulo.Marca.Id);
                datos.SetearParametro("@idCategoria", articulo.Categoria.Id);
                datos.SetearParametro("@img", articulo.ImagenUrl);
                datos.SetearParametro("@precio", articulo.Precio);
                datos.SetearParametro("@id", articulo.Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Delete from ARTICULOS where Id = @id");
                datos.SetearParametro("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // La consulta base es la misma que listar(), pero le vamos a pegar el WHERE al final
                string consulta = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria, M.Descripcion as Marca, C.Descripcion as Categoria From ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id And A.IdCategoria = C.Id";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += " AND A.Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += " AND A.Precio < " + filtro;
                            break;
                        default:
                            consulta += " AND A.Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " AND A.Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += " AND A.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += " AND A.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else 
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " AND A.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += " AND A.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += " AND A.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(mapear(datos));
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private Articulo mapear(AccesoDatos datos)
        {
            Articulo aux = new Articulo();
            try
            {

                aux.Id = (int)datos.Lector["Id"];
                aux.Codigo = (string)datos.Lector["Codigo"];
                aux.Nombre = (string)datos.Lector["Nombre"];

                
                if (!(datos.Lector["Descripcion"] is DBNull))
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                
                if (!(datos.Lector["ImagenUrl"] is DBNull))
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                aux.Precio = (decimal)datos.Lector["Precio"];

               
                aux.Marca = new Marca();
                aux.Marca.Id = (int)datos.Lector["IdMarca"];
                aux.Marca.Descripcion = (string)datos.Lector["Marca"]; // Ojo con el alias

                aux.Categoria = new Categoria();
                aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                aux.Categoria.Descripcion = (string)datos.Lector["Categoria"]; // Ojo con el alias
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return aux;
        }
    }
}