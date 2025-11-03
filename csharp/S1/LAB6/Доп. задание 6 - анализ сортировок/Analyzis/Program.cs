using System;
using System.Diagnostics;

namespace Analyzis
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxes = new int[10] { 100, 500, 1000, 5000, 10000, 20000, 30000, 40000, 50000, 100000 };
            long[,] results = new long[4, 10];
            Console.WriteLine("Скорости выполнения различных сортировок на разных количествах элементов");

            Console.WriteLine();
            Console.WriteLine("{0, -20}{1, 9}{2, 9}{3, 9}{4, 9}{5, 9}{6, 9}{7, 9}{8, 9}{9, 9}{10, 9}", "Сортировки/Элементы", "100", "500", "1000", "5000", "10000", "20000", "30000", "40000", "50000", "100000");
            for (int i = 0; i < 10; i++)
            {
                int[] array = new int[boxes[i]];
                Sort.Input(array);
                int[] array1 = new int[boxes[i]];
                int[] array2 = new int[boxes[i]];
                int[] array3 = new int[boxes[i]];
                int[] array4 = new int[boxes[i]];
                array.CopyTo(array1, 0);
                array.CopyTo(array2, 0);
                array.CopyTo(array3, 0);
                array.CopyTo(array4, 0);

                results[0, i] = Sort.BubbleSort(array1);
                results[1, i] = Sort.ShakerSort(array2);
                results[2, i] = Sort.InsertSort(array3);
                results[3, i] = Sort.ShellSort(array4);
            }

            
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                    Console.Write("{0, 20}", "Пузырьком");
                if (i == 1)
                    Console.Write("{0, 20}", "Шейкерная");
                if (i == 2)
                    Console.Write("{0, 20}", "Вставками");
                if (i == 3)
                    Console.Write("{0, 20}", "Шелла");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("{0, 9}", results[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

    class Sort
    {
        static public void Input(int[] array)
        {
            Random randNum = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randNum.Next(0, 1000);
            }
        }

        static public void Output(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static public long BubbleSort(int[] array)
        {
            var time = new Stopwatch();
            time.Start();
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            time.Stop();
            return time.ElapsedMilliseconds;
        }

        static public long ShellSort(int[] array)
        {
            var time = new Stopwatch();
            time.Start();
            int temp;
            int step = (int)(array.Length / 2);
            while (step > 0)
            {
                for (int i = step; i < array.Length; i++)
                {
                    int j = i;
                    while (j >= step && array[j - step] > array[j])
                    {
                        temp = array[j - step];
                        array[j - step] = array[j];
                        array[j] = temp;
                        j -= step;
                    }
                }
                step = (int)(step / 2);
            }
            time.Stop();
            return time.ElapsedMilliseconds;
        }

        static public long InsertSort(int[] array)
        {
            var time = new Stopwatch();
            time.Start();
            for (int i = 1; i < array.Length; i++)
            {
                int k = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > k)
                {
                    array[j + 1] = array[j];
                    array[j] = k;
                    j--;
                }
            }
            time.Stop();
            return time.ElapsedMilliseconds;
        }

        public static long ShakerSort(int[] arr)
        {
            var time = new Stopwatch();
            time.Start();
            int left = 0;
            int right = arr.Length - 1;
            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int v = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = v;
                    }
                }
                right--;
                for (int i = right; i > left; i--)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        int v = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = v;
                    }
                }
                left++;
            }
            time.Stop();
            return time.ElapsedMilliseconds;
        }
        
    }
}