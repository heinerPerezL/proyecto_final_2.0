using System;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    class BDconexion
    { //  datos para la conexión
        public string cadenaConexion = @"Data Source=SMORENO_POR\SQL;Initial Catalog=Control;Integrated Security=True";
        SqlConnection conexion;

        public SqlConnection crearConexion()
        {
            this.conexion = new SqlConnection(this.cadenaConexion);
            return this.conexion;
        }

        /****metodo de INSERT****/
        public bool comando(string strCOMANDO)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = strCOMANDO;
                comando.Connection = this.crearConexion();
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch
            {
                return false;

            }
        }

        public bool buscar(string usuario , string pwd) // Busca en la BD si usuario y contrasseña existen
        {
            bool r = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT Id_Conductor , Password FROM tblConductor WHERE Id_Conductor = '" + usuario + "' AND Password =  '" + pwd+"'";
            comando.Connection = this.crearConexion();
            conexion.Open();
            SqlDataReader resultado = null;
            resultado = comando.ExecuteReader();

            if (resultado.Read())
            {
                r = true;
            }
            else
            {
                r = false;
            }
            conexion.Close();
            return r;
        }

        public bool verEstado(string usuario) // Válida el estado del conductor
        {
            bool e = false;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT Estado_Conductor  FROM tblConductor WHERE Id_Conductor = '" + usuario + "' AND Estado_Conductor = 'inactivo' ";
            comando.Connection = this.crearConexion();
            conexion.Open();
            SqlDataReader resultado = null;
            resultado = comando.ExecuteReader();

            if (resultado.Read())
            {
                e = true;
            }
            else
            {
                e = false;
            }
            conexion.Close();
            return e;
        }

        public DataSet Mostrar(SqlCommand strCOMANDO) // ejecuta comando update y llenado de tablas
        {
            System.Data.DataSet Ds = new DataSet();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd = strCOMANDO;
                cmd.Connection = crearConexion();
                adaptador.SelectCommand = cmd;
                conexion.Open();
                adaptador.Fill(Ds);
                conexion.Close();
                return Ds;
            }
            catch (Exception)
            {
                return Ds;
            }

        }
    }
}
