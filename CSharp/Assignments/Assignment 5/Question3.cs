using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5
{
    class Question3
    {
        static void Main()
        {
            Console.Write("Enter the file path: ");
            string FilePath = Console.ReadLine();

            try
            {
                int lineCount = File.ReadAllLines(FilePath).Length;
                Console.WriteLine($"The number of lines in the file is {lineCount}");
            }

            catch(FileNotFoundException)
            {
                Console.WriteLine("The file was not found!");
            }

            catch(Exception ex)
            {
                Console.WriteLine("An error occured: "+ex.Message);
            }

            Console.ReadLine();
        }
    }
}
