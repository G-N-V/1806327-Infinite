using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public float Salary { get; set; }

        public Employee(int empId, string empName, float salary)
        {
            EmpId = empId;
            EmpName = empName;
            Salary = salary;
        }
    }

    class ParttimeEmployees: Employee
    {
        public float Wages { get; set; }

        public ParttimeEmployees(int empId, string empName, float salary):base(empId, empName, salary)
        {
            Wages = wages;
        }
    }
    class Question4
    {
        static void Main()
        {
            Console.WriteLine("Enter Employee ID: ");
            int empId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employee Name: ");
            string empName = Console.ReadLine();

            Console.WriteLine("Enter Employee salary: ");
            float salary = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Part-time wages: ");
            float wages = float.Parse(Console.ReadLine());

            ParttimeEmployees parttimeEmployees = new ParttimeEmployees(empId, empName, salary);

            Console.WriteLine("Employee Details: ");
            Console.WriteLine($"ID: {parttimeEmployees.EmpId}");
            Console.WriteLine($"Name: {parttimeEmployees.EmpName}");
            Console.WriteLine($"Salary: {parttimeEmployees.Salary}");
            Console.WriteLine($"Wages: {parttimeEmployees.Wages}");

            Console.ReadLine();
        }
    }
}
