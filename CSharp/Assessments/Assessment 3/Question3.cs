using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assessment_3
{
    public class Question3
    {
        public static void Main()
        {
            string filePath = "example.txt";

            string textToAppend = "This is appended text!";

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(textToAppend);
                }
                Console.WriteLine("Text has been appended!");
            }

            catch(Exception ex)
            {
                Console.WriteLine("An error occured!");
            }

            Console.ReadLine();
        }
    }
}
