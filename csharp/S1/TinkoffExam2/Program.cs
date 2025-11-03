using System;

namespace TinkoffExam2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Office[] offices = new Office[n];
            for (int i = 0; i < n; i++)
            {
                int stuffCount = Convert.ToInt32(Console.ReadLine());
                offices[i] = new Office(stuffCount);
                string s = Console.ReadLine();
                string[] socialBatteries = s.Split(' ');
                for (int j = 0; j < socialBatteries.Length; j++)
                {
                    offices[i].Stuff[j].SocialBattery = Convert.ToInt32(socialBatteries[j]);
                }
            }
            Console.ReadLine();
        }
    }

    class Programmer
    {
        int socialBattery;
        Programmer[] Connections;

        public int SocialBattery
        {
            get { return socialBattery; }
            set { socialBattery = value; }
        }
        public Programmer(int social)
        {
            this.socialBattery = social;
        }
    }

    class Office
    {
        int numberOfProgrammers;
        public Programmer[] Stuff;

        public Office(int numberOfProgrammers)
        {
            this.numberOfProgrammers = numberOfProgrammers;
        }
    }
}
