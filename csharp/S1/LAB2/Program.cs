using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 2, выполнила студент Бренева Вероника");

            // пользовательское меню здесь
            bool key = false;
            while (key == false)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("2 - второе задание «Таблица значений функции» ");
                Console.WriteLine("3 - третье задание «Серия выстрелов по мишени»");
                Console.WriteLine("4 - четвертое задание «Сумма ряда»");
                Console.WriteLine("любой другой знак - завершение работы с меню \n");
                string menu1 = Console.ReadLine();
                switch (menu1)
                {
                    case "2":
                        Console.WriteLine("Второе задание:\n");

                        Console.WriteLine("Введите минимум (xmin): ");
                        double xmin = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите максимум (xmax): ");
                        double xmax = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите шаг (dx): ");
                        double dx = Convert.ToDouble(Console.ReadLine());

                        if ((xmin < -7) || (xmin > 3))
                        {
                            xmin = -7;
                            Console.WriteLine("xmin не принадлежит области определения функции, xmin = -7\n");
                        }
                        if ((xmax < -7) || (xmax > 3))
                        {
                            xmax = 3;
                            Console.WriteLine("xmax не принадлежит области определения функции, xmax = 3\n");
                        }

                        Console.WriteLine("{0,10:0.00}{1,16:0.00}", "x", "y");

                        while (xmin <= xmax)
                        {
                            double y;
                            if ((xmin <= 3) && (xmin >= -7))
                            {
                                if (xmin < -6)
                                {
                                    y = 2;
                                }
                                else
                                {
                                    if (xmin < -2)
                                    {
                                        y = 0.25 * (xmin + 2);
                                    }
                                    else
                                    {
                                        if (xmin < 0)
                                        {
                                            y = Math.Sqrt((4 - Math.Pow((xmin + 2), 2))) - 2;
                                        }
                                        else
                                        {
                                            if (xmin < 2)
                                            {
                                                y = Math.Sqrt(4 - Math.Pow(xmin, 2));
                                            }
                                            else
                                            {
                                                y = -(xmin - 2);
                                            }
                                        }
                                    }
                                }
                                Console.WriteLine("{0,10:0.00}{1,16:0.00}", xmin, y);
                                xmin += dx;
                            }
                            else
                            {
                                Console.WriteLine("Функция не определена.");
                            }
                        }
                        break;
                    case "3": 
                        Console.WriteLine("Третье задание:\n");

                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("Попытка #{0}\n", i + 1);
                            Console.WriteLine("Введите х: ");
                            double x3 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите y: ");
                            double y = Convert.ToDouble(Console.ReadLine());
                            if (((y <= x3) && (y >= Math.Pow((x3 - 2), 2) - 3) && (y >= 0)) || ((y <= -x3) && (y >= Math.Pow((x3 - 2), 2) - 3)))
                            {
                                Console.WriteLine("Попали в цель.\n");
                            }
                            else
                            {
                                Console.WriteLine("Не попали.\n");
                            }
                        }
                        break;
                    case "4":
                        Console.WriteLine("Четвертое задание:\n");

                        Console.WriteLine("Введите x для вычисления arctg x (x > 1): ");
                        double x4 = Convert.ToDouble(Console.ReadLine());
                        if (x4 <= 1)
                        {
                            Console.WriteLine("Выполнение невозможно, так как x <= 1");
                        }
                        else
                        {
                            Console.WriteLine("Введите точность вычисления: ");
                            double eps = Convert.ToDouble(Console.ReadLine());
                            double currentRowSum = Math.PI / 2;
                            double lastRowSum = 0;
                            int n = 0; double elem;
                            while (Math.Abs(currentRowSum - lastRowSum) > eps)
                            {
                                elem = ((Math.Pow(-1, (n + 1))) / ((2 * n + 1) * (Math.Pow(x4, (2 * n + 1)))));
                                lastRowSum = currentRowSum;
                                currentRowSum += elem;
                                n++;
                            }
                            Console.WriteLine("\nСумма ряда с точностью {0} = {1}", eps, currentRowSum);
                            Console.WriteLine("Количество членов в ряду: {0}", n);
                        }
                        
                        break;
                    default:
                        Console.WriteLine("Спасибо за работу с нами!");
                        key = true;
                        break;
                }
            }
        }
    }
}