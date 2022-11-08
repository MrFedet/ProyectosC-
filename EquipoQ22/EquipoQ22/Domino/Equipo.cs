using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.Domino
{
    public class Equipo
    {
        public string Pais { get; set; }
        public string Director { get; set; }

        public List<Jugador> LPersonas;

        public Equipo()
        {
            LPersonas = new List<Jugador>();
        }
        public void AgregarDetalle(Jugador j)
        {
            LPersonas.Add(j);
        }
        public void QuitarDetalle(int posicion)
        {
            LPersonas.RemoveAt(posicion);
        }

        public bool search_list(Jugador a)
        {
            for (int i = 0; i < LPersonas.Count; i++)
            {
                if (LPersonas[i].Persona.IdPersona == a.Persona.IdPersona)
                {
                    return true;
                }
            }
            return false;
        }

        public bool search_camiseta(int a)
        {
            for (int i = 0; i < LPersonas.Count; i++)
            {
                if (LPersonas[i].Camiseta == a)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
