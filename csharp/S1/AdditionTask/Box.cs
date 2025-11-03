using System;

namespace AdditionTask
{
    public class Box // Ящик овощей
    {
        readonly double weight;
        private double price;

        public Box(double weight, double price)
        {
            this.weight = weight;
            this.price = price;
        }

        public double Weight // Свойство доступа массы ящика
        {
            get
            {
                return weight;
            }
        }
        public double Price // Свойство доступа и установки цены за кг
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
    }
}

