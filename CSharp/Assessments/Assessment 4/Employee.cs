using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_4
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string City { get; set; }

    }
    class Program
    {
        static void Main()
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee{EmployeeId = 1001, FirstName = "Malcolm", LastName="Daruwalla", Title="Manager", City="Mumbai" },
                new Employee{EmployeeId = 1002, FirstName = "Asdin", LastName="Dhalla", Title="AsstManager", City="Mumbai" },
                new Employee{EmployeeId = 1003, FirstName = "Madhavi", LastName="Oza", Title="Consultant", City="Pune" },
                new Employee{EmployeeId = 1004, FirstName = "Saba", LastName="Shaik", Title="SE", City="Pune" },
                new Employee{EmployeeId = 1005, FirstName = "Naiza", LastName="Shaik", Title="SE", City="Mumbai" },
                new Employee{EmployeeId = 1006, FirstName = "Amit", LastName="Pathak", Title="Consultant", City="Chennai" },
                new Employee{EmployeeId = 1007, FirstName = "Vijay", LastName="Natarajan", Title="Consultant", City="Mumbai" },
                new Employee{EmployeeId = 1008, FirstName = "Rahul", LastName="Dubey", Title="Associate", City="Chennai" },
                new Employee{EmployeeId = 1009, FirstName = "Suresh", LastName="Mistry", Title="Associate", City="Chennai" },
                new Employee{EmployeeId = 1010, FirstName = "Sumit", LastName="Shah", Title="Manager", City="Pune" }

            };

            //a.Display details of all employees
            var allEmployees = empList.Select(e => e);
            Console.WriteLine("All employees: ");
            foreach(var employee in allEmployees)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, Location: {employee.City}");
            }

            //b.Display details of all employees whose location is not Mumbai
            var employeesNotInMumbai = empList.Where(e => e.City != "Mumbai");
            Console.WriteLine("\nEmployees not in Mumbai");
            foreach(var employee in employeesNotInMumbai)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, Location: {employee.City}");
            }

            //c.Display details of all employees whose title is AsstManager
            var asstManagers = empList.Where(e => e.Title == "AsstManager");
            Console.WriteLine("\nAssistant Managers: ");
            foreach(var employee in asstManagers)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, Location: {employee.City}");
            }

            //d. Display details of all employees whose last name starts with S
            var employeeLastName = empList.Where(e => e.LastName.StartsWith("S"));
            Console.WriteLine("\nEmployees whose last name starts with S: ");
            foreach(var employee in employeeLastName)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, Location: {employee.City}");
            }

            Console.ReadLine();
        }
    } 
}
