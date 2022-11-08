using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ABMMascotas
{
    internal class accessDB
    {
        SqlConnection coneccion = new SqlConnection(@"Data Source=FEDET\SQLEXPRESS;Initial Catalog=Veterinaria;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        SqlDataReader lector; 

        public SqlDataReader Lector
        {
            get { return lector; }
            set { lector = value; }
        }
        public void leerDB(string query)
        {
            conection();
            command.CommandText = query;
            lector = command.ExecuteReader();
        }

        public void actualizarDB(string query, Mascota m)
        {
            conection();
            command.Parameters.AddWithValue("@codigo", m.pCodigo);
            command.Parameters.AddWithValue("@nombre", m.pNombre);
            command.Parameters.AddWithValue("@especie", m.pEspecie);
            command.Parameters.AddWithValue("@sexo", m.pSexo);
            command.Parameters.AddWithValue("@fechaNacimiento", m.pFechaNacimiento);
            command.CommandText = query;
            command.ExecuteNonQuery();
            desconectar();
        }

        public DataTable accederDB(string query)
        {
            DataTable dt = new DataTable();
            conection();
            command.CommandText= query;
            dt.Load(command.ExecuteReader());
            desconectar();
            return dt;
        }

        public void conection()
        {
            coneccion.Open();
            command.Connection = coneccion;
            command.CommandType = CommandType.Text;
        }
        public void desconectar()
        {
            coneccion.Close();
        }


    /*string insert = "insert into Mascotas(codigo , nombre ,especie, sexo, fechaNacimiento) values(" + m.pCodigo + ", '" + m.pNombre + "', " + m.pEspecie + "," + m.pSexo + ",'" + m.pFechaNacimiento.ToString("yyyy/MM/dd") + "')";
     oDB.actualizarDB(insert);*/
    /*txtCodigo.Focus();*/



    /* private void cargar_cbo(string query, ComboBox cbo, string display, string value)
{
    cbo.DataSource = oDB.accederDB(query);
    cbo.DisplayMember = display;
    cbo.ValueMember = value;
    cbo.DropDownStyle = ComboBoxStyle.DropDownList;
}*/


    /* List<Mascota> mascotaList = new List<Mascota>();

        private void cargar_lista(ListBox list, string tabla)
         {
         mascotaList.Clear();

         oDB.leerDB("Select * from " + tabla);
         while (oDB.Lector.Read())
         {
             Mascota m = new Mascota();
             if (!oDB.Lector.IsDBNull(0))
             {
                 m.pCodigo = oDB.Lector.GetInt32(0);
             }
             if (!oDB.Lector.IsDBNull(1))
             {
                 m.pNombre = oDB.Lector.GetString(1);
             }
             mascotaList.Add(m);
         }
         oDB.desconectar();
         list.Items.Clear();
         for(int i = 0; i < mascotaList.Count; i++)
         {
             list.Items.Add(mascotaList[i].ToString());
         }
    
        }*/


    /*public bool existedb(string table, string usuario)
        {
            oDB.leerDB("Select codigo from " + table);
            while (oDB.Lector.Read())
            {
                if(Convert.ToString(oDB.Lector.GetInt32(0)) == usuario)
                {
                    oDB.desconectar();
                    return true;
                }
            }
            oDB.desconectar();
            return false;
        }*/
}
}
