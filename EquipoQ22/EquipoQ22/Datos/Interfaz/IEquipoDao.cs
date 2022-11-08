using EquipoQ22.Domino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.Datos
{
    public interface IEquipoDao
    {
        List<Persona> ObtenerPersonas();
        bool CrearEquipo(Equipo equipo);
    }
}
