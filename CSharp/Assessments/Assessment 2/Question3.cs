using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    //Q3. Write a C# program to implement a method that takes an integer as
    //input and throws an exception if the number is negative.
    //Handle the exception in the calling code.
    class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message) : base(message) { }
    }
    class Question3
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter an integer: ");
                int number = Convert.ToInt32(Console.ReadLine());

            }

            catch(NegativeNumberException ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }

            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid integer!");
            }

            Console.ReadLine();
        }

        static void CheckNumber(int number)
        {
            if (number < 0)
            {
                throw new NegativeNumberException("Negative number is not allowed!");
            }

            else
            {
                Console.WriteLine($"You entered: {number}");
            }

            Console.ReadLine();
        }
    }
    
}
