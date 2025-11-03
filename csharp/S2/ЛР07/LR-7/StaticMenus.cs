using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LR_7
{

    class StaticMenus
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Лабораторная работа №5");
        //    Console.WriteLine("Выполнила студентка Бренева Вероника 6101-020302D\n");

        //    List<IVectorable> vectors = new List<IVectorable>();
        //    bool flag = true;
        //    while (flag)
        //    {
        //        flag = MainMenu(vectors);
        //    }

        //    Console.ReadKey();
        //}
        static bool MainMenu(List<IVectorable> vectors)
        {
            string choice;
            if (vectors.Count > 0)
            {
                Console.WriteLine("Список векторов:");
                VectorsInfo(vectors);
                Console.WriteLine();
            }

            string textMainMenu = "Выберите пункт меню: \n " +
                "1 - Создать вектор ArrayVecor \n" +
                "2 - Создать вектор LinkedList \n" +
                "3 - Клонировать вектор \n" +
                "4 - Редактировать вектор \n" +
                "5 - Высчитать модуль вектора \n" +
                "6 - Проверить вектора на равенство \n" +
                "7 - Сумма двух векторов \n" +
                "8 - Скалярное произведение двух векторов \n" +
                "9 - Вывести вектора с максимальным и минимальным количеством координат \n" +
                "10 - Отсортировать вектора по количеству координат \n" +
                "11 - Отсортировать вектора по модулю \n" +
                "12 - Удалить вектор \n" +
                "13 - Работа с потоками";
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
                    EditVector(vectors);
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
                case "13":
                    Stream(vectors);
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

        static void EditVector(List<IVectorable> vectors)
        {
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
                    if (((IComparable)vectors[j]).CompareTo((IComparable)vectors[j + 1]) > 0)
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

        static string VectorsInfo(List<IVectorable> vectors)
        {
            string text = String.Format("{0, -5}{1, -7}{2}", "№", "Тип", "Вектор") + '\n';
            string type;
            for (int i = 0; i < vectors.Count; i++)
            {
                if (vectors[i].GetType() == typeof(ArrayVector)) type = "Array";
                else type = "List";
                text += String.Format("{0, -5}{1, -7}{2}", i + 1, type, vectors[i].ToString()) + '\n';
            }
            return text;
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
        static void MenuStreams3(List<IVectorable> vectors)
        {
            //string path = @"C:\Users\veron\source\repos\csharp\Console\S2\ЛР05\ЛР05\Serialized.bin";
            //List<IVectorable> vectorsRead = new List<IVectorable>();
            //for (int i = 0; i < vectors.Count; i++)
            //{
            //    FileStream serialized = File.Create(path);
            //    BinaryFormatter convert = new();
            //    convert.Serialize(serialized, vectors[i]);
            //    serialized.Close();
            //    FileStream deserialized = File.Open(path, FileMode.Open, FileAccess.ReadWrite);
            //    vectorsRead.Add((IVectorable)convert.Deserialize(deserialized));
            //    deserialized.Close();
            //    Console.WriteLine("Ваш вектор:\n{0}", vectors[i].ToString());
            //    Console.WriteLine("Десериализованный вектор:\n{0}", vectorsRead[i].ToString());
            //    if (vectors[i].Equals(vectorsRead[i]) == true) Console.WriteLine("Вектора равны.");
            //    else Console.WriteLine("Вектора не равны.");
            //}
            //Console.ReadKey();
            //Console.Clear();
        }
        static void MenuStreams2(List<IVectorable> vectors)
        {
            string path2 = @"C:\Users\veron\source\repos\csharp\Console\S2\ЛР05\ЛР05\VectorsSymbol.txt";
            if (File.Exists(path2) == true)
            {
                File.Delete(path2);
            }
            using (TextWriter writer = File.AppendText(path2))
            {
                for (int i = 0; i < vectors.Count; i++)
                {
                    Vectors.WriteVector(vectors[i], writer);
                }
                Console.WriteLine("Запись в файл выполнена.");
                writer.Close();
            }


            TextReader reader = File.OpenText(path2);
            List<IVectorable> vectorsRead = new List<IVectorable>();
            for (int i = 0; i < vectors.Count; i++)
            {
                vectorsRead.Add(Vectors.ReadVector(reader));
            }
            reader.Close();
            Console.WriteLine("Чтение из файла выполнено.");

            Console.WriteLine("Исходный список векторов:");
            Console.WriteLine("{0, -3}{1, -10}", "№", "Вектор");
            for (int i = 0; i < vectors.Count; i++)
            {
                Console.WriteLine("{0, -3}{1, -10}", i + 1, vectors[i].ToString());
            }
            Console.WriteLine("Считанный с файла список векторов:");
            Console.WriteLine("{0, -3}{1, -10}", "№", "Вектор");
            for (int i = 0; i < vectorsRead.Count; i++)
            {
                Console.WriteLine("{0, -3}{1, -10}", i + 1, vectorsRead[i].ToString());
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void MenuStreams1(List<IVectorable> vectors)
        {
            string path = @"C:\Users\veron\source\repos\csharp\Console\S2\ЛР05\ЛР05\Vectors.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                Vectors.InputVectors(vectors, fileStream);
            }

            Console.WriteLine("Запись в файл выполнена.");
            List<IVectorable> vectorsRead = new List<IVectorable>();
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                vectorsRead = Vectors.OutputVectors(fileStream);
            }

            Console.WriteLine("Чтение из файла выполнено. \n");

            Console.WriteLine("Исходный списо векторов:");
            Console.WriteLine("{0, -3}{1, -10}", "№", "Вектор");
            for (int i = 0; i < vectors.Count; i++)
            {
                Console.WriteLine("{0, -3}{1, -10}", i + 1, vectors[i].ToString());
            }
            Console.WriteLine("Считанный с файла список векторов:");
            Console.WriteLine("{0, -3}{1, -10}", "№", "Вектор");
            for (int i = 0; i < vectorsRead.Count; i++)
            {
                Console.WriteLine("{0, -3}{1, -10}", i + 1, vectorsRead[i].ToString());
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void Stream(List<IVectorable> vectors)
        {
            bool flag = true;
            if (vectors.Count <= 0)
            {
                Console.WriteLine("Список векторов пуст, пожалуйста, вернитесь и создайте хотя бы один вектор!");
                Console.ReadKey();
                flag = false;
            }
            while (flag)
            {
                Console.Clear();

                Console.WriteLine("Выберите задание: ");
                Console.WriteLine("1 - Байтовый поток");
                Console.WriteLine("2 - Символьный поток");
                Console.WriteLine("3 - Сериализация");
                Console.WriteLine("любая другая кнопка - возврат к главному меню");


                Console.Write("Выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        MenuStreams1(vectors);
                        break;
                    case "2":
                        MenuStreams2(vectors);
                        break;
                    case "3":
                        MenuStreams3(vectors);
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}
