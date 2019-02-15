using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones
{
    public class Operaciones
    {
        double result = 0;
        double cant = 0;
        public double Promedio(int[] numeros)
        {
            cant = numeros.Count();
            int sum = 0;
            foreach (int n in numeros)
            {
                sum += n;
            }

            result = Convert.ToDouble(sum / cant);
            return result;
        }

        public double DesviacionEstandar(int[] numeros)
        {
            double suma = 0;
            cant = numeros.Count();

            foreach (int n in numeros)
            {
                suma += Math.Pow(n - Promedio(numeros), 2);
            }
            result = suma / cant;

            return Math.Sqrt(result);
        }

        public double Media(int[] numeros)
        {
            cant = numeros.Count();
            int index;
            double value = 0;

            Array.Sort(numeros);
            if (cant % 2 == 0)
            {
                //Cuando los numeros del arreglo son pares
                int pos_1 = Convert.ToInt32(cant) / 2;
                int pos_2 = pos_1 + 1;

                int val_1 = numeros[pos_1 - 1];
                int val_2 = numeros[pos_2 - 1];

                value = val_1 + val_2;
                value = value / 2;
                
            }
            else
            {
                //Cuando los numeros en el arreglo son impares
                result = cant / 2;
                index = Convert.ToInt32(Math.Ceiling(result));

                value = Convert.ToDouble(numeros[index - 1]);
                
            }

            return value;
        }
    }
}
