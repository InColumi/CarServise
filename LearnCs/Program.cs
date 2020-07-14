using LearnCs.Classes;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService(500f);
            carService.Work();
        }
    }
}