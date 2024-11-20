using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3
{
    public class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

        public Box() { }

        public Box(double Length, double Breadth)
        {
            
        }

        public static Box operator +(Box b1, Box b2)
        {
            return new Box(b1.Length + b2.Length, b1.Breadth+b2.Breadth);
        }

        public void Display()
        {
            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
        }
    }

    public class TestBox
    {
        public static void Main()
        {
            Console.Write("Enter length for Box 1: ");
            double length1 = double.Parse(Console.ReadLine());

            Console.Write("Enter breadth for Box 1: ");
            double breadth1 = double.Parse(Console.ReadLine());

            Box box1 = new Box(length1, breadth1);

            Console.Write("Enter Length for Box 2: ");
            double length2 = double.Parse(Console.ReadLine());

            Console.Write("Enter breadth for Box 2: ");
            double breadth2 = double.Parse(Console.ReadLine());

            Box box2 = new Box(length2, breadth2);

            Box box3 = box1 + box2;

            Console.WriteLine("\nDetails of Box 1: ");
            box1.Display();

            Console.WriteLine("\nDetails of Box 2: ");
            box2.Display();

            Console.WriteLine("\nDetails of Box 3: ");
            box3.Display();

            Console.ReadLine();
        }
    }
    class Question2
    {
    }
}
