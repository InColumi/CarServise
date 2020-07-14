using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCs.Classes
{
    class CarService
    {
        Random _rand;
        private Warehouse _warehouse;
        private Queue<Customer> _customers;

        private float _money;

        private int _priceForWorkInPercent;

        public CarService(float money, int priceForWorkInPercent = 30)
        {
            _warehouse = new Warehouse();
            _customers = new Queue<Customer>();
            _money = money;
            _priceForWorkInPercent = priceForWorkInPercent;
            GenarationCustomers();
        }

        private void GenarationCustomers()
        {
            _rand = new Random();
            _customers.Enqueue(new Customer("Фред", "Воздушный фильтр", _rand.Next(100, 501), _rand));
            _customers.Enqueue(new Customer("Сем", "Передние стойки", _rand.Next(100, 501), _rand));
            _customers.Enqueue(new Customer("Пайк", "Задние стойки", _rand.Next(100, 501), _rand));
            _customers.Enqueue(new Customer("Вова", "Суппорты", _rand.Next(100, 501), _rand));
            _customers.Enqueue(new Customer("Иван", "Капот", _rand.Next(100, 501), _rand));
            _customers.Enqueue(new Customer("Юрец", "Бампер", _rand.Next(100, 501), _rand));
            _customers.Enqueue(new Customer("Оругец", "Двигатель", _rand.Next(100, 501), _rand));
            _customers.Enqueue(new Customer("Стив", "Заднее стекло", _rand.Next(100, 501), _rand));
        }

        public void Work()
        {
            while(_customers.Count > 0)
            {
                ShowInfo();
                Console.WriteLine($"В очеди {_customers.Count - 1} человек.\n");
                Console.WriteLine();
                
                Customer currCustomer =  _customers.Dequeue();
                currCustomer.ShowInfo();

                Repairing(currCustomer);

                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine($"Рабочий день окончен. В касcе {_money} рублей.");
        }

        private void Repairing(Customer customer)
        {
            float fine = 150;
            if(_warehouse.CheckAvailabilityByName(customer.TextBreakage))
            {
                if(_warehouse.CheckNumbersDetails(customer.TextBreakage, customer.NumberOfBreakage))
                {
                    Detail detail = _warehouse.GetDetailByName(customer.TextBreakage);
                    float priceForDetails = detail.Price * customer.NumberOfBreakage;
                    float priceForWork = priceForDetails * _priceForWorkInPercent / 100;
                    float amountPriceForWork = priceForDetails + priceForWork;
                    if(customer.CheckSelvency(detail, priceForWork))
                    {
                        customer.ToPay();
                        _warehouse.TakeDetails(detail.Name, customer.NumberOfBreakage);
                        _money += amountPriceForWork;
                    }
                    else
                    {
                        Console.WriteLine("У клиента не оказалось столько денег и он ушел недовольным.");
                    }
                }
                else
                {
                    Console.WriteLine($"Детали нет на складе. Автосервису выписали штраф в размере {fine} руб");
                    _money -= fine;
                }         
            }
            else
            {
                Console.WriteLine($"Детали нет на складе. Автосервису выписали штраф в размере {fine} руб");
                _money -= fine;
            }
        }

        private void ShowInfo()
        {
            Console.WriteLine($"Баланс денег: {_money}.\n");
            _warehouse.ShowInfo();
        }
    }
}
