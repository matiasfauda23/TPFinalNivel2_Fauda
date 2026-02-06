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
        /// <summary>
        /// Recupera el listado completo de artículos desde la base de datos, incluyendo sus relaciones (Marcas y Categorías).
        /// </summary>
        /// <returns>Una colección (List) de objetos Articulo con sus datos mapeados.</returns>
        /// <exception cref="Exception">Lanza una excepción si falla la conexión o la lectura de datos.</exception>
        public List<Articulo> listar()
        {
            //Creo una nueva lista de articulos
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Traigo los datos de la tabla articulos
                datos.SetearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, A.IdMarca, A.IdCategoria, M.Descripcion as Marca, C.Descripcion as Categoria From ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id And A.IdCategoria = C.Id");
                datos.EjecutarLectura();

                //Mientras haya datos para leer los recorro
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    // Validacion de nulos para imagen
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Precio = (decimal)datos.Lector["Precio"];

                    // Instanciamos la Marca y cargamos sus datos
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    // Instanciamos la Categoria
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    // Agregamos el articulo a la lista
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
        /// <summary>
        /// Inserta un nuevo registro de Artículo en la base de datos.
        /// </summary>
        /// <param name="nuevo">Objeto Articulo con la información completa a registrar.</param>
        /// <exception cref="Exception">Lanza una excepción si ocurre un error durante la ejecución del comando SQL.</exception>

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

        /// <summary>
        /// Consulta la base de datos para filtrar articulos segun criterios dinamicos.
        /// Construye una consulta SQL bajo demanda concatenando las condiciones.
        /// </summary>
        /// <param name="campo">La propiedad por la cual se desea filtrar (ej: Precio, Nombre, Descripción).</param>
        /// <param name="criterio">El operador lógico a aplicar (ej: Mayor a, Contiene, Termina con).</param>
        /// <param name="filtro">El valor contra el cual se compara (el texto o número escrito por el usuario).</param>
        /// <returns>Una lista de objetos Articulo que cumplen con las condiciones.</returns>
        /// <exception cref="Exception">Lanza una excepción si hay error de conexión a SQL.</exception>
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria, M.Descripcion as Marca, C.Descripcion as Categoria From ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id And A.IdCategoria = C.Id ";

                //Agregamos el filtro dinamicamente segun el campo
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += " AND A.Precio > " + filtro.Replace(",", ".");
                            break;
                        case "Menor a":
                            consulta += " AND A.Precio < " + filtro.Replace(",", ".");
                            break;
                        default:
                            consulta += " AND A.Precio = " + filtro.Replace(",", ".");
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
               

                //Ejecutamos
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
            finally
            {
                datos.CerrarConexion();
            }
        }

        private Articulo mapear(AccesoDatos datos)
        {
            Articulo aux = new Articulo();
            try
            {
                // Datos basicos
                aux.Id = (int)datos.Lector["Id"];
                aux.Codigo = (string)datos.Lector["Codigo"];
                aux.Nombre = (string)datos.Lector["Nombre"];

                // Validacion de nulos
                if (!(datos.Lector["Descripcion"] is DBNull))
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                if (!(datos.Lector["ImagenUrl"] is DBNull))
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                aux.Precio = (decimal)datos.Lector["Precio"];

               
                aux.Marca = new Marca();
                aux.Marca.Id = (int)datos.Lector["IdMarca"];
                aux.Marca.Descripcion = (string)datos.Lector["Marca"]; // Ojo: requiere alias "Marca" en SQL

               
                aux.Categoria = new Categoria();
                aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                aux.Categoria.Descripcion = (string)datos.Lector["Categoria"]; // Ojo: requiere alias "Categoria" en SQL

                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}