using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2 
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Enter First Number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Second Number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int temp;
            temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine("Values after swapping First Number: {0} and Second Number: {1}", num1, num2);
            Console.ReadLine();

            Console.WriteLine("----------------------------------------------------------");

            //Question 2
            Console.WriteLine("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Output: ");

            for(int i=0; i<2; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();

                for (int j = 0; j < 4; j++)
                {
                    Console.Write(number);
                }
                Console.WriteLine();
                Console.ReadLine();
            }

            Console.WriteLine("------------------------------------------------------------");

            //Question 3

            Console.WriteLine("Enter a day number: ");
            int daynumber = Convert.ToInt32(Console.ReadLine());

            string dayname;

            switch (daynumber)
            {
                case 1:
                    dayname = "Monday";
                    break;
                case 2:
                    dayname = "Tuesday";
                    break;
                case 3:
                    dayname = "Wednesday";
                    break;
                case 4:
                    dayname = "Thursday";
                    break;
                case 5:
                    dayname = "Friday";
                    break;
                case 6:
                    dayname = "Saturday";
                    break;
                case 7:
                    dayname = "Sunday";
                    break;
                default:
                    dayname = "Invalid number";
                    break;
            }
            Console.WriteLine(dayname);

            Console.WriteLine("-----------------------------------------------------------");
            //Arrays
            //Question 1

            int[] array = { 10, 5, 20, 15, 25 };
            double average = 0;
            int sum = 0;
            int min_value = array[0];
            int max_value = array[0];
            

            foreach(int value in array)
            {
                sum = sum + value;
                if (value < min_value)
                    min_value = value;
                if (value > max_value)
                    max_value = value;
            }

            average = sum / array.Length;

            Console.WriteLine("Average Value: " + average);
            Console.WriteLine("Minimum Value: " + min_value);
            Console.WriteLine("Maximum Value: " + max_value);

            Console.WriteLine("-----------------------------------------------------------");

            //Question 2
            int[] marks = new int[10];
            Console.WriteLine("Enter 10 marks: ");
            for(int i = 0; i < marks.Length; i++)
            {
                Console.Write("Mark " + (i + 1) + ": ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }

            int totalMarks = 0;
            double averageMarks = 0;
            int minMarks = marks[0];
            int maxMarks = marks[0];

            for(int i = 0; i < marks.Length; i++)
            {
                totalMarks = totalMarks + marks[i];

                if (marks[i] < minMarks)
                    minMarks = marks[i];
                if (marks[i] > maxMarks)
                    maxMarks = marks[i];
            }
            averageMarks = totalMarks / marks.Length;

            Console.WriteLine("Total Marks: " + totalMarks);
            Console.WriteLine("Average Marks: " + averageMarks);
            Console.WriteLine("Minimum Marks: " + minMarks);
            Console.WriteLine("Maximum Marks: " + maxMarks);

            Array.Sort(marks);
            Console.WriteLine("Marks in Ascending Order: " + string.Join(", ", marks));

            Array.Reverse(marks);
            Console.WriteLine("Marks in Descending Order: " + string.Join(", ", marks));

            Console.WriteLine("------------------------------------------------------------");

            //Question 3

            Console.WriteLine("Enter the number of elements: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] originalArray = new int[size];
            int[] copyArray = new int[size];

            Console.WriteLine("Enter values for original array: ");
            for(int i = 0; i < size; i++)
            {
                Console.Write("Element-{0} ", i + 1);
                originalArray[i] = Convert.ToInt32(Console.ReadLine());
            }

            for(int i=0; i<size; i++)
            {
                copyArray[i] = originalArray[i]; 
            }

            Console.WriteLine("\nElements in the copy array: ");
            for(int i=0; i<size; i++)
            {
                Console.Write(copyArray[i] + " "); 
            }
            Console.ReadLine();

            //End
        }
    }
}
