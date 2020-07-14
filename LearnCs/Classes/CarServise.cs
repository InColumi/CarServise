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
            float amout = _warehouse.GetPriceByName(car.Breakage);
            return amout * car.NumberOfBreakage + amout * PriceForWorkInPercent / 100;
        }

        private void TakeMoney(float price)
        {
            _money += price;
        }

        private float GetCompansation(float price)
        {
            _money -= price;
            return price;
        }

        public void ReparingCar(Car car, ref float compansation)
        {
            float amount = _warehouse.GetPriceByName(car.Breakage);
            if(_warehouse.CheckNumberDetails(car.Breakage, car.NumberOfBreakage))
            {
                TakeMoney(amount);
                _warehouse.TakeDetails(car.Breakage, car.NumberOfBreakage);
                car.Raparing();
            }
            else
            {
                compansation = GetCompansation(amount);
            }     
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Баланс денег: {_money}.\n" +
                $"\tCклад деталей:");
            _warehouse.ShowInfo();
        }
    }
}
