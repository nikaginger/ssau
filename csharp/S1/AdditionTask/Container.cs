using System;
using System.Collections.Generic;

namespace AdditionTask
{
    class Container
    {
        List<Box> container = new List<Box>();
        private int capacity, number = 0;

        public Container()
        {
            Random rand = new Random();
            capacity = rand.Next(10, 101); // максимальная вместимость
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }

        public List<Box> Cont
        {
            get { return container; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public double massCounter = 0; // Общая масса контейнера
        public double Counter
        {
            get
            {
                return massCounter;
            }
            set
            {
                massCounter = value;
            }
        }

        public double totalCost = 0; // Общая стоимость ящиков контейнера
        public double TotalCost
        {
            get
            {
                return totalCost;
            }
            set
            {
                totalCost = value;
            }
        }


        public void AddBox(int weight, int price) // Добавить ящик в контейнер
        {
            Box box = new Box(weight, price);
            number += 1;
            if (Counter + box.Weight <= Capacity)
            {
                container.Add(box);
                Counter += box.Weight;
                TotalCost += box.Price * box.Weight;

            }
            else
            {
                number--;
                Console.WriteLine("Ящик не может быть помещен в контейнер");
            }
        }
    }
}