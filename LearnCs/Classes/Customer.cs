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

        public void TakeMoney(float price)
        {
            _money += price;
        }

        public void BayReparingCar(float price)
        {
            float amount = _money - price;
            if(amount >= 0)
            {
                _money = amount;
                Console.WriteLine("Ремонт оплачен");
            }
            else
            {
                Console.WriteLine($"Недостаточно денег для ремонта у {Name}.");
            }
        }
    }
}
