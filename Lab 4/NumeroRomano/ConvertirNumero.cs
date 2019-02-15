using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertirNumero
{
    public class ConvertirNumero
    {
        public string ConvierteNumero(int num)
        {
            string num_rom = "";
            bool val = true;
            while (true)
            {
                if (num < 1000000 && num > 99999)
                {
                    switch (num / 100000)
                    {
                        case 1: num_rom += "C°"; break;
                        case 2: num_rom += "C°C°"; break;
                        case 3: num_rom += "C°C°C°"; break;
                        case 4: num_rom += "C°D°"; break;
                        case 5: num_rom += "D°"; break;
                        case 6: num_rom += "D°C°"; break;
                        case 7: num_rom += "D°C°C°"; break;
                        case 8: num_rom += "D°C°C°C°"; break;
                        case 9: num_rom += "C°M°"; break;
                    }
                    num -= 100000 * (num / 100000);
                }
                else if (num < 100000 && num > 9999)
                {
                    switch (num / 10000)
                    {
                        case 1: num_rom += "X°"; break;
                        case 2: num_rom += "X°X°"; break;
                        case 3: num_rom += "X°X°X°"; break;
                        case 4: num_rom += "X°L°"; break;
                        case 5: num_rom += "L°"; break;
                        case 6: num_rom += "L°X°"; break;
                        case 7: num_rom += "L°X°X°"; break;
                        case 8: num_rom += "L°X°X°X°"; break;
                        case 9: num_rom += "X°C°"; break;
                    }
                    num -= 10000 * (num / 10000);
                }
                else if (num < 10000 && num > 999)
                {
                    switch (num / 1000)
                    {
                        case 1: num_rom += "M"; break;
                        case 2: num_rom += "MM"; break;
                        case 3: num_rom += "MMM"; break;
                        case 4: num_rom += "MV°"; break;
                        case 5: num_rom += "V°"; break;
                        case 6: num_rom += "V°M"; break;
                        case 7: num_rom += "V°MM"; break;
                        case 8: num_rom += "VMMM°"; break;
                        case 9: num_rom += "MX°"; break;
                    }
                    num -= 1000 * (num / 1000);
                }
                else if (num < 1000 && num > 99)
                {
                    switch (num / 100)
                    {
                        case 1: num_rom += "C"; break;
                        case 2: num_rom += "CC"; break;
                        case 3: num_rom += "CCC"; break;
                        case 4: num_rom += "CD"; break;
                        case 5: num_rom += "C"; break;
                        case 6: num_rom += "DC"; break;
                        case 7: num_rom += "DCC"; break;
                        case 8: num_rom += "DCCC"; break;
                        case 9: num_rom += "CM"; break;
                    }
                    num -= 100 * (num / 100);
                }
                else if (num < 100 && num > 9)
                {
                    switch (num / 10)
                    {
                        case 1: num_rom += "X"; break;
                        case 2: num_rom += "XX"; break;
                        case 3: num_rom += "XXX"; break;
                        case 4: num_rom += "XL"; break;
                        case 5: num_rom += "L"; break;
                        case 6: num_rom += "LX"; break;
                        case 7: num_rom += "LXX"; break;
                        case 8: num_rom += "LXXX"; break;
                        case 9: num_rom += "XC"; break;
                    }
                    num -= 10 * (num / 10);
                }
                else if (num < 10 && num > 0)
                {
                    switch (num)
                    {
                        case 1: num_rom += "I"; break;
                        case 2: num_rom += "II"; break;
                        case 3: num_rom += "III"; break;
                        case 4: num_rom += "IV"; break;
                        case 5: num_rom += "V"; break;
                        case 6: num_rom += "VI"; break;
                        case 7: num_rom += "VII"; break;
                        case 8: num_rom += "VIII"; break;
                        case 9: num_rom += "IX"; break;
                    }
                    num -= num;
                }
                else
                {
                    Console.Write("El número esta fuera de rango");
                    val = false;
                    break;
                }
                if (num == 0)
                    break;
            }
            if (val)
                Console.Write("");
            return num_rom;
        }
    }
}
