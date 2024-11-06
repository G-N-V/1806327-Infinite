using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    class Question1
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string inputString = Console.ReadLine();

            Console.WriteLine("Enter position you want to remove character: ");
            int position = Convert.ToInt32(Console.ReadLine());

            if (position < 0 || position >= inputString.Length)
            {
                Console.WriteLine("Invalid position!");
            }
            else
            { 
                string resultString = inputString.Remove(position, 1);
                Console.WriteLine("Resulting string: " + resultString);

                Console.ReadLine();
            }
        }
    }
}
