using System;


namespace Lab6
{
    class Sort
    {
        public int[] array;
        public Sort(int n)
        {
            array = new int[n];
        }
        public Sort()
        {
            array = new int[2];
        }
        public void Input()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Введите значение элемента массива: ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void Output()
        {
            foreach (int i in array)
            {
                Console.Write(i);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        static public void BubbleSort(int[] array)
        {
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
        }

        static public void ShellSort(int[] array)
        {
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
        }

        static public void InsertSort(int[] array)
        {
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
        }

        public static void ShakerSort(int[] arr)
        {
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
        }
    }
}