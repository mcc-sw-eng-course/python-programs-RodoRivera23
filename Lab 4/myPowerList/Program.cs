using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPowerList
{
    class Program
    {
        static void Main(string[] args)
        {
            String filename;

            Console.WriteLine("Escribe el nombre del archivo que será leido");

            filename = Console.ReadLine();

            myPowerList trylist = new myPowerList();
            Console.WriteLine("El archivo contiene lo siguiente: "+trylist.ReadFromTexFile(filename));

            Console.ReadLine();
            
        }
    }
}
