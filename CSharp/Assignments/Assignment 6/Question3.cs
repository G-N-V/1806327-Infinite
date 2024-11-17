using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }
    class Question3
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();

            Console.Write("Enter the number of employees: ");
            int numEmployees = int.Parse(Console.ReadLine());

            for(int i = 0; i < numEmployees; i++)
            {
                Employee emp = new Employee();

                Console.WriteLine($"\nEnter details for Employee {i+1}:");
                Console.Write("EmpID: ");
                emp.EmpID = int.Parse(Console.ReadLine());

                Console.Write("EmpName: ");
                emp.EmpName = Console.ReadLine();

                Console.Write("EmpCity: ");
                emp.EmpCity = Console.ReadLine();

                Console.Write("Emp Salary: ");
                emp.EmpSalary = double.Parse(Console.ReadLine());

                employees.Add(emp);
            }
            Console.WriteLine("\nAll Employees data: ");
            DisplayEmployees(employees);


            Console.WriteLine("/nEmployees with salary>45000: ");
            List<Employee> highSalaryEmployees = new List<Employee>();
            foreach(var emp in employees)
            {
                if (emp.EmpSalary > 45000)
                {
                    highSalaryEmployees.Add(emp);
                }
            }
            DisplayEmployees(highSalaryEmployees);


            Console.WriteLine("\nEmployees from Bangalore: ");
            List<Employee> bangaloreEmployees = new List<Employee>();
            foreach(var emp in employees)
            {
                if (emp.EmpCity.ToUpper() == "BANGALORE")
                    bangaloreEmployees.Add(emp);
            }
            DisplayEmployees(bangaloreEmployees);


            Console.WriteLine("\nEmployees Data sorted by Name (Ascending): ");
            employees.Sort((x, y) => string.Compare(x.EmpName, y.EmpName));
            DisplayEmployees(employees);

            Console.ReadLine();
        }

        static void DisplayEmployees(List<Employee> employees)
        {
            foreach(var emp in employees)
            {
                Console.WriteLine($"ID: {emp.EmpID}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
            }
        }
        
    }
}
