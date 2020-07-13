using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCs.Classes
{
    class Detail
    {
        public float Price { get; private set; }
        public string Name { get; private set; }

        public Detail(float price, string name)
        {
            Price = price;
            Name = name;
        }

        public void ShowInfo()
        {
            Console.Write($"Название детали: {Name}. Стоимость детали: {Price}.");
        }
    }
}
