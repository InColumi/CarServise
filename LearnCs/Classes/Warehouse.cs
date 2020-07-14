using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCs.Classes
{
    class Warehouse
    {
        private List<BoxWithDetails> _boxWithDetails;

        public Warehouse()
        {
            _boxWithDetails = new List<BoxWithDetails>();
            GenarateBoxes();
        }

        private void GenarateBoxes()
        {
            Random rand = new Random();

            _boxWithDetails.Add(new BoxWithDetails(new Detail(rand.Next(10, 101), "Воздушный фильтр"), rand.Next(1, 50)));
            _boxWithDetails.Add(new BoxWithDetails(new Detail(rand.Next(10, 101), "Передние стойки"), rand.Next(1, 5)));
            _boxWithDetails.Add(new BoxWithDetails(new Detail(rand.Next(10, 101), "Задние стойки"), rand.Next(1, 50)));
            _boxWithDetails.Add(new BoxWithDetails(new Detail(rand.Next(10, 101), "Суппорты"), rand.Next(1, 5)));
            _boxWithDetails.Add(new BoxWithDetails(new Detail(rand.Next(10, 101), "Капот"), rand.Next(1, 5)));
            _boxWithDetails.Add(new BoxWithDetails(new Detail(rand.Next(10, 101), "Бампер"), rand.Next(1, 5)));
            _boxWithDetails.Add(new BoxWithDetails(new Detail(rand.Next(10, 101), "Лобовое стекло"), rand.Next(1, 5)));
            _boxWithDetails.Add(new BoxWithDetails(new Detail(rand.Next(10, 101), "Передние сиденья"), rand.Next(1, 50)));
            _boxWithDetails.Add(new BoxWithDetails(new Detail(rand.Next(10, 101), "Задние сиденья"), rand.Next(1, 5)));
            _boxWithDetails.Add(new BoxWithDetails(new Detail(rand.Next(10, 101), "Двигатель"), rand.Next(1, 5)));
            _boxWithDetails.Add(new BoxWithDetails(new Detail(rand.Next(10, 101), "Заднее стекло"), rand.Next(1, 50)));
        }

        public int FindIndexDetailByName(string name)
        {
            if(CheckAvailabilityByName(name))
            {
                for(int i = 0; i < _boxWithDetails.Count; i++)
                {
                    if(_boxWithDetails[i].Detail.Name == name)
                    {
                        return i;
                    }
                }
            }
            throw new Exception("Такой детали на складе нет.");
        }

        public bool CheckAvailabilityByName(string name)
        {
            foreach(var detail in _boxWithDetails)
            {
                if(detail.Detail.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckNumbersDetails(string name, int numberOfDetails)
        {
            int indexDetail = FindIndexDetailByName(name);
            if(indexDetail >= 0)
            {
                return _boxWithDetails[indexDetail].CheckNumbersDetailsInBox(numberOfDetails);
            }
            else
            {
                return false;
            }
        }

        public Detail GetDetailByName(string name)
        {
            int indexDetails = FindIndexDetailByName(name);
            return _boxWithDetails[indexDetails].Detail;
        }
              
        public void TakeDetails(string name, int numberOfDetails)
        {
            int indexDetails = FindIndexDetailByName(name);
            _boxWithDetails[indexDetails].TakeDetailsFromBox(numberOfDetails);
        }

        public void AddDetailsToBox(string name, int numberOfDetails)
        {
            int indexDetails = FindIndexDetailByName(name);
            _boxWithDetails[indexDetails].AddToCountDetails(numberOfDetails);
        }

        public void ShowInfo()
        {
            Console.WriteLine("На складе:");
            foreach(var currentBox in _boxWithDetails)
            {
                currentBox.ShowInfo();
            }
        }
    }
}
