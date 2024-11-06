using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    class Question4
    {
        static void Main()
        {
            Console.WriteLine("Enter a string: ");
            string InputString = Console.ReadLine();

            Console.WriteLine("Enter the letter to be counted: ");
            char letterToCount = Convert.ToChar(Console.ReadLine());

            int count = 0;
            foreach(char c in InputString)
            {
                if (char.ToLower(c) == char.ToLower(letterToCount))
                    count++;
            }

            Console.WriteLine($"The letter '{letterToCount}' occurs {count} times in the string {InputString}");

            Console.ReadLine();
        }
    }
}
