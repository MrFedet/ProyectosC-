using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipoQ22.Datos;
using EquipoQ22.Domino;
using System.Data;
using System.Data.SqlClient;


namespace EquipoQ22.Datos.Implementacion
{
    internal class EquipoDao : IEquipoDao
    {
        public bool CrearEquipo(Equipo equipo)
        {
            bool bandera = false;
            SqlConnection conn = HelperDB.obtenerInstancia().conexion();
            SqlTransaction tr = null;
            try
            {
                HelperDB.obtenerInstancia().open();
                tr = conn.BeginTransaction();
                HelperDB.obtenerInstancia().Command.Transaction = tr;
                HelperDB.obtenerInstancia().Command.Parameters.Clear();
                HelperDB.obtenerInstancia().Command.Parameters.AddWithValue("@pais", equipo.Pais);
                HelperDB.obtenerInstancia().Command.Parameters.AddWithValue("@director_tecnico", equipo.Director);

                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@id";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                HelperDB.obtenerInstancia().Command.Parameters.Add(pOut);
                HelperDB.obtenerInstancia().Command.CommandText = "SP_INSERTAR_EQUIPO";
                HelperDB.obtenerInstancia().Command.ExecuteNonQuery();
                int idequipo = (int)pOut.Value;

                HelperDB.obtenerInstancia().Command.Parameters.Clear();
                for (int i = 0; i < equipo.LPersonas.Count; i++)
                {
                    HelperDB.obtenerInstancia().Command.Transaction = tr;
                    HelperDB.obtenerInstancia().Command.Parameters.AddWithValue("@id_equipo", idequipo);
                    HelperDB.obtenerInstancia().Command.Parameters.AddWithValue("@id_persona", equipo.LPersonas[i].Persona.IdPersona);
                    HelperDB.obtenerInstancia().Command.Parameters.AddWithValue("@camiseta", equipo.LPersonas[i].Camiseta);
                    HelperDB.obtenerInstancia().Command.Parameters.AddWithValue("@posicion", equipo.LPersonas[i].Posicion);
                    HelperDB.obtenerInstancia().Command.CommandText = "SP_INSERTAR_DETALLES_EQUIPO";
                    HelperDB.obtenerInstancia().Command.ExecuteNonQuery();
                    HelperDB.obtenerInstancia().Command.Parameters.Clear();
                }
                tr.Commit();
                bandera = true;
            }
            catch (Exception)
            {
                tr.Rollback();
                bandera = false;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    HelperDB.obtenerInstancia().close();
                }
            }
            return bandera;
        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> lst = new List<Persona>();
            DataTable tabla = HelperDB.obtenerInstancia().Consultar("SP_CONSULTAR_PERSONAS");
            foreach (DataRow fila in tabla.Rows)
            {
                Persona per = new Persona();
                per.IdPersona = (int)fila["id_persona"];
                per.NombreCompleto = fila["nombre_completo"].ToString();
                per.Clase = (int)fila["clase"];
                lst.Add(per);
            }
            return lst;
        }
    }
}
