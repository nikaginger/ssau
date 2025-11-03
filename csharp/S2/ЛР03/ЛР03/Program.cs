using LR_3;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Xml.Serialization;

namespace LR_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №3. Полиморфизм");
            Console.WriteLine("Выполнила Бренева Вероника 6101-020302D\n");

            bool check = true;
            while (check == true)
            {
                check = MainMenu();
            }

            Console.ReadLine();
        }

        static bool MainMenu()
        {
            Console.WriteLine("1. Работа с классом ArrayVector");
            Console.WriteLine("2. Работа с классом LinkedListVector");
            Console.WriteLine("3. Сумма векторов РАЗНЫХ классов");
            Console.WriteLine("4. Скалярное произведение вектора (типа IVectorable)");
            Console.WriteLine("5. Получение модуля вектора (типа IVectorable)");
            Console.WriteLine("Любая другая кнопка - выход из программы");
            string choice = Console.ReadLine();

            bool check = true;
            if (choice == "1")
            {
                List<ArrayVector> vectors = new List<ArrayVector>();
                while (check)
                {
                    check = Menu1(vectors);
                }
            }
            else if (choice == "2")
            {
                while (check)
                {
                    check = Menu2();
                }
            }
            else if (choice == "3")
            {
                while (check)
                {
                    check = Menu3();
                }
            }
            else if (choice == "4")
            {
                while (check)
                {
                    check = Menu4();
                }
            }
            else if (choice == "5")
            {
                while (check)
                {
                    check = Menu5();
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        static bool Menu1(List<ArrayVector> vectors)
        {
            string choice;

            Console.WriteLine("Выберите пункт меню: ");
            Console.WriteLine("\t1. Создать вектор \n\t2. Изменить элемент вектора \n\t3. Получить модуль вектора");
            Console.WriteLine("\t4. Сумма двух векторов");
            Console.WriteLine("\t5. Скалярное произведение векторов");
            Console.WriteLine("\t6. Выйти в главное меню");
            VectorsInfo(vectors);

            Console.Write("Выбор: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    VectorCreate(vectors);
                    break;
                case "2":
                    VectorChange(vectors);
                    break;
                case "3":
                    VectorNorm(vectors);
                    break;
                case "4":
                    Sum(vectors);
                    break;
                case "5":
                    Pow(vectors);
                    break;
                default:
                    Console.Clear();
                    return false;
                    break;
            }
            Console.Clear();
            return true;
        }

        static bool Menu2()
        {
            string choice;
            int len = 0;
            bool check = true;

            bool parsed = false;
            while (!parsed)
            {
                Console.Write("Введите длину вектора: ");
                parsed = Int32.TryParse(Console.ReadLine(), out len);
            }
            LinkedListVector list = new LinkedListVector(len);

            for (int i = 0; i < len; i++)
            {
                parsed = false;
                while (!parsed)
                {
                    Console.Write("Введите элемент вектора с индексом {0}: ", i + 1);
                    int value;
                    parsed = Int32.TryParse(Console.ReadLine(), out value);
                    list[i] = value;
                }
            }
            Console.Clear();

            while (check)
            {
                Console.WriteLine(list.ToString());

                Console.WriteLine("Выберите пункт меню: ");
                Console.WriteLine("\t1. Узнать длину вектора \n\t2. Добавить элемент в начало");
                Console.WriteLine("\t3. Добавить элемент в конец");
                Console.WriteLine("\t4. Добавить элемент по индексу");
                Console.WriteLine("\t5. Удалить первый элемент");
                Console.WriteLine("\t6. Удалить последний элемент");
                Console.WriteLine("\t7. Удалить элемент по индексу");

                Console.Write("Выбор: ");
                choice = Console.ReadLine();
                int value = 0;
                int index = 0;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Длина вектора: {0}", list.GetNorm());
                        Console.ReadLine();
                        break;
                    case "2":
                        parsed = false;
                        while (!parsed)
                        {
                            Console.Write("Введите значение: ");
                            parsed = Int32.TryParse(Console.ReadLine(), out value);
                        }
                        list.AddTop(value);
                        break;
                    case "3":
                        parsed = false;
                        while (!parsed)
                        {
                            Console.Write("Введите значение: ");
                            parsed = Int32.TryParse(Console.ReadLine(), out value);
                        }
                        list.AddEnd(value);
                        break;
                    case "4":
                        parsed = false;
                        while (!parsed)
                        {
                            Console.Write("Введите индекс: ");
                            parsed = Int32.TryParse(Console.ReadLine(), out index);
                        }
                        parsed = false;
                        while (!parsed)
                        {
                            Console.Write("Введите значение: ");
                            parsed = Int32.TryParse(Console.ReadLine(), out value);
                        }
                        try
                        {
                            list.AddByIndex(index - 1, value);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Введён неверный индекс");
                            Console.ReadLine();
                        }
                        break;
                    case "5":
                        list.DeleteTop();
                        if (list.Length == -1) return false;
                        Console.Clear();
                        break;
                    case "6":
                        list.DeleteEnd();
                        if (list.Length == -1) return false;
                        Console.Clear();
                        break;
                    case "7":
                        parsed = false;
                        while (!parsed)
                        {
                            Console.Write("Введите индекс: ");
                            parsed = Int32.TryParse(Console.ReadLine(), out index);
                        }
                        try
                        {
                            list.DeleteByIndex(index);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Введён неверный индекс");
                            Console.ReadLine();
                        }
                        if (list.Length == -1) return false;
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        return false;
                        break;
                }
                Console.Clear();
            }
            return true;
        }

        static bool Menu3()
        {
            try
            {
                int len = 0;
                bool parsed = false;
                while (!parsed)
                {
                    Console.Write("Введите длину вектора 1 (типа ArrayVector): ");
                    parsed = Int32.TryParse(Console.ReadLine(), out len);
                }

                IVectorable vector1 = new ArrayVector(len);

                for (int i = 0; i < len; i++)
                {
                    Console.Write("Введите координату {0}: ", i + 1);
                    vector1[i] = Convert.ToInt32(Console.ReadLine());
                }
                parsed = false;
                while (!parsed)
                {
                    Console.Write("Введите длину вектора 2 (типа LinkedListVector): ");
                    parsed = Int32.TryParse(Console.ReadLine(), out len);
                }

                IVectorable vector2 = new LinkedListVector(len);

                for (int i = 0; i < len; i++)
                {
                    Console.Write("Введите координату {0}: ", i + 1);
                    vector2[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Вектор: " + Vectors.Sum(vector1, vector2).ToString());
                Console.ReadLine();
                Console.Clear();
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Вектора разных размерностей!");
                return false;
            }
        }

        static bool Menu5()
        { 
            Console.WriteLine("Выберите объект какого класса хотите создать: ");
            Console.WriteLine("1 - ArrayVector");
            Console.WriteLine("2 - LinkedListVector");
            string choice4 = Console.ReadLine();
            if (choice4 == "1")
            {
                int len = 0;
                bool parsed = false;
                while (!parsed)
                {
                    Console.Write("Введите длину вектора 1 (типа ArrayVector): ");
                    parsed = Int32.TryParse(Console.ReadLine(), out len);
                }

                IVectorable vector1 = new ArrayVector(len);

                for (int i = 0; i < len; i++)
                {
                    Console.Write("Введите координату {0}: ", i + 1);
                    vector1[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine(Vectors.GetNormSt(vector1));
            }
            else if (choice4 == "2")
            {
                int len = 0;
                bool parsed = false;
                while (!parsed)
                {
                    Console.Write("Введите длину вектора 2 (типа LinkedListVector): ");
                    parsed = Int32.TryParse(Console.ReadLine(), out len);
                }

                IVectorable vector1 = new LinkedListVector(len);

                for (int i = 0; i < len; i++)
                {
                    Console.Write("Введите координату {0}: ", i + 1);
                    vector1[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine(Vectors.GetNormSt(vector1));
            }
            else
            {
                Console.WriteLine("Выбран несуществующий вариант меню");
            }
            Console.ReadLine();
            Console.Clear();
            return false;
        }

        static bool Menu4()
        {
            try
            {
                int len = 0;
                bool parsed = false;
                while (!parsed)
                {
                    Console.Write("Введите длину вектора 1 (типа ArrayVector): ");
                    parsed = Int32.TryParse(Console.ReadLine(), out len);
                }

                IVectorable vector1 = new ArrayVector(len);

                for (int i = 0; i < len; i++)
                {
                    Console.Write("Введите координату {0}: ", i + 1);
                    vector1[i] = Convert.ToInt32(Console.ReadLine());
                }
                parsed = false;
                while (!parsed)
                {
                    Console.Write("Введите длину вектора 2 (типа LinkedListVector): ");
                    parsed = Int32.TryParse(Console.ReadLine(), out len);
                }

                IVectorable vector2 = new LinkedListVector(len);

                for (int i = 0; i < len; i++)
                {
                    Console.Write("Введите координату {0}: ", i + 1);
                    vector2[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Скалярное произведение векторов: " + Vectors.Scalar(vector1, vector2).ToString());
                Console.ReadLine();
                Console.Clear();
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Вектора разных размерностей!");
                return false;
            }
        }


        static void VectorCreate(List<ArrayVector> vectors)
        {
            int len;

            Console.Write("Введите размерность вектора: ");
            len = Convert.ToInt32(Console.ReadLine());
            ArrayVector vector = new ArrayVector(len);

            for (int i = 0; i < len; i++)
            {
                Console.Write("Введите координату {0}: ", i + 1);
                vector[i] = Convert.ToInt32(Console.ReadLine());
            }
            vectors.Add(vector);
        }

        static void VectorChange(List<ArrayVector> vectors)
        {
            try
            {

                int numV;
                int numE;
                int newValue;
                Console.Write("Введите номер вектора: ");
                numV = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Введите номер элемента: ");
                numE = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Введите новое значение: ");
                newValue = Convert.ToInt32(Console.ReadLine());
                vectors[numV][numE] = newValue;
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода");
            }
        }

        static void VectorNorm(List<ArrayVector> vectors)
        {
            int numV;
            Console.Write("Введите номер вектора: ");
            numV = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine(vectors[numV].GetNorm());
            Console.ReadLine();
        }

        static void Sum(List<ArrayVector> vectors)
        {
            int numV1, numV2;
            Console.Write("Введите номер первого вектора: ");
            numV1 = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Введите номер второго вектора: ");
            numV2 = Convert.ToInt32(Console.ReadLine()) - 1;
            try
            {
                vectors.Add((ArrayVector)Vectors.Sum(vectors[numV1], vectors[numV2]));
                Console.WriteLine("Полученный вектор добавлен в список");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Вектора должны быть одинаковой длины");
                Console.ReadLine();
            }
        }

        static void Pow(List<ArrayVector> vectors)
        {
            int numV1, numV2;
            Console.Write("Введите номер первого вектора: ");
            numV1 = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Введите номер второго вектора: ");
            numV2 = Convert.ToInt32(Console.ReadLine()) - 1;
            try
            {
                Console.WriteLine("Значение: {0}", Vectors.Scalar(vectors[numV1], vectors[numV2]));
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Вектора должны быть одинаковой длины");
                Console.ReadLine();
            }
        }

        static void VectorsInfo(List<ArrayVector> vectors)
        {
            Console.WriteLine("№ Размерность Координаты");
            for (int i = 0; i < vectors.Count; i++)
            {
                Console.Write("{0} {1}           ", i + 1, vectors[i].Length);
                for (int j = 0; j < vectors[i].Length; j++)
                {
                    Console.Write("{0} ", vectors[i][j]);
                }
                Console.WriteLine();
            }
        }

    }
}

