using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCs.Classes
{
    class Customer
    {
        public string Name { get; private set; }
        private float _money;

        public Car Car { get; private set; }

        public Customer(string name, float money, Car car)
        {
            Name = name;
            _money = money;
            Car = car;
        }

        public void BayReparingCar(float price)
        {
            float amount = _money - price;
            if(amount >= 0)
            {
                _money = amount;
                Car.Raparing();
                Console.WriteLine("Ремонт прошел успешно.");
            }
            else
            {
                Console.WriteLine($"Недостаточно денег у клиента {Name}.");
            }
        }
    }
}
