using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3
{
    //Question-1
    public class CricketTeam
    {
        public(int Count, double Average, int sum) PointsCalculation(int no_of_matches)
        {
            int sum = 0;
            List<int> scores = new List<int>();

            for(int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Enter score for match {i + 1}: ");
                int score = int.Parse(Console.ReadLine());
                scores.Add(score);
                sum = sum + score;
            }

            double average = sum / no_of_matches;
            return (no_of_matches, average, sum);
        }
    }
    class Question1
    {
        static void Main(string[] args)
        {
            CricketTeam team = new CricketTeam();

            Console.Write("Enter the number of matches: ");
            int no_of_matches = int.Parse(Console.ReadLine());

            var result = team.PointsCalculation(no_of_matches);

            Console.WriteLine($"Count of matches: {result.Count}");
            Console.WriteLine($"Sum of scores: {result.sum}");
            Console.WriteLine($"Average score: {result.Average}");

            Console.ReadLine();
        }
    }
}
