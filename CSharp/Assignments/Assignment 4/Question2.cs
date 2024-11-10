using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class Scholarship
    {
        public void Merit(int marks, double fees)
        {
            double scholarshipAmount = 0;

            if (marks >= 70 && marks <= 80)
                scholarshipAmount = 0.20 * fees;

            else if (marks > 80 && marks < 90)
                scholarshipAmount = 0.30 * fees;
            else if (marks > 90)
                scholarshipAmount = 0.50 * fees;

            Console.WriteLine("Scholarship Amount: " + scholarshipAmount);

        }
    }
    class Question2
    {
        static void Main()
        {
            Console.WriteLine("Enter Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter fees: ");
            double fees = Convert.ToDouble(Console.ReadLine());

            Scholarship scholarship = new Scholarship();

            scholarship.Merit(marks, fees);

            Console.WriteLine("/nPress any key to exit");

            Console.ReadLine();
        }
    }
}
