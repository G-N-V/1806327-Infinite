using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class strings
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Enter a word: ");
            string word = Console.ReadLine();
            int length = word.Length;
            Console.WriteLine("Length of word is {0}", length);

            Console.WriteLine("------------------------------------------------------------------");

            //Question 2
            Console.WriteLine("Enter a word: ");
            string Word = Console.ReadLine();
            string reversedWord = new string(Word.Reverse().ToArray());
            Console.WriteLine("The Reversed word is: {0}", reversedWord);

            Console.WriteLine("------------------------------------------------------------------");

            //Question 3
            Console.WriteLine("Enter first word: ");
            string word1 = Console.ReadLine();

            Console.WriteLine("Enter second word: ");
            string word2 = Console.ReadLine();

            if (word1.Equals(word2))
                Console.WriteLine("Both the words are same!");
            else
                Console.WriteLine("Both the words are NOT same!");    
            
            //End
        }
    }
}
