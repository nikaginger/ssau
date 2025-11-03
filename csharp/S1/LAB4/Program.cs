using System;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool key0 = true;
            while (key0)
            {
                Console.WriteLine("Выберите задание: ");
                Console.WriteLine("1 - Класс 'Десятичный счетчик'");
                Console.WriteLine("2 - Класс 'Многочлен'");
                Console.WriteLine("Другая цифра - завершение работы");
                string switcher0 = Console.ReadLine();
                switch (switcher0)
                {
                    case "1":
                        {
                            Console.Write("Введите минимальное значение счетчика: ");
                            int m1 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите максимальное значение счетчика: ");
                            int m2 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите начальное значение: ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            while ((n <= m1) || (n >= m2))
                            {
                                Console.WriteLine("Начальное значение вне заданного диапазона счетчика, попробуйте еще раз: ");
                                Console.Write("Введите начальное значение: ");
                                n = Convert.ToInt32(Console.ReadLine());
                            }
                            DecimalCounter decimalCounter = new DecimalCounter(m1, m2, n);
                            bool key = true;
                            while (key)
                            {
                                Console.WriteLine("1 - Увеличить значение счетчика на 1");
                                Console.WriteLine("2 - Уменьшить значение счетчика на 1");
                                Console.WriteLine("3 - Получить текущее значение");
                                Console.WriteLine("Другое число - выход из меню");
                                string switcher = Console.ReadLine();
                                switch (switcher)
                                {
                                    case "1":
                                        {
                                            decimalCounter.Inc();
                                            Console.WriteLine("Обновленное текущее значение: {0}", decimalCounter.GetCurrent());
                                            break;
                                        }
                                    case "2":
                                        {
                                            decimalCounter.Dec();
                                            Console.WriteLine("Обновленное текущее значение: {0}", decimalCounter.GetCurrent());
                                            break;
                                        }
                                    case "3":
                                        {
                                            Console.WriteLine("Текущее значение: {0}",decimalCounter.GetCurrent());
                                            break;
                                        }
                                    default:
                                        {
                                            key = false;
                                            break;
                                        }

                                }
                            }
                        }
                        break;
                    case "2":
                        {
                            Console.Write("Введите коэффицент а: ");
                            double a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Введите коэффицент b: ");
                            double b = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Введите коэффицент c: ");
                            double c = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Многочлен: {0}х^2 + {1}x + {2}", a, b, c);
                            Polynomial polynom = new Polynomial(a, b, c);
                            polynom.GetValue();
                            Console.ReadKey();
                        }
                        break;
                    default:
                        {
                            key0 = false;
                            break;
                        }
                }
            }
        }
    }

    class DecimalCounter
    {
        int mini; int maxi; public int current;


        // Конструктор
        public DecimalCounter(int mini, int maxi, int current)
        {
            this.mini = mini;
            this.maxi = maxi;
            this.current = current;
        }

        public DecimalCounter()
        {
            mini = 0;
            maxi = 10;
            current = 1;
        }

        // Метод увеличения на 1
        public void Inc()
        {
            if (current == maxi)
                current = mini;
            else
                current++;
        }
        // Метод уменьшения на 1
        public void Dec()
        {
            if (current == mini)
                current = maxi;
            else
                current--;
        }
        // Метод получения значения
        public int GetCurrent()
        {
            return current;
        }
    }
    class Polynomial
    {
        double a; double b; double c;

        public Polynomial(double a, double b, double c)
        {
            this.a = a; this.b = b; this.c = c;
        }
        public void GetValue()
        {
            if (a == 0)
            {
                double x1 = -c / b;
                Console.WriteLine("Корень уравнения: {0}", x1);
            }
            else
            {
                double d = b * b - 4 * a * c;
                if (d >= 0)
                {
                    double x1 = (-1 * b + Math.Sqrt(d)) / (2 * a);
                    double x2 = (-1 * b - Math.Sqrt(d)) / (2 * a);
                    Console.WriteLine("Корни квадратного уравнения: x1 = {0}, x2 = {1}.", x1, x2);
                }
                else
                {
                    Console.WriteLine("Невозможно получить значения, так как дискриминант < 0.");
                }
            }
        }
    }
}