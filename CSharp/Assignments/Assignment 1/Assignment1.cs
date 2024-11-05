using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Assignment1
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("1. Write a C# program to accept two integers and check whether they are equal or not.");

            Console.WriteLine("Input 1st Number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input 2nd Number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            if (num1 == num2)
            {
                Console.WriteLine("{0} and {1} are equal", num1, num2);
            }

            else
            {
                Console.WriteLine("{0} and {1} are not equal", num1, num2);
            }

            
            Console.WriteLine("-----------------------------------------------------------");

            //Question 2
            Console.WriteLine("2. Write a C# program to check whether a given number is positive or negative");

            Console.WriteLine("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num >=0)
                Console.WriteLine("{0} is a positive number", num);
            else
                Console.WriteLine("{0} is a negative number", num);


            Console.WriteLine("-----------------------------------------------------------");


            //Question 3
            Console.WriteLine("3. Write a C# program that takes two numbers as input and performs all operations +,-,/,* on them and displays the result of that operation.");

            Console.WriteLine("Input First Number: ");
            double number1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Input Second Number: ");
            double number2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Input operation (+,-,*,/): ");
            char operation = Console.ReadLine()[0];

            double answer = 0;

            if(operation == '+')
            {
                answer = number1 + number2;
                Console.WriteLine("{0} + {1} = {2}", number1, number2, answer);
            }

            else if(operation == '-')
            {
                answer = number1 - number2;
                Console.WriteLine("{0} - {1} = {2}", number1, number2, answer);
            }

            else if(operation == '*')
            {
                Console.WriteLine("{0} * {1} = {2}", number1, number2, answer);
            }

            else if(operation == '/')
            {
                Console.WriteLine("{0} / {1} = {2}", number1, number2, answer);
            }

            else
            {
                Console.WriteLine("Invalid Operation!");
            }

            Console.WriteLine("-----------------------------------------------------------");


            //Question 4
            Console.WriteLine("4.Write a C# program that prints the multiplication table of a number as input.");

            Console.WriteLine("Enter the number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Expected Output: ");

            for(int i=0; i<=10; i++)
            {
                Console.WriteLine(number + "x" + i + "=" + (number * i));
            }

            Console.WriteLine("-----------------------------------------------------------");


            //Question 5
            Console.WriteLine("5. Write a C# program to compute the sum of two given integers. If two values are the same, return the triple of their sum.");

            Console.WriteLine("Enter first number: ");
            int first_num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            int second_num = Convert.ToInt32(Console.ReadLine());

            int sum = first_num + second_num;

            if(first_num == second_num)
            {
                sum = sum * 3;
            }

            Console.WriteLine("Sum of the numbers: {0}", sum);
            Console.ReadLine();
        }
    }
}
