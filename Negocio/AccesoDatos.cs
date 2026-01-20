using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        //Atributos para la conexion
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        //Constructor
        public AccesoDatos()
        {
            //Leemos la direccion de la conexion del archivo App.config
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexion"].ToString());
            comando = new SqlCommand();
        }

        //Metodo para setear la consulta
        public void SetearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //Metodo para ejecutar la consulta
        public void EjecutarLectura()
        {
            //Asigno la conexion al comando
            comando.Connection = conexion;
            try
            {
                //Abro la conexion
                conexion.Open();
                //Ejecuto el lector el cual devuelve un conjunto de resultados que luego puedo recorrer
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Metodo para ejecutar acciones (insert, update, delete)
        public void EjecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                //Ejecuto el comando y que no devuelva nada
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Metodo para setear los parametros
        public void SetearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        //Metodo para cerrar la conexion y el lector
        public void CerrarConexion()
        {
            if (lector != null)
                lector.Close();
            if(conexion.State == System.Data.ConnectionState.Open)
            {
               conexion.Close();
            }
        }
    }
}