using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5
{
    class Question2
    {
        static void Main()
        {
            Console.WriteLine("Enter number of lines you want to write: ");
            int numLines = int.Parse(Console.ReadLine());

            string[] lines = new string[numLines];

            for(int i = 0; i < numLines; i++)
            {
                Console.WriteLine($"Enter line {i+1}: ");
                lines[i] = Console.ReadLine();
            }

            string filePath = "output.txt";

            try
            {
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Array of strings written succesfully!");

                string[] readText = File.ReadAllLines(filePath);
                Console.WriteLine("\nContents of the file: ");
                foreach(string line in readText)
                {
                    Console.WriteLine(line);
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine("An error occured: "+ex.Message);
            }

            Console.ReadLine();
        }
    }
}
