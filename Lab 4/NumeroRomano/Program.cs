using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertirNumero
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Escribe un número mayor a 0 y menor a 1 millon: ");
            int num = Int32.Parse(Console.ReadLine());

            ConvertirNumero numeroRomano = new ConvertirNumero();
            Console.WriteLine(numeroRomano.ConvierteNumero(num));

            Console.ReadKey();
        }
    }
}
