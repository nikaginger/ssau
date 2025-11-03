using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите х: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите y: ");
            double y = Convert.ToDouble(Console.ReadLine());
            if (((y <= x) && (y >= Math.Pow((x-2), 2) - 3) && (y >= 0)) || ((y <= -x) && (y >= Math.Pow((x - 2), 2) - 3)))
            {
                Console.WriteLine("Попали в цель.");
            }
            else
            {
                Console.WriteLine("Не попали.");
            }
        }
    }
}
