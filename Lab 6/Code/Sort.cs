using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMethod
{
    public class Sort
    {
        public void create_file(int cant)
        {
            var builder = new StringBuilder();
            Random rdm = new Random();

            if (cant > 0)
            {
                //create n random numbers
                for (int i = 0; i < cant; i++)
                {
                    string num = Convert.ToString(rdm.Next(0, 1000000) + ",");
                    builder.Append(num);
                }
                builder.Length--;

                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string file_name = @"\unsorted_numbers.txt";

                //Creates new txt file with random numbers in desktop, if its already exists overwrite it
                if (!File.Exists(desktop + file_name))
                {
                    // Create a file
                    using (StreamWriter sw = File.CreateText(desktop + file_name))
                    {
                        sw.WriteLine(builder);
                    }
                }
                else
                {
                    //Overwrite file
                    using (StreamWriter writer = new StreamWriter(desktop + file_name, false))
                    {
                        writer.Write(builder);
                    }
                }

                Console.WriteLine("Se creo un archivo .txt en el escritorio del equipo llamado: unsorted_numbers.txt");
                
                //Set up the data in the file
                set_input_data(file_name);
            }
            else
            {
                Console.WriteLine("El numero debe ser mayor a 0");
            }
        }
        public void set_input_data(string file_name)
        {
            string line = "";
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string file_path = desktop + file_name;

            List<int> unsortedNums = new List<int>();
            List<int> sortedNums = new List<int>();

            try
            {   //Open the text file.
                var reader = new StreamReader(File.OpenRead(file_path));

                while (!reader.EndOfStream)
                {
                    //read file
                    line = reader.ReadLine();
                }
            }
            catch (IOException e)
            {
                //exception open file error
                Console.WriteLine("Ocurrio un error al leer el archivo unsorted_numbers.txt");
                Console.WriteLine(e.Message);
            }

            if (checkNumbers(line))
            {
                //add unsorted numbers separated by comma into list
                unsortedNums = line.Split(',').Select(int.Parse).ToList();
                
                //add sort numbers into list
                sortedNums = execute_merge_sort(unsortedNums);

                set_up_data(sortedNums);
            }
            else
            {
                Console.WriteLine("Existe un caracter no valido en el archivo unsorted_numbers.txt");
            }
        }

        public bool checkNumbers(string line)
        {
            List<int> numberList = new List<int>();
            try
            {
                //if there's only numbers 
                numberList = line.Split(',').Select(int.Parse).ToList();
                return true;
            }
            catch (FormatException)
            {
                //some not number character in ghe string
                return false;
            }
        }

        public void set_up_data(List<int> sort_list)
        {
            var builder = new StringBuilder();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string file_name = @"\sorted_numbers.txt";

            foreach (int x in sort_list)
            {
                var num = x + ",";
                builder.Append(num);
            }
            builder.Length--;

            //Creates new txt file with the sorted numbers in desktop, if its already exists overwrite it
            if (!File.Exists(desktop + file_name))
            {
                // Create a file
                using (StreamWriter sw = File.CreateText(desktop + file_name))
                {
                    sw.WriteLine(builder);
                }
            }
            else
            {
                //Overwrite file
                using (StreamWriter writer = new StreamWriter(desktop + file_name, false))
                {
                    writer.Write(builder);
                }
            }
            Console.WriteLine("Se creo el archivo sorted_numbers.txt en el escritorio del equipo con los numeros ordenados");
        }

        public List<int> execute_merge_sort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = execute_merge_sort(left);
            right = execute_merge_sort(right);

            return Merge(left, right);
        }

        public List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
