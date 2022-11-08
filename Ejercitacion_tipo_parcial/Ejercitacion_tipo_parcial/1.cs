using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Problema 2.8:
Capturar los datos de 5 productos comprados en una tienda, incluyendo
nombre, precio y cantidad en sus 3 listas respectivas, después calcular una cuarta
lista con el gasto total por cada producto desplegarlo todo en un segundo panel e
incluir también el gran total.*/

namespace tarea
{
    public class producto
    {
        private string nombre;
        private int cantidad;
        private double precio;



        public producto()
        {
            nombre = string.Empty;
            cantidad = 0;
            precio = 0;
        }

        public producto(string nombre, int cantidad, double precio)
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.precio = precio;
        }

        public string pNombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        public double pPrecio
        {
            set { precio = value; }
            get { return precio; }
        }

        public int pCantidad
        {
            set { cantidad = value; }
            get { return cantidad; }
        }
    }
}
