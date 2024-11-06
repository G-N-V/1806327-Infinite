using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    class Question3
    {
        static void Main()
        {
            Console.WriteLine("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter third number: ");
            int num3 = Convert.ToInt32(Console.ReadLine());

            int largest = num1;

            if (num2 > largest)
                largest = num2;

            if (num3 > largest)
                largest = num3;

            Console.WriteLine("The largest number is: "+largest);

            Console.ReadLine();
        }
    }
}
