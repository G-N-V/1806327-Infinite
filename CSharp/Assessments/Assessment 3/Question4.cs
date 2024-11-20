using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3
{
    public delegate int CalculatorDelegate(int x, int y);

    public class Calculator
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Subtract(int x, int y)
        {
            return x - y;
        }

        public static int Multiply(int x, int y)
        {
            return x * y;
        }

        
    }
    public class Question4
    {
        public static void Main()
        {
            Console.Write("Enter the first integer: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the second integer: ");
            int num2 = int.Parse(Console.ReadLine());

            CalculatorDelegate calcDelegate;

            Console.WriteLine("---------------Result-----------------");
            calcDelegate = new CalculatorDelegate(Calculator.Add);
            int additionResult = calcDelegate(num1, num2);
            Console.WriteLine($"Addition of {num1} + {num2} = {additionResult}");

            calcDelegate = new CalculatorDelegate(Calculator.Subtract);
            int subtractionResult = calcDelegate(num1, num2);
            Console.WriteLine($"Subtraction of {num1} - {num2} = {subtractionResult}");

            calcDelegate = new CalculatorDelegate(Calculator.Multiply);
            int multiplyResult = calcDelegate(num1, num2);
            Console.WriteLine($"Multiplication of {num1} X {num2} = {multiplyResult}");

            Console.ReadLine();
        }
    }
}
