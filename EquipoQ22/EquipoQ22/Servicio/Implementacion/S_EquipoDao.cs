using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipoQ22.Domino;
using EquipoQ22.Servicio.Interfaz;
using EquipoQ22.Datos;
using EquipoQ22.Datos.Implementacion;


namespace EquipoQ22.Servicio.Implementacion
{
    internal class S_EquipoDao : IS_EquipoDao
    {
        private IEquipoDao eq;

        public S_EquipoDao()
        {
            eq = new EquipoDao();
        }

        public bool CrearEquipo(Equipo equipo)
        {
            return eq.CrearEquipo(equipo);
        }

        public List<Persona> ObtenerPersonas()
        {
            return eq.ObtenerPersonas();
        }
    }
}
