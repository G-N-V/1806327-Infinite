using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class Student
    {
        private int rollNo;
        private string name;
        private string studentClass;
        private string semester;
        private string branch;
        private int[] marks = new int[5];

        public Student(int rollNo, string name, string studentClass, string semester, string branch)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.studentClass = studentClass;
            this.semester = semester;
            this.branch = branch;

        }

        public void GetMarks()
        {
            for(int i=0; i<marks.Length; i++)
            {
                Console.WriteLine("Enter marks for subject{0}: ", i+1);
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            int total = 0;
            bool isFailed = false;

            for(int i=0; i < marks.Length; i++)
            {
                if (marks[i] < 35)
                    isFailed = true;
                total = total + marks[i];
            }

            double average = total / 5;

            if(isFailed)
                Console.WriteLine("Result: Failed as less than 35 in one or more subjects");

            else if(average>50)
                Console.WriteLine("Result: Failed as average less than 50");

            else
                Console.WriteLine("Result: Passed!");
        }

        public void DisplayData()
        {
            Console.WriteLine("Roll No.: "+rollNo);
            Console.WriteLine("Name: "+name);
            Console.WriteLine("Class: "+studentClass);
            Console.WriteLine("Semester: "+semester);
            Console.WriteLine("Branch: "+branch);
            Console.WriteLine("Marks: " +string.Join(", ",marks));
        }
    }
    class StudentQ2
    {
        static void Main()
        {
            Console.WriteLine("Enter Roll No.: ");
            int rollNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Class: ");
            string studentClass = Console.ReadLine();

            Console.WriteLine("Enter Semester");
            string semester = Console.ReadLine();

            Console.WriteLine("Enter Branch: ");
            string branch = Console.ReadLine();

            Student student = new Student(rollNo, name, studentClass, semester, branch);

            student.GetMarks();
            student.DisplayData();
            student.DisplayResult();

            Console.ReadLine();
        }
    }
}
