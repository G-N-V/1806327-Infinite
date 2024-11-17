using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelConcessionLibrary
{
    public class ConcessionCalculator
    {
        public const double TotalFare = 500.0;

        public static void CalculateConcession(int age)
        {
            if(age<=5)
                Console.WriteLine("Little Champs - Free Ticket");

            else if (age > 60)
            {
                double concessionFare = TotalFare * 0.7;
                Console.WriteLine($"Senior Citizen - Calculated Fare: {concessionFare}");
            }

            else
                Console.WriteLine($"Ticket Booked - Fare: {TotalFare}");
        }
    }
}
