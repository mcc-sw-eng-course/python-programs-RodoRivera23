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

            if (IsNumeric(cant))
            {
                Sort file = new Sort();
                file.create_file(Convert.ToInt32(cant));
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
