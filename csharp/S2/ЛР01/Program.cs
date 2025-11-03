using System;
using System.Collections.Generic;


namespace LR_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №1 «Основы языка С#: Классы. Повторение»");
            Console.WriteLine("Выполнила студент Бренева Вероника 6101-020302D\n");

            List<ArrayVector> vectors = new List<ArrayVector>();
            bool check = true;
            while (check)
            {
                check = Menu(vectors);
                Console.ReadKey();
            }

            Console.Read();
        }
        static bool Menu(List<ArrayVector> vectors)
        {
            Console.Clear();
            string choice;

            Console.WriteLine("Выберите пункт меню: ");
            Console.WriteLine("\t1. Создать вектор");
            Console.WriteLine("\t2. Изменить элемент вектора");
            Console.WriteLine("\t3. Получить модуль вектора");
            Console.WriteLine("\t4. Сумма всех положительных элементов с чётными номерами");
            Console.WriteLine("\t5. Сумма всех элементов, которые меньше среднего значения модулей вектора и имеют нечётные номера");
            Console.WriteLine("\t6. Произведение всех чётных положительных элементов вектора");
            Console.WriteLine("\t7. Произведение всех нечётных элементов, не делящихся на 3");
            Console.WriteLine("\t8. Сортировка элементов вектора по возрастанию");
            Console.WriteLine("\t9. Сортировка элементов вектора по убыванию");
            Console.WriteLine("\t10. Сумма двух векторов");
            Console.WriteLine("\t11. Скалярное произведение векторов");
            Console.WriteLine("\t12. Умножение вектора на число");
            Console.WriteLine("\t13. Завершить программу");
            VectorsInfo(vectors);

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
                    Condition1(vectors);
                    break;
                case "5":
                    Condition2(vectors);
                    break;
                case "6":
                    Condition3(vectors);
                    break;
                case "7":
                    Condition4(vectors);
                    break;
                case "8":
                    SortU(vectors);
                    break;
                case "9":
                    SortD(vectors);
                    break;
                case "10":
                    Sum(vectors);
                    break;
                case "11":
                    Pow(vectors);
                    break;
                case "12":
                    MultNum(vectors);
                    break;
                default:
                    return false;
                    break;
            }

            return true;
        }


        static void VectorCreate(List<ArrayVector> vectors)
        {
            int n;

            Console.Write("Введите размерность вектора: ");
            n = Convert.ToInt32(Console.ReadLine());
            ArrayVector vector = new ArrayVector(n);

            for (int i = 0; i < n; i++)
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
                int vectorNum;
                int ElementNum;
                int newValue;
                Console.Write("Введите номер вектора: ");
                vectorNum = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Введите номер элемента: ");
                ElementNum = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Введите новое значение: ");
                newValue = Convert.ToInt32(Console.ReadLine());
                vectors[vectorNum][ElementNum] = newValue;
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода");
            }
        }

        static void VectorNorm(List<ArrayVector> vectors)
        {
            int vectorNum;
            Console.Write("Введите номер вектора: ");
            vectorNum = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine(vectors[vectorNum].GetNorm());
            Console.ReadLine();
        }

        static void Condition1(List<ArrayVector> vectors)
        {
            int vectorNum;
            Console.Write("Введите номер вектора: ");
            vectorNum = Convert.ToInt32(Console.ReadLine()) - 1;
            if (vectors[vectorNum].SumPositivesFromChetIndex() != 0)
            {
                Console.WriteLine("Результат: {0}", vectors[vectorNum].SumPositivesFromChetIndex());
            }
            else
            {
                Console.WriteLine("Таких элементов нет");
            }
            Console.ReadLine();
        }

        static void Condition2(List<ArrayVector> vectors)
        {
            int vectorNum;
            Console.Write("Введите номер вектора: ");
            vectorNum = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Результат: {0}", vectors[vectorNum].SumLessFromNechetIndex());
            Console.ReadLine();
        }

        static void Condition3(List<ArrayVector> vectors)
        {
            int vectorNum;
            Console.Write("Введите номер вектора: ");
            vectorNum = Convert.ToInt32(Console.ReadLine()) - 1;
            if (vectors[vectorNum].MultChet() != 1)
            {
                Console.WriteLine("Результат: {0}", vectors[vectorNum].MultChet());
            }
            else
            {
                Console.WriteLine("Таких элементов нет");
            }
            Console.ReadLine();
        }

        static void Condition4(List<ArrayVector> vectors)
        {
            int numV;
            Console.Write("Введите номер вектора: ");
            numV = Convert.ToInt32(Console.ReadLine()) - 1;
            if (vectors[numV].MultNechet() != 1)
            {
                Console.WriteLine("Результат: {0}", vectors[numV].MultNechet());
            }
            else
            {
                Console.WriteLine("Таких элементов нет");
            }
            Console.ReadLine();
        }

        static void SortU(List<ArrayVector> vectors)
        {
            int numV;
            Console.Write("Введите номер вектора: ");
            numV = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Значения отсортированы");
            vectors[numV].SortUp();
        }

        static void SortD(List<ArrayVector> vectors)
        {
            int numV;
            Console.Write("Введите номер вектора: ");
            numV = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Значения отсортированы");
            vectors[numV].SortDown();
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
                vectors.Add(Vectors.Sum(vectors[numV1], vectors[numV2]));
                Console.WriteLine("Полученный вектор добавлен в список");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Вектора должны быть одинаковой длины");
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
            }
        }

        static void MultNum(List<ArrayVector> vectors)
        {
            int numV1, num;
            Console.Write("Введите номер первого вектора: ");
            numV1 = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Введите число: ");
            num = Convert.ToInt32(Console.ReadLine());
            vectors.Add(Vectors.MultNumber(vectors[numV1], num));
            Console.WriteLine("Полученный вектор добавлен в список");
            Console.ReadLine();
        }

        static void VectorsInfo(List<ArrayVector> vectors)
        {
            Console.WriteLine("Список векторов: ");
            Console.WriteLine("Вектор \t Размерность \t Координаты \t");
            for (int i = 0; i < vectors.Count; i++)
            {
                Console.Write("{0} \t {1}               ", i + 1, vectors[i].ArrayVectorLength());
                for (int j = 0; j < vectors[i].ArrayVectorLength(); j++)
                {
                    Console.Write("{0} ", vectors[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}