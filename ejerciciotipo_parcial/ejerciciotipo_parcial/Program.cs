namespace tipo_parcial
{
    public abstract class persona
    {
        protected string nombre;
        protected string apellido;
        protected string fecha;
        protected string grupo_sanguineo;

        public persona()
        {
            nombre = "";
            apellido = "";
            fecha = "";
            grupo_sanguineo = "";
        }

        public persona(string nombre, string apellido , string fecha, string grupo_sanguineo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fecha = fecha;
            this.grupo_sanguineo = grupo_sanguineo;
        }

        public string pNombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        public string pApellido
        {
            set { apellido = value; }
            get { return apellido; }
        }

        public string pFecha
        {
            set { fecha = value; }
            get { return fecha; }
        }

        public string pGrupo_Sanguineo
        {
            set { grupo_sanguineo = value; }
            get { return grupo_sanguineo; }
        }

        public virtual void ToString()
        {
            Console.WriteLine("Nombre: " + nombre + " Apellido: " + apellido + " Fecha: " + fecha + " Grupo Sanguineo: " + grupo_sanguineo);
        } 

    }
}