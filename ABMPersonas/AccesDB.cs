using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ABMPersonas
{
    internal class AccesDB
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=FEDET\SQLEXPRESS;Initial Catalog=TUPPI;Integrated Security=True"); 
        SqlCommand comando = new SqlCommand();
        DataTable tabla = new DataTable();
        SqlDataReader lector;

        public void obtener_datosDB(string commandoQuery)
        {
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = commandoQuery;
            lector = comando.ExecuteReader();
            lector.Read();
            conexion.Close();
        }
    }
}
