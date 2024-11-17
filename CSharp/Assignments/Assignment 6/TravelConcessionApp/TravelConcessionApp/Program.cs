using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelConcessionLibrary;

namespace TravelConcessionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nHello {name}, let's calculate your concession: ");

            ConcessionCalculator.CalculateConcession(age);

            Console.ReadLine();
        }
    }
}
