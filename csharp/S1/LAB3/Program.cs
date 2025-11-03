using System;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №3.Основы языка С#: Программы с использованием циклов - 2");
            Console.WriteLine("Выполнила студентка группы 6101-020302D Бренева Вероника");

            bool check0 = true;
            while (check0)
            {
                Console.WriteLine("Задание: Действия с матрицами и перевод систем счисления.");
                Console.WriteLine("Выберите задание:");
                Console.WriteLine("1. Действия с матрицами");
                Console.WriteLine("2. Перевод из двоичной системы счисления в десятичную");
                string switcher0 = Console.ReadLine();
                switch (switcher0)
                {
                    case "1":
                        {
                            bool check1 = true;
                            while (check1)
                            {
                                string switcher3 = "";
                                Console.WriteLine("Введите количество строк первой матрицы: ");
                                int n1 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите количество столбцов первой матрицы: ");
                                int n2 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите количество строк второй матрицы: ");
                                int m1 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите количество столбцов второй матрицы: ");
                                int m2 = Convert.ToInt32(Console.ReadLine());
                                
                                if ((n1 != m1) || (n2 != m2))
                                {
                                    if (n2 == m1)
                                    {

                                        Console.WriteLine("Для данных матриц можно выполнить только умножение.");
                                        switcher3 = "3";
                                        Console.WriteLine("Ввод матриц:");
                                        Console.WriteLine("Введите первую матрицу:");
                                        int[,] arr1 = new int[n1, n2];
                                        for (int i = 0; i < n1; i++)
                                        {
                                            for (int j = 0; j < n2; j++)
                                            {
                                                Console.WriteLine("Введите элемент a[{0},{1}]", i + 1, j + 1);
                                                arr1[i, j] = Convert.ToInt32(Console.ReadLine());
                                            }
                                        }
                                        Console.WriteLine("Первая матрица:");
                                        for (int i = 0; i < n1; i++)
                                        {
                                            for (int j = 0; j < n2; j++)
                                            {
                                                Console.Write(arr1[i, j] + "\t");
                                            }
                                            Console.WriteLine();
                                        }
                                        Console.WriteLine("Введите вторую матрицу:");
                                        int[,] arr2 = new int[m1, m2];
                                        for (int i = 0; i < m1; i++)
                                        {
                                            for (int j = 0; j < m2; j++)
                                            {
                                                Console.WriteLine("Введите элемент a[{0},{1}]", i + 1, j + 1);
                                                arr2[i, j] = Convert.ToInt32(Console.ReadLine());
                                            }
                                        }
                                        Console.WriteLine("Вторая матрица:");
                                        for (int i = 0; i < m1; i++)
                                        {
                                            for (int j = 0; j < m2; j++)
                                            {
                                                Console.Write(arr2[i, j] + "\t");
                                            }
                                            Console.WriteLine();
                                        }
                                        int[,] arr3 = new int[n1, m2];
                                        for (int i = 0; i < n1; i++)
                                        {
                                            for (int j = 0; j < m2; j++)
                                            {
                                                arr3[i, j] = 0;
                                                for (int k = 0; k < n2; k++)
                                                {
                                                    arr3[i, j] += arr1[i, k] * arr2[k, j];
                                                }
                                            }
                                            Console.WriteLine();
                                        }
                                        Console.WriteLine("Первая матрица: ");
                                        for (int i = 0; i < n1; i++)
                                        {
                                            for (int j = 0; j < n2; j++)
                                            {
                                                Console.Write(arr1[i, j] + "\t");
                                            }
                                            Console.WriteLine();
                                        }
                                        Console.WriteLine("Вторая матрица: ");
                                        for (int i = 0; i < m1; i++)
                                        {
                                            for (int j = 0; j < m2; j++)
                                            {
                                                Console.Write(arr2[i, j] + "\t");
                                            }
                                            Console.WriteLine();
                                        }
                                        Console.WriteLine("Итоговая матрица в результате умножения: ");
                                        for (int i = 0; i < n1; i++)
                                        {
                                            for (int j = 0; j < m2; j++)
                                            {
                                                Console.Write(arr3[i, j] + "\t");
                                            }
                                            Console.WriteLine();
                                        }
         
                                    }
                                    else
                                    {
                                        Console.WriteLine("Вычисление невозможно из-за разных размерностей. Хотите повторить?");
                                        Console.WriteLine("Введите 1, чтобы повторить, любую цифру, чтобы завершить первое задание");
                                        string switcher1 = Console.ReadLine();
                                        switch (switcher1)
                                        {
                                            case "1":
                                                break;
                                            default:
                                                {
                                                    check1 = false;
                                                    break;
                                                }
                                        }
                                    }
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Ввод матриц:");
                                    Console.WriteLine("Введите первую матрицу:");
                                    int[,] arr1 = new int[n1, n2];
                                    for (int i = 0; i < n1; i++)
                                    {
                                        for (int j = 0; j < n2; j++)
                                        {
                                            Console.WriteLine("Введите элемент a[{0},{1}]", i + 1, j + 1);
                                            arr1[i, j] = Convert.ToInt32(Console.ReadLine());
                                        }
                                    }
                                    Console.WriteLine("Первая матрица:");
                                    for (int i = 0; i < n1; i++)
                                    {
                                        for (int j = 0; j < n2; j++)
                                        {
                                            Console.Write(arr1[i, j] + "\t");
                                        }
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine("Введите вторую матрицу:");
                                    int[,] arr2 = new int[m1, m2];
                                    for (int i = 0; i < m1; i++)
                                    {
                                        for (int j = 0; j < m2; j++)
                                        {
                                            Console.WriteLine("Введите элемент a[{0},{1}]", i + 1, j + 1);
                                            arr2[i, j] = Convert.ToInt32(Console.ReadLine());
                                        }
                                    }
                                    Console.WriteLine("Вторая матрица:");
                                    for (int i = 0; i < m1; i++)
                                    {
                                        for (int j = 0; j < m2; j++)
                                        {
                                            Console.Write(arr2[i, j] + "\t");
                                        }
                                        Console.WriteLine();
                                    }
                                    int[,] arr3 = new int[n1, m2];
                                    bool check2 = true;
                                    while (check2)
                                    {
                                        if (switcher3 != "3")
                                        {
                                            Console.WriteLine("Выберите действие:");
                                            Console.WriteLine("1. Сложение матриц");
                                            Console.WriteLine("2. Вычитание матриц");
                                            Console.WriteLine("3. Умножение матриц");
                                            Console.WriteLine("4. Умножение матрицы на число (невозможно для прямоугольных матриц) ");
                                            Console.WriteLine("5. Сравнить матрицы на равенство");
                                            Console.WriteLine("Другое число - выход в главное меню");
                                            switcher3 = Console.ReadLine();
                                        }
                                        switch (switcher3)
                                        {
                                            case "1":
                                                {
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            arr3[i, j] = arr1[i, j] + arr2[i, j];
                                                        }
                                                        Console.WriteLine();
                                                    }

                                                    Console.WriteLine("Первая матрица: ");
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            Console.Write(arr1[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Вторая матрица: ");
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            Console.Write(arr2[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Итоговая матрица в результате сложения: ");
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            Console.Write(arr3[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Введите 1 если хотите продолжить");
                                                    string key1 = Console.ReadLine();
                                                    if (key1 != "1")
                                                    {
                                                        check2 = false;
                                                    }
                                                    else
                                                    {
                                                        check1 = false;
                                                    }
                                                    break;
                                                }
                                            case "2":
                                                {
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            arr3[i, j] = arr1[i, j] - arr2[i, j];
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Первая матрица: ");
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            Console.Write(arr1[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Вторая матрица: ");
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            Console.Write(arr2[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Итоговая матрица в результате вычитания: ");
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            Console.Write(arr3[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Введите 1 если хотите продолжить");
                                                    string key1 = Console.ReadLine();
                                                    if (key1 != "1")
                                                    {
                                                        check2 = false;
                                                    }
                                                    break;
                                                }
                                            case "3":
                                                {
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < m2; j++)
                                                        {
                                                            arr3[i, j] = 0;
                                                            for (int k = 0; k < n2; k++)
                                                            {
                                                                arr3[i, j] += arr1[i, k] * arr2[k, j];
                                                            }
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Первая матрица: ");
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            Console.Write(arr1[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Вторая матрица: ");
                                                    for (int i = 0; i < m1; i++)
                                                    {
                                                        for (int j = 0; j < m2; j++)
                                                        {
                                                            Console.Write(arr2[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Итоговая матрица в результате умножения: ");
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            Console.Write(arr3[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Введите 1 если хотите продолжить");
                                                    string key1 = Console.ReadLine();
                                                    if (key1 != "1")
                                                        check2 = false;
                                                    break;
                                                }
                                            case "4":
                                                {
                                                    Console.WriteLine("Первая матрица: ");
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            Console.Write(arr1[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Вторая матрица: ");
                                                    for (int i = 0; i < m1; i++)
                                                    {
                                                        for (int j = 0; j < m2; j++)
                                                        {
                                                            Console.Write(arr2[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Какую матрицу будем умножать?");
                                                    int choose = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine("Введите число на которое хотите умножить:");
                                                    int multiplier = Convert.ToInt32(Console.ReadLine());
                                                    if (choose == 1)
                                                    {
                                                        for (int i = 0; i < n1; i++)
                                                        {
                                                            for (int j = 0; j < n2; j++)
                                                            {
                                                                arr3[i, j] = arr1[i, j] * multiplier;
                                                            }
                                                            Console.WriteLine();
                                                        }
                                                    }
                                                    else if (choose == 2)
                                                    {
                                                        for (int i = 0; i < n1; i++)
                                                        {
                                                            for (int j = 0; j < n2; j++)
                                                            {
                                                                arr3[i, j] = arr2[i, j] * multiplier;
                                                            }
                                                            Console.WriteLine();
                                                        }
                                                    }
                                                    Console.WriteLine("Итоговая матрица в результате умножения на число: ");
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            Console.Write(arr3[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Введите 1 если хотите продолжить");
                                                    string key1 = Console.ReadLine();
                                                    if (key1 != "1")
                                                    {
                                                        check2 = false;
                                                    }
                                                    break;
                                                }
                                            case "5":
                                                {
                                                    Console.WriteLine("Первая матрица: ");
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            Console.Write(arr1[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    Console.WriteLine("Вторая матрица: ");
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            Console.Write(arr2[i, j] + "\t");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    for (int i = 0; i < n1; i++)
                                                    {
                                                        for (int j = 0; j < n2; j++)
                                                        {
                                                            if (arr1[i, j] != arr2[i, j])
                                                            {
                                                                Console.WriteLine("Матрицы не равны");
                                                                Console.WriteLine("Введите 1 если хотите продолжить");
                                                                string key1 = Console.ReadLine();
                                                                if (key1 != "1")
                                                                    check2 = false;
                                                                break;

                                                            }
                                                        }
                                                    }
                                                    Console.WriteLine("Матрицы равны");
                                                    Console.WriteLine("Введите 1 если хотите продолжить");
                                                    string key2 = Console.ReadLine();
                                                    if (key2 != "1")
                                                    {
                                                        check2 = false;
                                                    }
                                                    break;
                                                }
                                            default:
                                                {
                                                    check2 = false;
                                                    break;
                                                }
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    case "2":
                        {
                            {
                                bool ender1 = true;
                                while (ender1)
                                {
                                    int count = 0;
                                    double res = 0;
                                    Console.Write("Введите изначальное число: ");
                                    int n = Convert.ToInt32(Console.ReadLine());
                                    int x = n;
                                    while (n > 0)
                                    {
                                        n /= 2;
                                        count++;
                                    }
                                    n = x;
                                    if (count < 9)
                                    {
                                        count = 9;
                                    }
                                    int[] arr = new int[count];
                                    int i = 0;
                                    while (n > 0)
                                    {
                                        arr[i] = n % 2;
                                        n /= 2;
                                        i++;
                                    }
                                    if (i < 8)
                                    {
                                        i++;
                                        while (count - i != 0)
                                        {
                                            arr[i] = 0;
                                            i++;
                                        }
                                    }
                                    // реверс массива
                                    for (int j = 0; j < arr.Length / 2; j++)
                                    {
                                        int v = arr[j];
                                        arr[j] = arr[arr.Length - (j + 1)];
                                        arr[arr.Length - (j + 1)] = v;
                                    }
                                    Console.WriteLine("Число в десятичной системе счисления: {0}", x);
                                    Console.Write("Число в двоичной системе счисления: ");
                                    for (int k = 0; k < arr.Length; k++)
                                        Console.Write(arr[k]);
                                    for (int k = 0; k < 3; k++)
                                    {
                                        int v = arr[count - k - 1];
                                        arr[count - k - 1] = arr[count - k - 7];
                                        arr[count - k - 7] = v;

                                    }
                                    for (int k = 0; k < arr.Length; k++)
                                    {
                                        if (arr[k] == 1)
                                        {
                                            res += Math.Pow(2, arr.Length - (k + 1));
                                        }
                                    }
                                    Console.WriteLine("\nПолученное число после смены триад в десятичной системе = {0}", Convert.ToInt32(res));
                                    Console.Write("Полученное число после смены триад в двоичной системе счисления: ");
                                    for (int k = 0; k < arr.Length; k++)
                                        Console.Write(arr[k]);
                                    Console.WriteLine();
                                    Console.WriteLine("Хотите продолжить это задание? 1 - Да, Другое число - Нет ");
                                    int ender2 = Convert.ToInt32(Console.ReadLine());
                                    if (ender2 == 1)
                                    {
                                        ender1 = true;
                                    }
                                    else
                                    {
                                        ender1 = false;
                                    }
                                }
                                break;
                            }
                        }
                    default:
                        {
                            Console.WriteLine("Такого задания нет. Хотите продолжить?");
                            Console.WriteLine("Введите 1, чтобы повторить, любую цифру, чтобы завершить.");
                            string switcher_err = Console.ReadLine();
                            switch (switcher_err)
                            {
                                case "1":
                                    break;
                                default:
                                    {
                                        check0 = false;
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
        }
    }
}