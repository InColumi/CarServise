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

            ProcessReparing(carService, customer1);
        }
        static void ProcessReparing(CarService carService, Customer customer)
        {
            customer.Car.ShowBreakage();
            Console.Write("Цена за починку авто: ");
            
            float amountByReparing = carService.GetPriceByReparing(customer.Car);
            Console.WriteLine(amountByReparing);

            float compansation = 0;
            carService.ReparingCar(customer.Car, ref compansation);
            if(compansation == 0)
            {
                customer.BayReparingCar(amountByReparing);
            }
            else
            {
                customer.TakeMoney(compansation);
                Console.WriteLine($"Отказ возмещен в размере - {compansation}");
            } 
        }

        static void GenagateWarehouse(Warehouse warehouse)
        {
            Random random = new Random();

            warehouse.AddNewDetail(new Detail(random.Next(10, 101), "Воздушный фильтр"), random.Next(1, 2));
        }
    }
}