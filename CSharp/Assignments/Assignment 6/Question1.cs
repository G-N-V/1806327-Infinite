using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Question1
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter numbers (enter non-numeric value to stop): ");
            string input;

            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out var number))
                {
                    numbers.Add(number);
                }

                else
                    break;
            }

            Console.WriteLine("\nNumbers and their Squares(>20): ");

            foreach(var number in numbers)
            {
                int squares = number * number;
                if (squares > 20)
                {
                    Console.WriteLine($"{number}-{squares}");
                }
            }

            Console.ReadLine();
        }
    }
}
