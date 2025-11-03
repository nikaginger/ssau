using System;

namespace Lab6
{
    class Array
    {
        public int[,] array;
        public Array (int n, int m)
        {
            array = new int[n, m];
        }
        public Array ()
        {
            array = new int[2, 2];
        }
        public int[,] RandomFill()
        {
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(-100, 100);
                }
            }
            return array;
        }

        public static void Output(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0,5}", array[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void IncSort()
        {
            for (int k = 0; k < array.GetLength(1); k++)
            {
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    double sum1 = 0;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        sum1 += array[i, j];
                    }
                    double sum2 = 0;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        sum2 += array[i, j - 1];
                    }
                    if (sum1 < sum2)
                    {
                        for (int i = 0; i < array.GetLength(0); i++)
                        {
                            (array[i, j - 1], array[i, j]) = (array[i, j], array[i, j - 1]);
                        }
                    }
                }

            }

        }
        public void DecSort()
        {
            for (int k = 0; k < array.GetLength(1); k++)
            {
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    double sum1 = 0;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        sum1 += array[i, j];
                    }
                    double sum2 = 0;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        sum2 += array[i, j - 1];
                    }
                    if (sum1 > sum2)
                    {
                        for (int i = 0; i < array.GetLength(0); i++)
                        {
                            (array[i, j - 1], array  [i, j]) = (array  [i, j], array[i, j - 1]);
                        }
                    }
                }

            }

        }
    }
}
