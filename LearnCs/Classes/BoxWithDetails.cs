using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCs.Classes
{
    class BoxWithDetails
    {
        public Detail Detail { get; private set; }
        public int CountDetails { get; private set; }
        public int MaxCapacity { get; private set; }
        public int EmptySpace { get; private set; }
        
        public BoxWithDetails(Detail detail, int countDetails, int capacity = 25)
        {
            Detail = detail;
            MaxCapacity = capacity;
            if(countDetails <= MaxCapacity)
            {
                CountDetails = countDetails;
                EmptySpace = MaxCapacity - CountDetails;
            }
            else
            {
                CountDetails = MaxCapacity;
                EmptySpace = 0;
                Console.WriteLine($"Деталей \"{Detail.Name}\" заказали слишком много. Остальные придется викинуть на улицу.");
            }
        }

        public bool CheckNumbersDetailsInBox(int numberOfDetails)
        {
            return CountDetails >= numberOfDetails;
        }

        public void TakeDetailsFromBox(int numberOfDetails)
        {
            if(CheckNumbersDetailsInBox(numberOfDetails))
            {
                CountDetails -= numberOfDetails;
            }
            else
            {
                Console.WriteLine("Деталей слишком мало.");
            }
        }

        public void AddToCountDetails(int numberOfDetails)
        {
            if(numberOfDetails <= EmptySpace)
            {
                EmptySpace -= numberOfDetails;
                CountDetails += numberOfDetails;
            }
            else
            {
                Console.WriteLine("Деталей слишком много. Закажите меньше деталей и будьте вниметельней!");
            }
        }

        public void ShowInfo()
        {
            Detail.ShowInfo();
            Console.WriteLine($"В наличии: {CountDetails} шт.");
        }
    }
}
