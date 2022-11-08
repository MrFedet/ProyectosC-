using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EquipoQ22.Datos
{
    internal class HelperDB
    {
        protected SqlConnection conn = new SqlConnection(@"Data Source = sqlgabineteinformatico.frc.utn.edu.ar; Initial Catalog = Qatar2022; User ID = alumnolab22; Password=SQL-Alu22");
        protected SqlCommand cmd = new SqlCommand();

        private static HelperDB instance;
        SqlDataReader dr;

        public static HelperDB obtenerInstancia()
        {
            if (instance == null)
            {
                instance = new HelperDB();
            }
            return instance;
        }

        public void open()
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public void close()
        {
            conn.Close();
        }


        public SqlCommand Command
        {
            get { return cmd; }
            set { cmd = value; }
        }


        public DataTable Consultar(string NombreSP)
        {
            DataTable tabla = new DataTable();
            open();
            cmd.CommandText = NombreSP;
            tabla.Load(cmd.ExecuteReader());
            close();
            return tabla;
        }


        public SqlConnection conexion()
        {
            return this.conn;
        }
    }
}
