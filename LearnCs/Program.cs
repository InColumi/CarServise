using LearnCs.Classes;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.WriteLine("Добро пожаловать!");

            Warehouse warehouse = new Warehouse();
            GenagateWarehouse(warehouse);
            warehouse.ShowInfo();

            CarService carService = new CarService(warehouse, 1000.0f, 25);

            Car car = new Car("Воздушный фильтр", 2);
            Customer customer1 = new Customer("Френк", 500f, car);

            Console.WriteLine("Цена за починку авто:");
            float amountByReparing = carService.GetPriceByReparing(customer1.Car);
            Console.WriteLine(amountByReparing);
            customer1.BayReparingCar(amountByReparing);
        }

        static void GenagateWarehouse(Warehouse warehouse)
        {
            Random random = new Random();

            warehouse.AddNewDetail(new Detail(random.Next(10, 101), "Воздушный фильтр"), random.Next(1, 21));
            warehouse.AddNewDetail(new Detail(random.Next(10, 101), "Передние стойки"), random.Next(1, 21));
            warehouse.AddNewDetail(new Detail(random.Next(10, 101), "Задние стойки"), random.Next(1, 21));
            warehouse.AddNewDetail(new Detail(random.Next(10, 101), "Суппорты"), random.Next(1, 21));
            warehouse.AddNewDetail(new Detail(random.Next(10, 101), "Капот"), random.Next(1, 21));
            warehouse.AddNewDetail(new Detail(random.Next(10, 101), "Бампер"), random.Next(1, 21));
            warehouse.AddNewDetail(new Detail(random.Next(10, 101), "Лобовое стекло"), random.Next(1, 21));
            warehouse.AddNewDetail(new Detail(random.Next(10, 101), "Заднее стекло"), random.Next(1, 21));
            warehouse.AddNewDetail(new Detail(random.Next(10, 101), "Передние сиденья"), random.Next(1, 21));
            warehouse.AddNewDetail(new Detail(random.Next(10, 101), "Задние сиденья"), random.Next(1, 21));
            warehouse.AddNewDetail(new Detail(random.Next(10, 101), "Двигатель"), random.Next(1, 21));
        }
    }
}