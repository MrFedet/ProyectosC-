using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tipo_parcial
{
    internal class Equipo
    {
        private string denominacion;
        private int categoria;
        private Jugador jugador;
        private Jugador[] personas;
        private Jugador[] suspendidos;
        private int cant;
        private Jugador encontrado;
        private  double val_prom;
        private int bestvaloracion;
        private Jugador bestvalor;
        private bool ban;




        public Equipo()
        {
            denominacion = "";
            categoria = 0;
            personas = new Jugador[5];
            suspendidos = new Jugador[5];
            cant = 0;
            bestvaloracion = 0;
        }

        public Equipo(string denominacion, int categoria)
        {
            this.denominacion = denominacion;
            this.categoria = categoria;
        }

        public void AgregarJugador()
        {
            for(int i = 0; i < personas.Length; i++)
            {
                jugador = new Jugador();

                Console.WriteLine("Ingrese el Nombre del Jugador:");
                jugador.pNombre = Console.ReadLine();
                Console.WriteLine("Ingrese el Apellido del Jugador");
                jugador.pApellido = Console.ReadLine();
                Console.WriteLine("Ingrese la fecha de nacimiento del Jugador");
                jugador.pFecha = Console.ReadLine();
                Console.WriteLine("Ingrese el grupo sanguineo del Jugador");
                jugador.pGrupo_Sanguineo = Console.ReadLine();
                Console.WriteLine("Ingrese la posicion del Jugador");
                jugador.pPosicion = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese las faltas del jugador");
                jugador.pFaltas = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese si el jugador está lesionado");
                jugador.pEstaLesionado = bool.Parse(Console.ReadLine());

                personas[i] = jugador;
            }
            Console.WriteLine("");
        }

        public void Listar_Jugadores()
        {
            for (int i = 0; i < personas.Length; i++)
            {
                personas[i].ToString();
            }
        }

        public void Suspendidos()
        {
            for (int i = 0; i < personas.Length; i++)
            {
                if (personas[i].EstaSuspendido())
                {
                    suspendidos[i] = personas[i];
                }
            }

            Console.WriteLine("Los jugadores suspendidos por faltas fueron");
            for (int i = 0; i < personas.Length; i++)
            {
                if (suspendidos[i] != null)
                {
                    suspendidos[i].ToString();
                }   
            }
            Console.WriteLine("");
        }

        public void determinar_jugadores(int pos, int valor)
        {
            for (int i = 0; i < personas.Length; i++)
            {
                if ((personas[i].pPosicion == pos) && valor == personas[i].Valoracion())
                {
                    cant++;
                }
            }
            Console.WriteLine("");
        }

        public void Existe_Jugador()
        {
            for (int i = 0; i < personas.Length; i++)
            {
                if ((personas[i].pPosicion >= 4 && personas[i].pPosicion <= 7) && (personas[i].Valoracion() == 10) && personas[i].pEstaLesionado == false)
                {
                    ban = true;
                    encontrado = personas[i];

                    break;
                }
                else
                {
                    ban = false;
                }
            }

            if (ban is true)
            {
                encontrado.ToString();
            }
            else
            {
                Console.WriteLine("Jugador no encontrado");
            }
        }

        public void Valoracion_prom()
        {
            for (int i = 0; i < personas.Length; i++)
            {
                val_prom += personas[i].Valoracion();
            }

            val_prom = val_prom / personas.Length;
            Console.WriteLine("La valoracion promedio de los jugadores es de " + val_prom);
            Console.WriteLine("");
        }

        public void best_valoracion()
        {
            for(int i = 0; i < personas.Length; i++)
            {
                if (personas[i].pPosicion >= 8 && personas[i].pPosicion <= 11)
                {
                    if (personas[i].Valoracion() > bestvaloracion)
                    {
                        bestvaloracion = personas[i].Valoracion();
                        bestvalor = personas[i];
                    }
                }
            }

            Console.WriteLine("El jugador con mejor valoracion en los delanteros fue");
            bestvalor.ToString();
        }

    }
}
