using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public interface IStudent
    {
        int studentID { get; set; }
        string Name { get; set; }

        void ShowDetails();
    }

    public class Dayscholar : IStudent
    {
        public int StudentID { get; set; }
        public string Name { get; set; }

        public void ShowDetails()
        {
            Console.WriteLine($"Dayscholar ID: {StudentID}, Name: {Name}");
        }
    }

    public class Resident : IStudent
    {
        public int StudentID { get; set; }
        public string Name { get; set; }

        public void ShowDetails()
        {
            Console.WriteLine($"Resident ID: {StudentID}, Name: {Name}");
        }
    }

    class Question5
    {
        static void Main()
        {
            Console.WriteLine("Enter details for Dayscholar: ");
            Console.WriteLine("Student ID: ");
            int dsID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Name: ");
            string dsName = Console.ReadLine();

            Dayscholar dayscholar = new Dayscholar { StudentID = dsID, Name = dsName };
            dayscholar.ShowDetails();

            Console.WriteLine("Enter Details for Resident: ");
            Console.WriteLine("Enter Student ID: ");
            int resID = int.Parse(Console.ReadLine());

            Console.WriteLine("Name: ");
            string resName = Console.ReadLine();

            Resident resident = new Resident { StudentID = resID, Name = resName };
            resident.ShowDetails();

            Console.ReadLine();
        }
    }
}
