using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentID { get; set; }
        public float Grade { get; set; }

        public Student(string name, int studentID, float grade)
        {
            Name = name;
            StudentID = studentID;
            Grade = grade;
        }

        public abstract bool IsPassed(float grade);
    }

    class Undergraduate: Student
    {
        public Undergraduate(string name, int studentID, float grade) : base(name, studentID, grade)
        {

        }

        public override bool IsPassed(float grade)
        {
            return grade > 70;
        }

    }

    class Graduate : Student
    {
        public Graduate(string name, int studentID, float grade) : base(name, studentID, grade)
        {

        }

        public override bool IsPassed(float grade)
        {
            return grade > 80;
        }
    }
    class Question1
    {
        static void Main()
        {
            Console.WriteLine("Enter details for Undergraduate student: ");
            Console.WriteLine("Name: ");
            string undergradName = Console.ReadLine();

            Console.WriteLine("Student ID: ");
            int undergradID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Grade: ");
            float undergradGrade = float.Parse(Console.ReadLine());

            Undergraduate undergrad = new Undergraduate(undergradName, undergradID, undergradGrade);

            if (undergrad.IsPassed(undergrad.Grade))
                Console.WriteLine("Undergraduate student has passed!");

            else
                Console.WriteLine("Undergraduate has not passed!");


            Console.WriteLine("\nEnter details for Graduate Student: ");
            Console.WriteLine("Name: ");
            string gradName = Console.ReadLine();

            Console.WriteLine("Student ID: ");
            int gradID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Grade: ");
            float gradGrade = float.Parse(Console.ReadLine());

            Graduate grad = new Graduate(gradName, gradID, gradGrade);

            if (grad.IsPassed(grad.Grade))
                Console.WriteLine("Graduate Student has passed!");

            else
                Console.WriteLine("Graduate Student has not passed!");

            Console.ReadLine();
        }
    }
}
