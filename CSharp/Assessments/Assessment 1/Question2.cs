using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    class Question2
    {
        static void Main()
        {
            Console.WriteLine("Enter a string: ");
            string input_string = Console.ReadLine();

            if (input_string.Length < 2)
                Console.WriteLine("Swapped output: " + input_string);
            else
            {
                char firstChar = input_string[0];
                char lastChar = input_string[input_string.Length - 1];
                string middle = input_string.Substring(1, input_string.Length - 2);
                string output_string = lastChar + middle + firstChar;

                Console.WriteLine("Swapped output: " + output_string);   
            }

            Console.ReadLine();
        }
    }
}
