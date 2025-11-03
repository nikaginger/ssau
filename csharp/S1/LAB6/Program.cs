using System;


namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №6.Основы языка С#: Массивы");
            Console.WriteLine("Выполнила студентка группы 6101-020302D Бренева Вероника");
            Console.WriteLine("В рамках курса \"Основы программирования\"");

            bool check0 = true;
            string switcher0;
            while (check0)
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1 - Сортировка");
                Console.WriteLine("2 - Массивы");
                Console.WriteLine("3 - Ступенчатые массивы");
                Console.WriteLine("4 - Завершить работу программы");
                switcher0 = Console.ReadLine();
                Console.WriteLine();

                switch (switcher0)
                {
                    case "1": Task1(); break;
                    case "2": Task2(); break;
                    case "3": Task3(); break;
                    case "4": check0 = false; break;
                    default: Console.WriteLine("Такого варианта нет \n"); break;
                }
            }
            Console.ReadLine();
        }

        public static void Task1()
        {
            int n;
            Sort array;
            bool check1 = true;

            Console.WriteLine("Сортировка\n");

            while (check1)
            {
                Console.WriteLine("Выберите сортировку:");
                Console.WriteLine("1 - Сортировка пузырком");
                Console.WriteLine("2 - Сортировка Шелла");
                Console.WriteLine("3 - Шейкерная сортировка");
                Console.WriteLine("4 - Сортировка вставками");
                Console.WriteLine("5 - Вернуться к главному меню");

                Console.Write("Выбор: ");
                string switcher1 = Console.ReadLine();
                Console.WriteLine();
                switch (switcher1)
                {
                    case "1":
                        {
                            Console.WriteLine("Сортировка пузырком");
                            Console.Write("Введите длину массива: ");
                            n = Convert.ToInt32(Console.ReadLine());
                            array = new Sort(n);
                            array.Input();
                            Console.WriteLine("Исходный массив: ");
                            array.Output();
                            Sort.BubbleSort(array.array);
                            Console.WriteLine("Отсортированный массив: ");
                            array.Output();
                            Console.WriteLine();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Сортировка Шелла");
                            Console.Write("Введите длину массива: ");
                            n = Convert.ToInt32(Console.ReadLine());
                            array = new Sort(n);
                            array.Input();
                            Console.WriteLine("Исходный массив: ");
                            array.Output();
                            Sort.ShellSort(array.array);
                            Console.WriteLine("Отсортированный массив: ");
                            array.Output();
                            Console.WriteLine();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Шейкерная сортировка: ");
                            Console.Write("Введите длину массива: ");
                            n = Convert.ToInt32(Console.ReadLine());
                            array = new Sort(n);
                            array.Input();
                            Console.WriteLine("Исходный массив: ");
                            array.Output();
                            Sort.ShakerSort(array.array);
                            Console.WriteLine("Отсортированный массив: ");
                            array.Output();
                            Console.WriteLine();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Сортировка вставками: ");
                            Console.Write("Введите длину массива: ");
                            n = Convert.ToInt32(Console.ReadLine());
                            array = new Sort(n);
                            array.Input();
                            Console.WriteLine("Исходный массив: ");
                            array.Output();
                            Sort.InsertSort(array.array);
                            Console.WriteLine("Отсортированный массив: ");
                            array.Output();
                            Console.WriteLine();
                            break;
                        }
                    case "5": 
                        check1 = false; 
                        break;
                    default: 
                        Console.WriteLine("Такого варианта нет \n"); 
                        break;
                }
            }
        }

        public static void Task2()
        {
            int n, m;
            Array array;

            Console.WriteLine("Массивы\n");

            Console.Write("Введите количество строчек массива: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов массива: ");
            m = Convert.ToInt32(Console.ReadLine());
            array = new Array(n, m);
            Console.WriteLine("Массив, заполненный случайными значениями:\n");
            array.RandomFill();
            Array.Output(array.array);
            Console.WriteLine("Отсортированный по возрастанию сумм элементов столбцов массив:\n");
            array.IncSort();
            Array.Output(array.array);
            Console.WriteLine("Отсортированный по убыванию сумм элементов столбцов массив:\n");
            array.DecSort();
            Array.Output(array.array);

            Console.WriteLine("\nлюбая кнопка - выход в главное меню");
            Console.ReadLine();

        }

        public static void Task3()
        {
            int n;
            SteppedArray array;


            Console.WriteLine("Ступенчатый массив\n");

            Console.Write("Введите количество строчек массива: ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nЗаполните массив:");
            array = new SteppedArray(n);
            SteppedArray.Input(array.array);

            SteppedArray.SteppedArraySort(array.array);
            Console.WriteLine("Отсортированный ступенчатый массив:");
            SteppedArray.Output(array.array);

            Console.WriteLine("\nлюбая кнопка - выход в главное меню");
            Console.ReadLine();
        }
    }
}