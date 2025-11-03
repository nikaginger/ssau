using System;
using System.Collections.Generic;

namespace AdditionTask
{
    class Store // Склад с контейнерами
    {
        readonly int storage, cost;
        List<Container> stock = new List<Container>();

        public Store() // Конструктор по умолчанию
        {
            storage = 2;
            cost = 100;
        }
        public Store(int storage, int cost) // Конструктор с заданными значениями
        {
            this.storage = storage;
            this.cost = cost;
        }

        public int Storage // Свойство доступа к складу
        {
            get
            {
                return storage;
            }
        }
        public int Cost // Свойство доступа к цене хранения на складе
        {
            get
            {
                return cost;
            }
        }

        public int currentContainer = 0; // Текущий контейнер, с которым идет взаимодействие
        public int CurrentContainer
        {
            get
            {
                return currentContainer;
            }
            set
            {
                currentContainer = value;
            }
        }

        public void Print()
        {
            //Console.Clear();
            double storeMass = 0;
            double storeCost = 0;
            for (int i = 0; i < stock.Count; i++)
            {
                storeMass += stock[i].TotalCost;
                storeCost += stock[i].Counter;
            }
            Console.WriteLine("Склад: \t {0} кг \t {1} руб", storeMass, storeCost);
            for (int i = 0; i < stock.Count; i++)
            {
                Console.Write((i + 1) + " контейнер: \t");
                for (int j = 0; j < stock[i].Number; j++)
                {
                    //Console.WriteLine(j);
                    Console.Write(stock[i].Cont[j] + "\n\t\t");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("1 - Добавление контейнера на склад");
            Console.WriteLine("2 - Удаление контейнера со склада");
            Console.WriteLine("3 - Просмотр склада");
            Console.WriteLine("любая другая кнопка - Остановить редактирование");
        }

        public void InputContainer(Container container) // Добавление контейнера
        {
            if (Rentabel(container))
            {
                if (CurrentContainer == storage)
                {
                    CurrentContainer -= 1;
                    stock.RemoveAt(0);
                }
                stock.Add(container);
                CurrentContainer += 1;
            }
            else Console.WriteLine("Контейнер нерентабелен");
        }

        public void DeleteContainer(int number) // Удаление контейнера
        {
            stock.RemoveAt(number - 1);
            CurrentContainer -= 1;
        }

        public bool Rentabel(Container container) // Проверка на рентабельность
        {
            Random rand = new Random();
            double v = rand.Next(0, 51) / 100;
            if (container.TotalCost * (1 - v) > Cost) return true;
            else return false;
        }
    }
}