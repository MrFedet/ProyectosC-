/*Problema 2.8:
Capturar los datos de 5 productos comprados en una tienda, incluyendo
nombre, precio y cantidad en sus 3 listas respectivas, después calcular una cuarta
lista con el gasto total por cada producto desplegarlo todo en un segundo panel e
incluir también el gran total.*/

namespace tarea
{
    class Program {
        static void Main(string[] args){

            lista_productos list_prod = new lista_productos();

            list_prod.Meter_datos();
            list_prod.Calcular_precioTotal();
            list_prod.Mostrar_Lista();

            Console.ReadKey();

        }
    }
}