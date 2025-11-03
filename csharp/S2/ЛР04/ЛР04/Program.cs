using System;
using System.Collections.Generic;

namespace LR_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №4");
            Console.WriteLine("Выполнила студентка Бренева Вероника 6101-020302D\n");

            List<IVectorable> vectors = new List<IVectorable>();
            bool flag = true;
            while (flag)
            {
                flag = MainMenu(vectors);
            }

            Console.ReadKey();
        }

        static bool MainMenu(List<IVectorable> vectors)
        {
            string choice;
            if (vectors.Count > 0)
            {
                Console.WriteLine("Список векторов:");
                VectorsInfo(vectors);
                Console.WriteLine();
            }
            Console.WriteLine("Выберите пункт меню: ");
            Console.WriteLine("1 - Создать вектор ArrayVecor");
            Console.WriteLine("2 - Создать вектор LinkedList");
            Console.WriteLine("3 - Клонировать вектор");
            Console.WriteLine("4 - Редактировать вектор");
            Console.WriteLine("5 - Высчитать модуль вектора");
            Console.WriteLine("6 - Проверить вектора на равенство");
            Console.WriteLine("7 - Сумма двух векторов");
            Console.WriteLine("8 - Скалярное произведение двух векторов");
            Console.WriteLine("9 - Вывести вектора с максимальным и минимальным количеством координат");
            Console.WriteLine("10 - Отсортировать вектора по количеству координат");
            Console.WriteLine("11 - Отсортировать вектора по модулю");
            Console.WriteLine("12 - Удалить вектор");
            Console.WriteLine("любая другая кнопка - Завершить программу");


            Console.Write("Выбор: ");
            choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateArrayVector(vectors);
                    break;
                case "2":
                    CreateLinkedListVector(vectors);
                    break;
                case "3":
                    CloneVector(vectors);
                    break;
                case "4":
                    int num;
                    OutputInput("Введите номер вектора: ", out num);
                    try
                    {
                        if (vectors[num - 1].GetType() == typeof(ArrayVector)) EditArrayVector((ArrayVector)vectors[num - 1], num);
                        else EditLinkedList((LinkedListVector)vectors[num - 1], num, vectors);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Введён неверный номер");
                        Console.ReadKey();
                    }
                    break;
                case "5":
                    VectorNorm(vectors);
                    break;
                case "6":
                    IsEquals(vectors);
                    break;
                case "7":
                    Sum(vectors);
                    break;
                case "8":
                    Mult(vectors);
                    break;
                case "9":
                    MinMaxLength(vectors);
                    break;
                case "10":
                    SortByLength(vectors);
                    break;
                case "11":
                    SortByNorm(vectors);
                    break;
                case "12":
                    Delete(vectors);
                    break;
                default:
                    return false;
            }
            Console.Clear();
            return true;
        }

        static void CreateArrayVector(List<IVectorable> vectors)
        {
            int len;
            int value;

            try
            {
                OutputInput("Введите размерность вектора: ", out len);
                ArrayVector vector = new ArrayVector(len);

                for (int i = 0; i < len; i++)
                {
                    string messege = String.Format("Введите координату {0}: ", i + 1);
                    OutputInput(messege, out value);
                    vector[i] = value;
                }
                vectors.Add(vector);
            }
            catch
            {
                Console.WriteLine("Размерность должна быть положительной");
                Console.ReadKey();
            }
        }

        static void CreateLinkedListVector(List<IVectorable> vectors)
        {
            int len;
            int value;

            try
            {
                OutputInput("Введите размерность вектора: ", out len);
                LinkedListVector vector = new LinkedListVector(len);

                for (int i = 0; i < len; i++)
                {
                    string messege = String.Format("Введите координату {0}: ", i + 1);
                    OutputInput(messege, out value);
                    vector[i] = value;
                }
                vectors.Add(vector);
            }
            catch
            {
                Console.WriteLine("Размерность должна быть положительной");
                Console.ReadKey();
            }
        }

        static void CloneVector(List<IVectorable> vectors)
        {
            int numV;
            OutputInput("Введите номер вектора, который хотите клонировать: ", out numV);
            try
            {
                if (vectors[numV - 1] is ArrayVector)
                {
                    vectors.Add((IVectorable)((ArrayVector)vectors[numV - 1]).Clone());
                }
                else
                {
                    vectors.Add((IVectorable)((LinkedListVector)vectors[numV - 1]).Clone());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Введён неверный номер");
            }
        }

        static void EditArrayVector(ArrayVector vector, int numV)
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Редактируемый вектор:");
                Console.WriteLine("{0, -5}{1, -7}{2, -15}{3}", "№", "Тип", "Размерность", "Координаты");
                Console.WriteLine("{0, -5}{1, -7}{2}", numV, "Arr", vector.ToString());
                Console.WriteLine();

                try
                {
                    int num;
                    int newValue;
                    Console.Write("Введите номер элемента или нажмите Enter, чтобы звершить редактирование: ");
                    flag = Int32.TryParse(Console.ReadLine(), out num);
                    if (flag)
                    {
                        OutputInput("Введите новое значение: ", out newValue);
                        vector[num - 1] = newValue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введён недопустимый номер элемента");
                    Console.ReadKey();
                }
            }
        }

        static void EditLinkedList(LinkedListVector vector, int numV, List<IVectorable> vectors)
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Редактируемый вектор:");
                Console.WriteLine("{0, -5}{1, -7}{2, -15}{3}", "№", "Тип", "Размерность", "Координаты");
                Console.WriteLine("{0, -5}{1, -7}{2}", numV, "List", vector.ToString());
                Console.WriteLine();

                Console.WriteLine("Введите номер элемента или нажмите Enter, чтобы звершить редактирование: ");
                Console.WriteLine("1 - Изменить элемент по номеру");
                Console.WriteLine("2 - Добавить элемент в начало");
                Console.WriteLine("3 - Добавить элемент в конец");
                Console.WriteLine("4 - Добавить элемент по номеру");
                Console.WriteLine("5 - Удалить первый элемент");
                Console.WriteLine("6 - Удалить последний элемент");
                Console.WriteLine("7 - Удалить элемент по номеру");

                Console.Write("Выбор: ");
                string choice = Console.ReadLine();
                int value = 0;
                int index = 0;

                switch (choice)
                {
                    case "1":
                        OutputInput("Ведите номер: ", out index);
                        OutputInput("Ведите значение: ", out value);
                        try
                        {
                            vector[index - 1] = value;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Введён неверный номер");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        OutputInput("Ведите значение: ", out value);
                        vector.AddTop(value);
                        break;
                    case "3":
                        OutputInput("Ведите значение: ", out value);
                        vector.AddEnd(value);
                        break;
                    case "4":
                        OutputInput("Ведите номер: ", out index);
                        OutputInput("Ведите значение: ", out value);
                        try
                        {
                            vector.AddByIndex(index - 1, value);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Введён неверный номер");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        vector.DeleteTop();
                        if (vector.Length == 0)
                        {
                            vectors.Remove(vector);
                            flag = false;
                        }
                        break;
                    case "6":
                        vector.DeleteEnd();
                        if (vector.Length == 0)
                        {
                            vectors.Remove(vector);
                            flag = false;
                        }
                        break;
                    case "7":
                        OutputInput("Ведите номер: ", out index);
                        try
                        {
                            vector.DeleteByIndex(index - 1);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Введён неверный номер");
                            Console.ReadKey();
                        }
                        if (vector.Length == 0)
                        {
                            vectors.Remove(vector);
                            flag = false;
                        }
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }

        static void VectorNorm(List<IVectorable> vectors)
        {
            int numV;
            OutputInput("Введите номер вектора: ", out numV);
            try
            {
                Console.WriteLine("Модуль вектора №{0}: {1}", numV, vectors[numV - 1].GetNorm());
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Введён неверный номер");
                Console.ReadKey();
            }
        }

        static void IsEquals(List<IVectorable> vectors)
        {
            int numV1, numV2;
            OutputInput("Введите номер первого вектора: ", out numV1);
            OutputInput("Введите номер второго вектора: ", out numV2);
            try
            {
                if (vectors[numV1 - 1].Equals(vectors[numV2 - 1]))
                {
                    Console.WriteLine("Вектора равны");
                }
                else
                {
                    Console.WriteLine("Вектора не равны");
                }
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Введён неверный номер");
                Console.ReadKey();
            }
        }

        static void Sum(List<IVectorable> vectors)
        {
            int numV1, numV2;
            OutputInput("Введите номер первого вектора: ", out numV1);
            OutputInput("Введите номер второго вектора: ", out numV2);
            try
            {
                vectors.Add(Vectors.Sum(vectors[numV1 - 1], vectors[numV2 - 1]));
                Console.WriteLine("Полученный вектор добавлен в список");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Вектора должны быть одинаковой длины");
                Console.ReadKey();
            }
        }

        static void Mult(List<IVectorable> vectors)
        {
            int numV1, numV2;
            OutputInput("Введите номер первого вектора: ", out numV1);
            OutputInput("Введите номер второго вектора: ", out numV2);
            try
            {
                Console.WriteLine("Значение: {0}", Vectors.Scalar(vectors[numV1 - 1], vectors[numV2 - 1]));
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Вектора должны быть одинаковой длины");
                Console.ReadKey();
            }
        }

        static void MinMaxLength(List<IVectorable> vectors)
        {
            try
            {
                int minL = vectors[0].Length;
                int maxL = vectors[0].Length;
                for (int i = 0; i < vectors.Count; i++)
                {
                    if (minL > vectors[i].Length)
                    {
                        minL = vectors[i].Length;
                    }
                    if (maxL < vectors[i].Length)
                    {
                        maxL = vectors[i].Length;
                    }
                }
                string type;
                Console.WriteLine("Вектора с минимальным количеством координат:");
                Console.WriteLine("{0, -7}{1, -15}{2}", "Тип", "Размерность", "Координаты");
                for (int i = 0; i < vectors.Count; i++)
                {
                    if (vectors[i].Length == minL)
                    {
                        if (vectors[i].GetType() == typeof(ArrayVector)) type = "Array";
                        else type = "List";
                        Console.WriteLine("{0, -7}{1}", type, vectors[i].ToString());
                    }
                }
                Console.WriteLine("Вектора с максимальным количеством координат:");
                Console.WriteLine("{0, -7}{1, -15}{2}", "Тип", "Размерность", "Координаты");
                for (int i = 0; i < vectors.Count; i++)
                {
                    if (vectors[i].Length == maxL)
                    {
                        if (vectors[i].GetType() == typeof(ArrayVector)) type = "Array";
                        else type = "List";
                        Console.WriteLine("{0, -7}{1}", type, vectors[i].ToString());
                    }
                }
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Нет векторов для вывода");
                Console.ReadKey();
            }
        }

        static void SortByLength(List<IVectorable> vectors)
        {
            IVectorable temp;
            for (int i = 0; i < vectors.Count; i++)
            {
                for (int j = 0; j < vectors.Count - 1 - i; j++)
                {
                    if (((IComparable)vectors[j]).CompareTo((IComparable)vectors[j+1]) > 0)
                    {
                        temp = vectors[j];
                        vectors[j] = vectors[j + 1];
                        vectors[j + 1] = temp;
                    }
                }
            }
        }

        static void SortByNorm(List<IVectorable> vectors)
        {
            IVectorable temp;
            VectorsComparer comparer = new VectorsComparer();
            for (int i = 0; i < vectors.Count; i++)
            {
                for (int j = 0; j < vectors.Count - 1 - i; j++)
                {
                    if (comparer.Compare(vectors[j], vectors[j + 1]) > 0)
                    {
                        temp = vectors[j];
                        vectors[j] = vectors[j + 1];
                        vectors[j + 1] = temp;
                    }
                }
            }
        }

        static void Delete(List<IVectorable> vectors)
        {
            int num;
            OutputInput("Введите номер вектора: ", out num);
            try
            {
                vectors.RemoveAt(num - 1);
            }
            catch (Exception)
            {
                Console.WriteLine("Введён неверный номер");
                Console.ReadKey();
            }
        }

        static void VectorsInfo(List<IVectorable> vectors)
        {
            Console.WriteLine("{0, -5}{1, -7}{2}", "№", "Тип", "Вектор");
            string type;
            for (int i = 0; i < vectors.Count; i++)
            {
                if (vectors[i].GetType() == typeof(ArrayVector)) type = "Array";
                else type = "List";
                Console.WriteLine("{0, -5}{1, -7}{2}", i + 1, type, vectors[i].ToString());
            }
        }

        static void OutputInput(string output, out int input)
        {
            bool inputCompleted = false;
            do
            {
                Console.Write(output);
                inputCompleted = Int32.TryParse(Console.ReadLine(), out input);
                if (!inputCompleted)
                {
                    Console.WriteLine("\nВведённые данные некорректны, повторите ввод\n");
                }
            } while (!inputCompleted);
        }
    }
}

