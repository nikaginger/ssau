using System;

namespace AdditionTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine ("Рады приветствовать Вас на складе 'СуперСток'!\n");
            Console.Write("Введите вместимость склада: ");
            int storage = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите стоимость хранения: ");
            int cost = Convert.ToInt32(Console.ReadLine());
            Store store = new Store(storage, cost);
            int flag = -1;
            
            Console.WriteLine("1 - Добавление контейнера на склад");
            Console.WriteLine("2 - Удаление контейнера со склада");
            Console.WriteLine("3 - Просмотр склада");
            Console.WriteLine("любая кнопка - Остановить редактирование");
            while (flag != 0)
            {
                Console.Write("\nВведите пункт меню: ");
                flag = Convert.ToInt32(Console.ReadLine());
                switch (flag)
                {
                    case 1: //Ввод данных о контейнере (добавление)
                        Container container = new Container();
                        if (store.CurrentContainer == store.Storage)
                        {
                            store.CurrentContainer -= 1;
                        }
                            Console.WriteLine("Вы можете добавить в '" + (store.CurrentContainer + 1) + "' контейнер " + container.Capacity + " кг");
                        Console.WriteLine("Чтобы перестать заполнять контейнер, введите 0 в строке 'Ввод массы'");
                        int weight = 0;
                        do
                        {
                            Console.Write("Ввод массы ящика: ");
                            weight = Convert.ToInt32(Console.ReadLine());
                            if (weight != 0)
                            {
                                Console.Write("Ввод цены за кг: ");
                                int price = Convert.ToInt32(Console.ReadLine());
                                container.AddBox(weight, price);
                                Console.WriteLine("Контейнер заполнен на " + container.Counter + " кг из " + container.Capacity);
                            }
                        }
                        while (weight != 0);
                        store.InputContainer(container);
                        break;

                    case 2: // Указывается индефикатор удаляемого контейнера
                        Console.Write("Введите номер удаляемого контейнера: ");
                        int number = Convert.ToInt32(Console.ReadLine());
                        store.DeleteContainer(number);
                        Console.WriteLine("Контейнер '{0}' удален", number);
                        break;
                    case 3:
                        store.Print();
                        break;
                    default:
                        break;
                }
            }

        }
    }
}