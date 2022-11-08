using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea
{
    public class lista_productos
    {
        private string[] nombres;
        private int[] cantidades;
        private double[] precios;
        private double[] precio_xcant;
        private double precio_total;
        private producto prod;


        public lista_productos()
        {
            nombres = new string[2];
            cantidades = new int[2];
            precios = new double[2];
            precio_xcant = new double[2];
            precio_total = 0;
            prod = new producto();

        }
        public void Meter_datos()
        {
            for (int i = 0; i < nombres.Length; i++)
            {
                Console.WriteLine("Ingrese el Nombre del producto");
                prod.pNombre = Console.ReadLine();
                Console.WriteLine("Ingrese la Cantidad del producto");
                prod.pCantidad = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el Precio del producto");
                prod.pPrecio = double.Parse(Console.ReadLine());

                nombres[i] = prod.pNombre;
                cantidades[i] = prod.pCantidad;
                precios[i] = prod.pPrecio;
            }
        }

        public void Calcular_precioTotal()
        {
            for (int i = 0; i < precio_xcant.Length; i++)
            {
                precio_xcant[i] = cantidades[i] * precios[i];
                precio_total = precio_total + precio_xcant[i];
            }
        }

        public void Mostrar_Lista()
        {
            for (int i = 0; i < precio_xcant.Length; i++)
            {
                Console.WriteLine("Nombre: " + nombres[i]+ " Precio: " +  precios[i]+ " Cantidad: "+ cantidades[i]+ " Precio x Cantidad "+ precio_xcant[i]);
            }
            Console.WriteLine("Precio Total de productos " + precio_total);
        }


    }
}
