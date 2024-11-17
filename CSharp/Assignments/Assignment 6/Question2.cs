using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Question2
    {
        static void Main()
        {
            Console.WriteLine("Enter words separated by spaces: ");
            string input = Console.ReadLine().ToLower();

            List<string> result = new List<string>();

            string word = "";

            for(int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == ' ')
                {
                    if (word.Length > 0 && word[0] == 'a' && word[word.Length - 1] == 'm')
                        result.Add(word);

                    word = "";
                }

                else
                    word = word + c;
            }

            Console.WriteLine("Words starting with a and ending with m: ");

            foreach(string res in result)
            {
                Console.WriteLine(res);
            }

            Console.ReadLine();
        }
    }
}
