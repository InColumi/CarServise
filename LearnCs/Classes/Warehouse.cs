using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCs.Classes
{
    class Warehouse
    {
        private Random _random;
        private Dictionary<Detail, int> _countDetails;

        public Warehouse()
        {
            _countDetails = new Dictionary<Detail, int>();
        }

        public bool FindByName(string name)
        {
            foreach(var detail in _countDetails)
            {
                if(detail.Key.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckNumberDetails(string name, int numberOfDetails)
        {
            if(FindByName(name))
            {
                foreach(var detail in _countDetails)
                {
                    if(detail.Key.Name == name)
                    {
                        return detail.Value >= numberOfDetails;
                    }
                }
            }
            else
            {
                Console.WriteLine("Такой детали нет.");
            }
            return false;
        }

        public float GetPriceByName(string name)
        {
            if(FindByName(name))
            {
                foreach(var detail in _countDetails)
                {
                    if(detail.Key.Name == name)
                    {
                        return detail.Key.Price;
                    }
                }
            }
            else
            {
                Console.WriteLine("Такой детали нет.");
            }
            return 0;
        }

        private bool PreparationToApply(string name, int number, string operation)
        {
            bool resalt = false;
            bool availabilityDetails = false;
            if(FindByName(name))
            {
                foreach(var detail in _countDetails)
                {
                    if(detail.Key.Name == name)
                    {
                        if(number > 0)
                        {
                            switch(operation)
                            {
                                case "Take":
                                    int numberTake = detail.Value - number;
                                    if(numberTake >= 0)
                                    {
                                        availabilityDetails = true;
                                        _countDetails[detail.Key] = numberTake;
                                        resalt = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Деталей недостаточно.");
                                    }
                                    break;
                                case "Add":
                                    _countDetails[detail.Key] += number;
                                    resalt = true;
                                    break;
                            }
                        }
                        break;
                    }
                }
            }

            if(availabilityDetails == false)
            {
                Console.WriteLine($"Деталь {name} отсутствует.");
            }

            return resalt;
        }

        public bool TakeDetails(string name, int number)
        {
            return PreparationToApply(name, number, "Take");
        }

        public bool AddDetailsByName(string name, int number)
        {
            return PreparationToApply(name, number, "Add");
        }

        public void AddNewDetail(Detail detail, int number)
        {
            _countDetails.Add(detail, number);
        }

        public void ShowInfo()
        {
            foreach(var detail in _countDetails)
            {
                detail.Key.ShowInfo();
                Console.WriteLine($" В наличии: {detail.Value}");
            }
        }
    }
}
