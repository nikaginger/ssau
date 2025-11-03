using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            if (a != 0 && a!= 2 && a != -2)
            {
                double z1 = Convert.ToDouble(Math.Pow(((1 + a + Math.Pow(a, 2)) / (2 * a + Math.Pow(a, 2)) + 2 - ((1 - a + Math.Pow(a, 2)) / (2 * a - Math.Pow(a, 2)))), -1) * (5 - 2 * Math.Pow(a, 2)));
                double z2 = Convert.ToDouble((4 - Math.Pow(a, 2)) / 2);
                Console.WriteLine(z1);
                Console.WriteLine(z2);
            }
            else
            {
                Console.WriteLine("На ноль деление невозможно!");
            }
            Console.ReadLine();
        }
    }
}
