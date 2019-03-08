using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa la cantidad de numeros aleatorios a generar");
            var cant = Console.ReadLine();

            Console.WriteLine("\nIngresa la opción de ordenamiento: 1-Merge Sort  2-Quick Sort  3-Heap Sort");
            var opt = Console.ReadLine();

            if (IsNumeric(cant) && IsNumeric(opt))
            {
                Sort file = new Sort();
                file.create_file(Convert.ToInt32(cant),Convert.ToInt32(opt));
            }

            bool IsNumeric(string line)
            {
                //method to validate only numbers
                try
                {
                    line = line.Trim();
                    int num = int.Parse(line);
                    return (true);
                }
                catch (FormatException)
                {
                    // Not a numeric value
                    Console.WriteLine("Solo se permiten valores numericos");
                    return (false);
                }
            }
            Console.ReadLine();
        }
    }
}
