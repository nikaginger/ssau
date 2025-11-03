using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координату х: ");
            double x = Convert.ToDouble(Console.ReadLine());
            double y;
            if ((x <= 3) && (x >= -7))
            {
                if (x < -6)
                {
                    y = 2;
                }
                else
                {
                    if (x < -2)
                    {
                        y = 0.25 * (x + 2);
                    }
                    else
                    {
                        if (x < 0)
                        {
                            y = Math.Sqrt((4 - Math.Pow((x + 2), 2))) - 2;
                        }
                        else
                        {
                            if (x < 2)
                            {
                                y = Math.Sqrt(4 - Math.Pow(x, 2));
                            }
                            else
                            {
                                y = -(x - 2);
                            }
                        }
                    }
                }
                Console.WriteLine("Значение y = " + y);
            }
            else
            {
                Console.WriteLine("Функция не определена.");
            }
        }
    }
}
