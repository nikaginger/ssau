using System;


namespace Lab6
{
    class SteppedArray
    {
        public int[][] array;
        public SteppedArray(int m)
        {
            array = new int[m][];
        }
        public static int[][] Input(int[][] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("Введите количество элементов в подмассиве: ");
                int n = Convert.ToInt32(Console.ReadLine());
                array[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    Console.Write("Введите элемент массива: ");
                    array[i][j] = Convert.ToInt32(Console.ReadLine());
                }

            }
            return array;
        }

        public static void Output(int[][] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public static void SteppedArraySort(int[][] array)
        {
            int count = 0;
            int[] aux;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    count++;
                }
            }
            aux = new int[count];

            count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    aux[count] = array[i][j];
                    count++;
                }
            }

            int temp;
            for (int i = 0; i < aux.Length - 1; i++)
            {
                for (int j = 0; j < aux.Length - 1 - i; j++)
                {
                    if (aux[j] > aux[j + 1])
                    {
                        temp = aux[j];
                        aux[j] = aux[j + 1];
                        aux[j + 1] = temp;
                    }
                }
            }

            count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = aux[count];
                    count++;
                }
            }
        }
    }
}
