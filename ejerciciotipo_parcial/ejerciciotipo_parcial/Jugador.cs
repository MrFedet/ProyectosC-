using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tipo_parcial
{
    internal class Jugador:persona
    {
        private int posicion;
        private bool estaLesionado;
        private int faltas;
        private int valoracion;
        private string estado;


        public Jugador()
        {
            posicion = 0;
            estaLesionado = false;
            faltas = 0;
            valoracion = 0;
            estado = "";
        }
        public Jugador(int posicion, bool estaLesionado, int faltas, 
            string nombre, string apellido, string fecha, string grupo_sanguineo): base(nombre, apellido, fecha, grupo_sanguineo)
        {
            this.posicion = posicion;
            this.estaLesionado = estaLesionado;
            this.faltas = faltas;
        }

        public int pPosicion
        {
            set { posicion = value; }
            get { return posicion; }
        }

        public bool pEstaLesionado
        {
            set { estaLesionado = value; }
            get { return estaLesionado; }
        }
        public int pFaltas
        {
            set { faltas = value; }
            get { return faltas; }
        }

        public int Valoracion()
        {
            if (estaLesionado is false && faltas == 0)
            {
                return 10;
            }
            else
            {
                return 5;
            }
        }

        public bool EstaSuspendido()
        {
            if (faltas >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void ToString()
        {
            Console.WriteLine("Nombre:" + nombre + " Apellido: " + apellido + " Posicion: " + posicion +
                " Esta Lesionado" + estaLesionado + " Faltas:" + faltas + " Fecha de Nacimienot: " + fecha + " Grupo Sanguineo: " + grupo_sanguineo);
        }
    }
}
