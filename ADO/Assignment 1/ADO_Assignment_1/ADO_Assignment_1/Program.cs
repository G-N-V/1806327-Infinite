using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assignment_1
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee{EmployeeId = 1001, FirstName = "Malcolm", LastName="Daruwalla", Title="Manager", DOB=new DateTime(1984,11,16), DOJ=new DateTime(2011,6,8), City="Mumbai" },
                new Employee{EmployeeId = 1002, FirstName = "Asdin", LastName="Dhalla", Title="AsstManager",DOB=new DateTime(1984,8,20), DOJ=new DateTime(2012,7,7), City="Mumbai" },
                new Employee{EmployeeId = 1003, FirstName = "Madhavi", LastName="Oza", Title="Consultant",DOB=new DateTime(1987,11,14), DOJ=new DateTime(2015,4,12), City="Pune" },
                new Employee{EmployeeId = 1004, FirstName = "Saba", LastName="Shaik", Title="SE",DOB=new DateTime(1990,6,3), DOJ=new DateTime(2016,2,2), City="Pune" },
                new Employee{EmployeeId = 1005, FirstName = "Naiza", LastName="Shaik", Title="SE",DOB=new DateTime(1991,3,8), DOJ=new DateTime(2016,2,2), City="Mumbai" },
                new Employee{EmployeeId = 1006, FirstName = "Amit", LastName="Pathak", Title="Consultant",DOB=new DateTime(1989,11,7), DOJ=new DateTime(2014,8,8), City="Chennai" },
                new Employee{EmployeeId = 1007, FirstName = "Vijay", LastName="Natarajan", Title="Consultant",DOB=new DateTime(1989,12,2), DOJ=new DateTime(2015,6,1), City="Mumbai" },
                new Employee{EmployeeId = 1008, FirstName = "Rahul", LastName="Dubey", Title="Associate",DOB=new DateTime(1993,11,11), DOJ=new DateTime(2014,11,6), City="Chennai" },
                new Employee{EmployeeId = 1009, FirstName = "Suresh", LastName="Mistry", Title="Associate",DOB=new DateTime(1992,8,12), DOJ=new DateTime(2014,12,3), City="Chennai" },
                new Employee{EmployeeId = 1010, FirstName = "Sumit", LastName="Shah", Title="Manager",DOB=new DateTime(1991,4,12), DOJ=new DateTime(2016,1,2), City="Pune" }

            };

            //1.
            var empDOJBefore2015 = empList.Where(e => e.DOJ < new DateTime(2015, 1, 1));
            Console.WriteLine("Employees DOJ before 2015 below: ");
            foreach(var employee in empDOJBefore2015)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, DOJ: {employee.DOJ.ToShortDateString()}, City: {employee.City}");
            }

            //2.
            var DOBAfter1990 = empList.Where(e => e.DOB > new DateTime(1990, 1, 1));
            Console.WriteLine("Employees DOB After 1990: ");
            foreach(var employee in DOBAfter1990)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, DOB: {employee.DOB.ToShortDateString()}, City: {employee.City}");
            }

            //3.
            var consulAndAssoc = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate");
            Console.WriteLine("Employees with Job title as Consultants or Associates: ");
            foreach(var employee in consulAndAssoc)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, City: {employee.City}");
            }

            //4.
            int totalEmpCount = empList.Count;
            Console.WriteLine("Total number of Employees: {totalEmpCount}");

            //5.
            int totalEmpInChennai = empList.Count(e => e.City == "Chennai");
            Console.WriteLine("Total Employee Count in Chennai: {totalEmpInChennai}");

            //6.
            int highestEmpID = empList.Max(e => e.EmployeeId);
            Console.WriteLine($"Highest Employee ID: {highestEmpID}");

            //7.
            int empCountAfter2015 = empList.Count(e => e.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"Total Employees joined after 2015: {empCountAfter2015}");

            //8.
            int empNotAssociates = empList.Count(e => e.Title != "Associate");
            Console.WriteLine("Total number of Employees who are not Associates: {empNotAssociates}");

            //9.
            var empByCity = empList.GroupBy(e => e.City).Select(group => new { City = group.Key, Count = group.Count() });
            Console.WriteLine("Total number of Employees based on City: ");
            foreach(var group in empByCity)
            {
                Console.WriteLine($"{group.City}:{group.Count}");
            }

            //10.
            var empByCityAndTitle = empList.GroupBy(e => new { e.City, e.Title }).Select(group => new { group.Key.City, group.Key.Title, Count = group.Count() });
            Console.WriteLine("Total number of Employees based on City and Title: ");
            foreach(var group in empByCityAndTitle)
            {
                Console.WriteLine($"{group.City} - {group.Title}:{group.Count}");
            }

            //11.
            var youngestEmp = empList.OrderByDescending(e => e.DOB).First();
            Console.WriteLine($"\nYoungest Employee: ID: {youngestEmp.EmployeeId}, Name:{youngestEmp.FirstName} {youngestEmp.LastName}, Title: {youngestEmp.Title}, DOB: {youngestEmp.DOB.ToShortDateString()}, City: {youngestEmp.City}");

            Console.ReadLine();
        }
    }
}
