using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMPersonas
{
    internal class Persona
    {
        private string nombre;
        private string apellido;
        private int tipo_documento;
        private string documento;
        private int estado_civil;
        private int sexo;
        private bool fallecido;

        public Persona(string nombre, string apellido, int tipo_documento, string documento, int estado_civil, int sexo, bool fallecido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.tipo_documento = tipo_documento;
            this.documento = documento;
            this.estado_civil = estado_civil;
            this.sexo = sexo;
            this.fallecido = fallecido;
        }

        public Persona()
        {
            this.nombre = string.Empty;
            this.apellido = string.Empty;
            this.tipo_documento = 0 ;
            this.documento = string.Empty;
            this.estado_civil = 0 ;
            this.sexo = 0;
            this.fallecido = false;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public int Tipo_documento
        {
            get { return tipo_documento; }
            set { tipo_documento = value; }
        }

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public int Estado_civil
        {
            get { return estado_civil; }
            set { estado_civil = value; }
        }

        public int Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public bool Fallecido
        {
            get { return fallecido; }
            set { fallecido = value; }
        }
    }
}
