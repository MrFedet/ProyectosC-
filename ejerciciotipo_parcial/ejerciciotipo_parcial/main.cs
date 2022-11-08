using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tipo_parcial
{
    internal class program
    {
        static void Main(string[] args)
        {
            Equipo talleres = new Equipo();

            talleres.AgregarJugador();
            talleres.Listar_Jugadores();
            talleres.Suspendidos();
            talleres.determinar_jugadores(5,10);
            talleres.Existe_Jugador();
            talleres.Valoracion_prom();
            talleres.best_valoracion();

        }
    }
}
