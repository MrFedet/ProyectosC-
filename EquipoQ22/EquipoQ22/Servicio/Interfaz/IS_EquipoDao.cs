using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipoQ22.Domino;

namespace EquipoQ22.Servicio.Interfaz
{
    internal interface IS_EquipoDao
    {
        List<Persona> ObtenerPersonas();
        bool CrearEquipo(Equipo equipo);
    }
}
