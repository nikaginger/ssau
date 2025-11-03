using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

class Program
{
    static void Main(string[] args)
    {
        // Год
        int year = 2015; int month;
        bool key = true;
        while (key)
        {
            Console.WriteLine("Введите НОМЕР нужного месяца 2015 года: ");
            month = Convert.ToInt32(Console.ReadLine());
            DateTime currentDate = new DateTime(year, month, 1);
            Console.Write(currentDate.ToString("MMMM"));
            Console.Write(" 2015\n");
            Console.WriteLine("Пн Вт Ср Чт Пт Сб Вс");
            // Определение дня недели первого дня месяца
            int firstDayOfWeek = (int)currentDate.DayOfWeek;
            if (firstDayOfWeek == 0)
            {
                firstDayOfWeek = 6;
            }
            else
                firstDayOfWeek--;
            Console.Write(new string(' ', firstDayOfWeek * 3));
            for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
            {
                Console.Write(day.ToString().PadLeft(2) + " ");

                if (currentDate.AddDays(day).DayOfWeek == DayOfWeek.Monday)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine('\n');

            Console.WriteLine("1 - продолжить, другое число - выход из программы. ");
            int ender = Convert.ToInt32(Console.ReadLine());
            if (ender != 1)
            {
                key = false;
            }
        }
    }
}