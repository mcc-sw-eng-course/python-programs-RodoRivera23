using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SortMethod
{
    public class Sort
    {
        public void create_file(int cant, int option)
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

                Console.WriteLine("\nSe creo un archivo .txt en el escritorio del equipo llamado: unsorted_numbers.txt");
                
                //Set up the data in the file
                set_input_data(file_name, option);
            }
            else
            {
                Console.WriteLine("El numero debe ser mayor a 0");
            }
        }
        public void set_input_data(string file_name, int option)
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

                int[] unsortedArr = line.Split(',').Select(int.Parse).ToArray();


                switch (option)
                {
                    case 1:
                        //merge sort
                        var watch1 = System.Diagnostics.Stopwatch.StartNew();
                            sortedNums = execute_merge_sort(unsortedNums);
                        watch1.Stop();
                        
                        var elapsedMs1 = watch1.ElapsedMilliseconds;
                        Console.WriteLine("\nSe ordenaron "+sortedNums.Count+" números");
                        Console.WriteLine("\nEl proceso de ordenamiento se completo en: " + elapsedMs1 +" milisegundos");

                        set_up_data(sortedNums);
                        break;
                    case 2:
                        //quick sort 
                        var watch2 = System.Diagnostics.Stopwatch.StartNew();
                            sortedNums = execute_quick_sort(unsortedNums);
                        watch2.Stop();

                        var elapsedMs2 = watch2.ElapsedMilliseconds;
                        Console.WriteLine("\nSe ordenaron " + sortedNums.Count + " números");
                        Console.WriteLine("\nEl proceso de ordenamiento se completo en: " + elapsedMs2 + " milisegundos");

                        set_up_data(sortedNums);
                        break;
                    case 3:
                        //heap sort
                        var watch3 = System.Diagnostics.Stopwatch.StartNew();
                            sortedNums = execute_heap_sort(unsortedArr);
                        watch3.Stop();

                        var elapsedMs3 = watch3.ElapsedMilliseconds;
                        Console.WriteLine("\nSe ordenaron " + sortedNums.Count + " números");
                        Console.WriteLine("\nEl proceso de ordenamiento se completo en: " + elapsedMs3 + " milisegundos");

                        set_up_data(sortedNums);
                        break;
                    default:
                        Console.WriteLine("Se ingresó una opción no válida");
                        break;
                }
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
            Console.WriteLine("\nSe creo el archivo sorted_numbers.txt en el escritorio del equipo con los numeros ordenados");
        }

        public void get_perfomance_data()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
        }

        #region Sort Methods
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

        public List<int> execute_quick_sort(List<int> list)
        {
            if (list.Count <= 1) return list;
            int pivotPosition = list.Count / 2;
            int pivotValue = list[pivotPosition];
            list.RemoveAt(pivotPosition);

            List<int> smaller = new List<int>();
            List<int> greater = new List<int>();

            foreach (int item in list)
            {
                if (item < pivotValue)
                {
                    smaller.Add(item);
                }
                else
                {
                    greater.Add(item);
                }
            }

            List<int> sorted = execute_quick_sort(smaller);
            sorted.Add(pivotValue);
            sorted.AddRange(execute_quick_sort(greater));

            return sorted;
        }

        public List<int> execute_heap_sort(int[] array)
        {
            int heapSize = array.Length;

            buildMaxHeap(array);

            for (int i = heapSize - 1; i >= 1; i--)
            {
                swap(array, i, 0);
                heapSize--;
                sink(array, heapSize, 0);
            }

            List<int> result = new List<int>(array);
            return result;
        }

        private static void buildMaxHeap<T>(T[] array) where T : IComparable<T>
        {
            int heapSize = array.Length;

            for (int i = (heapSize / 2) - 1; i >= 0; i--)
            {
                sink(array, heapSize, i);
            }
        }

        private static void sink<T>(T[] array, int heapSize, int toSinkPos) where T : IComparable<T>
        {
            if (getLeftKidPos(toSinkPos) >= heapSize)
            {
                // No left kid => no kid at all
                return;
            }

            int largestKidPos;
            bool leftIsLargest;

            if (getRightKidPos(toSinkPos) >= heapSize || array[getRightKidPos(toSinkPos)].CompareTo(array[getLeftKidPos(toSinkPos)]) < 0)
            {
                largestKidPos = getLeftKidPos(toSinkPos);
                leftIsLargest = true;
            }
            else
            {
                largestKidPos = getRightKidPos(toSinkPos);
                leftIsLargest = false;
            }

            if (array[largestKidPos].CompareTo(array[toSinkPos]) > 0)
            {
                swap(array, toSinkPos, largestKidPos);

                if (leftIsLargest)
                {
                    sink(array, heapSize, getLeftKidPos(toSinkPos));

                }
                else
                {
                    sink(array, heapSize, getRightKidPos(toSinkPos));
                }
            }

        }

        private static void swap<T>(T[] array, int pos0, int pos1)
        {
            T tmpVal = array[pos0];
            array[pos0] = array[pos1];
            array[pos1] = tmpVal;
        }

        private static int getLeftKidPos(int parentPos)
        {
            return (2 * (parentPos + 1)) - 1;
        }

        private static int getRightKidPos(int parentPos)
        {
            return 2 * (parentPos + 1);
        }
        #endregion
    }
}
