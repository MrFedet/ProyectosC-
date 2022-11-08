using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ABMProductos
{
    class AccesoDatos
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=localhost;Initial Catalog=Informatica;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;
        
        public SqlDataReader pLector
        {
            get { return lector; }
            set { lector = value; }
        }
        public void leerBD(string consultaSQL)
        {
            conectar();
            comando.CommandText = consultaSQL;
            lector = comando.ExecuteReader();
        }
        public DataTable consultarBD(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            conectar();
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }
        private void conectar()
        {
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }
        public void desconectar()
        {
            conexion.Close();
        }
        public void actualizarBD(string consultaSQL)
        {
            conectar();
            comando.CommandText = consultaSQL;
            comando.ExecuteNonQuery();
            desconectar();
        }
    }
}
