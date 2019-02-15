using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa la cantidad de numeros a usar");
            int cantidad = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa " + cantidad + " numeros");
            int[] numeros = new int[cantidad];
            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = int.Parse(Console.ReadLine());
            }

            Operaciones resultado = new Operaciones();

            Console.WriteLine("El promedio es: " + resultado.Promedio(numeros));
            Console.WriteLine("La desviacion estandar es: " + resultado.DesviacionEstandar(numeros));
            Console.WriteLine("El valor medio es: " + resultado.Media(numeros));


            Console.ReadLine();
        }
    }
}
