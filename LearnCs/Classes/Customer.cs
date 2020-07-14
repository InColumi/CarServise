using System;

namespace LearnCs.Classes
{
    class Customer
    {
        private float _money;
        private float _moneyToPay;
        public string Name { get; private set; }
        public string TextBreakage { get; private set; }
        public int NumberOfBreakage { get; private set; }

        public Customer(string name, string textBreakage, float money, Random rand)
        {
            Name = name;
            _money = money;
            TextBreakage = textBreakage;
            NumberOfBreakage = rand.Next(1, 5);
        }

        public bool CheckSelvency(Detail detail, float moneyForWork)
        {
            _moneyToPay = detail.Price * NumberOfBreakage + moneyForWork;
            if(_moneyToPay <= _money)
            {
                return true;
            }
            else
            {
                _moneyToPay = 0;
                return false;
            }
        }

        public void ToPay()
        {
            _money -= _moneyToPay;
            _moneyToPay = 0;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"У клиента {Name} проблема с {TextBreakage}. Для починки нужно {NumberOfBreakage} деталей.");
        }
    }
}
