using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCs.Classes
{
    class Car
    {
        public string Breakage { get; private set; }
        public int NumberOfBreakage { get; private set; }
        private bool _isBreakage ;
        public Car(string breakage, int numberOfBreakage)
        {
            Breakage = breakage;
            NumberOfBreakage = numberOfBreakage;
            _isBreakage = true;
        }

        public void Raparing()
        {
            _isBreakage = false;
            Breakage = "";
        }

        public void ShowBreakage()
        {
            if(_isBreakage)
            {
                Console.WriteLine($"Поломка заключается в : {Breakage} - для починки нужно {NumberOfBreakage} штук");
            }
            else
            {
                Console.WriteLine("Машина в порядке");
            }
            
        }
    }
}
