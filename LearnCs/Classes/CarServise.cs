using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCs.Classes
{
    class CarService
    {
        private Warehouse _warehouse;

        private float _money;

        public int PriceForWorkInPercent { get; private set; }

        public CarService(Warehouse warehouse, float money, int priceForWorkInPercent)
        {
            _warehouse = warehouse;
            _money = money;
            PriceForWorkInPercent = priceForWorkInPercent;
        }

        public float GetPriceByReparing(Car car)
        {
            float amout = _warehouse.GetPriceByName(car.Breakage) * car.NumberOfBreakage;
            return amout + amout * PriceForWorkInPercent / 100;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Баланс денег: {_money}.\n" +
                $"\tCклад деталей:");
            _warehouse.ShowInfo();
        }
    }
}
