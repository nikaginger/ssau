using System;

namespace LAB7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №7.Основы языка С#: Работа со строками");
            Console.WriteLine("Выполнила студентка группы 6101-020302D Бренева Вероника");
            Console.WriteLine("В рамках курса \"Основы программирования\"");
            bool check0 = true;
            while (check0)
            {
                Console.WriteLine("Выберите номер задания:");
                Console.WriteLine("1 - Подсчитать число букв");
                Console.WriteLine("2 - Подсчитать среднюю длину слова");
                Console.WriteLine("3 - Замена слова");
                Console.WriteLine("4 - Количество вхождений подстроки");
                Console.WriteLine("5 - Проверка на палиндром");
                Console.WriteLine("6 - Проверка на дату");
                Console.WriteLine("любая кнопка - выход");
                string choice0 = Console.ReadLine();
                switch (choice0)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите строку: ");
                            string str = Console.ReadLine();
                            Console.WriteLine("Количество букв в строке: {0}", MyString.CountLetters(str));
                            Console.WriteLine();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Введите строку: ");
                            string str = Console.ReadLine();
                            Console.WriteLine("Средняя длина слова: {0}", MyString.AverageWordLength(str));
                            Console.WriteLine();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Введите строку: ");
                            string str = Console.ReadLine();
                            Console.WriteLine("Введите слово, которое надо заменить: ");
                            string old = Console.ReadLine();
                            Console.WriteLine("Введите слово, которым надо заменить: ");
                            string newword = Console.ReadLine();
                            Console.WriteLine("Ваша строка:\n" + str);
                            Console.WriteLine("Итоговая строка:\n{0}", MyString.ReplaceString(str, old, newword));
                            break;
                        }
                    case "4":
                        {

                            Console.WriteLine("Введите строку: ");
                            string str = Console.ReadLine();
                            Console.WriteLine("Введите подстроку для подсчета: ");
                            string old = Console.ReadLine();
                            Console.WriteLine("Количество вхождений подстроки: {0}", MyString.CountSubString(str, old));
                            Console.WriteLine();
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Введите строку: ");
                            string str = Console.ReadLine();
                            MyString strin = new MyString(str);
                            if (MyString.IsPalindrome(str))
                            {
                                Console.WriteLine("Строка является палиндромом.");
                            }
                            else {
                                Console.WriteLine("Строка не является палиндромом.");
                            }
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("Введите строку: ");
                            string str = Console.ReadLine();
                            MyString strin = new MyString(str);
                            strin.isDate(str);
                            break;
                        }
                    default:
                        {
                            check0 = false;
                            break;
                        }
                }
            }
        }
    }
}
