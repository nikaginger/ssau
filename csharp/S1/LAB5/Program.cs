using System;

namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №5.Основы языка С#: Классы");
            Console.WriteLine("Выполнила студентка группы 6101-020302D Бренева Вероника");
            Console.WriteLine("В рамках курса \"Основы программирования\"");

            bool check0 = true;
            while (check0)
            {
                Console.WriteLine("Задания на дроби:");
                Console.WriteLine("1 - Методы");
                Console.WriteLine("2 - Статические методы");
                Console.WriteLine("3 - Переопределение операций");
                Console.WriteLine("любая кнопка - завершение работы программы");
                string switcher0 = Console.ReadLine();
                switch (switcher0)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "3":
                        Task3();
                        break;
                    default:
                        check0 = false;
                        break;
                }
            }
        }

        public static void Task1()
        {
            bool check1 = true;
            while (check1)
            {
                Console.WriteLine("Действия:");
                Console.WriteLine("1 - Сложение");
                Console.WriteLine("2 - Вычитание");
                Console.WriteLine("3 - Умножение");
                Console.WriteLine("4 - Деление");
                Console.WriteLine("5 - Сократить");
                Console.WriteLine("любая кнопка - выход");
                string switcher1 = Console.ReadLine();
                switch (switcher1)
                {
                    case "1":
                        Console.WriteLine("Введите числитель первой дроби");
                        int num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель первой дроби");
                        int den1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите числитель второй дроби");
                        int num2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель второй дроби");
                        int den2 = Int32.Parse(Console.ReadLine());
                        Fraction x = new Fraction(num1, den1);
                        Console.WriteLine("Первая  дробь: {0}", x.ToString()); ;
                        Fraction y = new Fraction(num2, den2);
                        Console.WriteLine("Вторая дробь: {0}", y.ToString());
                        Fraction z = new Fraction();
                        z = x.Addition(y);
                        z = z.ToReduce();
                        Console.WriteLine("Итоговая дробь: {0}", z.ToString());
                        break;
                    case "2":
                        Console.WriteLine("Введите числитель первой дроби");
                        num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель первой дроби");
                        den1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите числитель второй дроби");
                        num2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель второй дроби");
                        den2 = Int32.Parse(Console.ReadLine());
                        x = new Fraction(num1, den1);
                        Console.WriteLine("Первая  дробь: {0}", x.ToString()); ;
                        y = new Fraction(num2, den2);
                        Console.WriteLine("Вторая дробь: {0}", y.ToString());
                        z = new Fraction();
                        z = x.Subtract(y);
                        z = z.ToReduce();
                        Console.WriteLine("Итоговая дробь: {0}", z.ToString());
                        break;
                    case "3":
                        Console.WriteLine("Введите числитель первой дроби");
                        num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель первой дроби");
                        den1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите числитель второй дроби");
                        num2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель второй дроби");
                        den2 = Int32.Parse(Console.ReadLine());
                        x = new Fraction(num1, den1);
                        Console.WriteLine("Первая  дробь: {0}", x.ToString()); ;
                        y = new Fraction(num2, den2);
                        Console.WriteLine("Вторая дробь: {0}", y.ToString());
                        z = new Fraction();
                        z = x.Multiply(y);
                        z = z.ToReduce();
                        Console.WriteLine("Итоговая дробь: {0}", z.ToString());
                        break;
                    case "4":
                        Console.WriteLine("Введите числитель первой дроби");
                        num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель первой дроби");
                        den1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите числитель второй дроби");
                        num2 = Int32.Parse(Console.ReadLine());
                        if (num2 == 0)
                        {
                            Console.WriteLine("На ноль делить нельяз!");
                        }
                        else
                        {
                            Console.WriteLine("Введите знаменатель второй дроби");
                            den2 = Int32.Parse(Console.ReadLine());
                            x = new Fraction(num1, den1);
                            Console.WriteLine("Первая  дробь: {0}", x.ToString()); ;
                            y = new Fraction(num2, den2);
                            Console.WriteLine("Вторая дробь: {0}", y.ToString());
                            z = new Fraction();
                            z = x.Divide(y);
                            z = z.ToReduce();
                            Console.WriteLine("Итоговая дробь: {0}", z.ToString());
                        }
                        break;
                    case "5":
                        Console.WriteLine("Введите числитель дроби");
                        num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель дроби");
                        den1 = Int32.Parse(Console.ReadLine());
                        x = new Fraction(num1, den1);
                        Console.WriteLine("Ваша дробь: {0}", x.ToString());
                        x = x.ToReduce();
                        Console.WriteLine("Итоговая дробь: {0}", x.ToString());
                        break;
                    default:
                        check1 = false;
                        break;
                }
            }
        }

        public static void Task2()
        {
            bool check2 = true;
            while (check2)
            {
                Console.WriteLine("Действия:");
                Console.WriteLine("1 - Сложение");
                Console.WriteLine("2 - Вычитание");
                Console.WriteLine("3 - Умножение");
                Console.WriteLine("4 - Деление");
                Console.WriteLine("любая кнопка - выход");
                string switcher2 = Console.ReadLine();
                switch (switcher2)
                {
                    case "1":
                        Console.WriteLine("Введите числитель первой дроби");
                        int num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель первой дроби");
                        int den1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите числитель второй дроби");
                        int num2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель второй дроби");
                        int den2 = Int32.Parse(Console.ReadLine());
                        Fraction x = new Fraction(num1, den1);
                        Console.WriteLine("Первая  дробь: {0}", x.ToString()); ;
                        Fraction y = new Fraction(num2, den2);
                        Console.WriteLine("Вторая дробь: {0}", y.ToString());
                        Fraction z = new Fraction();
                        z = Actions.Addition(x, y);
                        z = z.ToReduce();
                        Console.WriteLine("Итоговая дробь: {0}", z.ToString());
                        break;
                    case "2":
                        Console.WriteLine("Введите числитель первой дроби");
                        num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель первой дроби");
                        den1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите числитель второй дроби");
                        num2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель второй дроби");
                        den2 = Int32.Parse(Console.ReadLine());
                        x = new Fraction(num1, den1);
                        Console.WriteLine("Первая  дробь: {0}", x.ToString()); ;
                        y = new Fraction(num2, den2);
                        Console.WriteLine("Вторая дробь: {0}", y.ToString());
                        z = new Fraction();
                        z = Actions.Subtract(x, y);
                        z = z.ToReduce();
                        Console.WriteLine("Итоговая дробь: {0}", z.ToString());
                        break;
                    case "3":
                        Console.WriteLine("Введите числитель первой дроби");
                        num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель первой дроби");
                        den1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите числитель второй дроби");
                        num2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель второй дроби");
                        den2 = Int32.Parse(Console.ReadLine());
                        x = new Fraction(num1, den1);
                        Console.WriteLine("Первая  дробь: {0}", x.ToString()); ;
                        y = new Fraction(num2, den2);
                        Console.WriteLine("Вторая дробь: {0}", y.ToString());
                        z = new Fraction();
                        z = Actions.Multiply(x, y); ;
                        z = z.ToReduce();
                        Console.WriteLine("Итоговая дробь: {0}", z.ToString());
                        break;
                    case "4":
                        Console.WriteLine("Введите числитель первой дроби");
                        num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель первой дроби");
                        den1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите числитель второй дроби");
                        num2 = Int32.Parse(Console.ReadLine());
                        if (num2 == 0)
                        {
                            Console.WriteLine("На ноль делить нельзя!");
                        }
                        else
                        {
                            Console.WriteLine("Введите знаменатель второй дроби");
                            den2 = Int32.Parse(Console.ReadLine());
                            x = new Fraction(num1, den1);
                            Console.WriteLine("Первая  дробь: {0}", x.ToString()); ;
                            y = new Fraction(num2, den2);
                            Console.WriteLine("Вторая дробь: {0}", y.ToString());
                            z = new Fraction();
                            z = Actions.Divide(x, y);
                            z = z.ToReduce();
                            Console.WriteLine("Итоговая дробь: {0}", z.ToString());
                        }
                        break;
                    default:
                        check2 = false;
                        break;
                }
            }
        }
        public static void Task3()
        {
            bool check3 = true;
            while (check3)
            {
                Console.WriteLine("Действия:");
                Console.WriteLine("1 - Сложение");
                Console.WriteLine("2 - Вычитание");
                Console.WriteLine("3 - Умножение");
                Console.WriteLine("4 - Деление");
                Console.WriteLine("любая кнопка - выход");
                string switcher3 = Console.ReadLine();
                switch (switcher3)
                {
                    case "1":
                        Console.WriteLine("Введите числитель первой дроби");
                        int num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель первой дроби");
                        int den1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите числитель второй дроби");
                        int num2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель второй дроби");
                        int den2 = Int32.Parse(Console.ReadLine());
                        Fraction x = new Fraction(num1, den1);
                        Console.WriteLine("Первая  дробь: {0}", x.ToString()); ;
                        Fraction y = new Fraction(num2, den2);
                        Console.WriteLine("Вторая дробь: {0}", y.ToString());
                        Fraction z = new Fraction();
                        z = x + y;
                        z = z.ToReduce();
                        Console.WriteLine("Итоговая дробь: {0}", z.ToString());
                        break;
                    case "2":
                        Console.WriteLine("Введите числитель первой дроби");
                        num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель первой дроби");
                        den1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите числитель второй дроби");
                        num2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель второй дроби");
                        den2 = Int32.Parse(Console.ReadLine());
                        x = new Fraction(num1, den1);
                        Console.WriteLine("Первая  дробь: {0}", x.ToString()); ;
                        y = new Fraction(num2, den2);
                        Console.WriteLine("Вторая дробь: {0}", y.ToString());
                        z = new Fraction();
                        z = x - y;
                        z = z.ToReduce();
                        Console.WriteLine("Итоговая дробь: {0}", z.ToString());
                        break;
                    case "3":
                        Console.WriteLine("Введите числитель первой дроби");
                        num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель первой дроби");
                        den1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите числитель второй дроби");
                        num2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель второй дроби");
                        den2 = Int32.Parse(Console.ReadLine());
                        x = new Fraction(num1, den1);
                        Console.WriteLine("Первая  дробь: {0}", x.ToString()); ;
                        y = new Fraction(num2, den2);
                        Console.WriteLine("Вторая дробь: {0}", y.ToString());
                        z = new Fraction();
                        z = x * y;
                        z = z.ToReduce();
                        Console.WriteLine("Итоговая дробь: {0}", z.ToString());
                        break;
                    case "4":
                        Console.WriteLine("Введите числитель первой дроби");
                        num1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите знаменатель первой дроби");
                        den1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите числитель второй дроби");
                        num2 = Int32.Parse(Console.ReadLine());
                        if (num2 == 0)
                        {
                            Console.WriteLine("На ноль делить нельзя!");
                        }
                        else
                        {
                            Console.WriteLine("Введите знаменатель второй дроби");
                            den2 = Int32.Parse(Console.ReadLine());
                            x = new Fraction(num1, den1);
                            Console.WriteLine("Первая  дробь: {0}", x.ToString()); ;
                            y = new Fraction(num2, den2);
                            Console.WriteLine("Вторая дробь: {0}", y.ToString());
                            z = new Fraction();
                            z = x / y;
                            z = z.ToReduce();
                            Console.WriteLine("Итоговая дробь: {0}", z.ToString());
                        }
                        break;
                    default:
                        check3 = false;
                        break;
                }
            }
        }
    }
}

