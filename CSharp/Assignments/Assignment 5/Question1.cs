using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    public class Book
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Book(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }
        public void Display()
        {
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
        }
    }

    public class BookShelf
    {
        private Book[] books = new Book[5];

        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < books.Length)
                    return books[index];

                throw new IndexOutOfRangeException("Index out of range!");
            }

            set
            {
                if (index >= 0 && index < books.Length)
                    books[index] = value;

                else
                    throw new IndexOutOfRangeException("Index out of range!");
            }
        }

        public void DisplayBooks()
        {
            foreach(Book book in books)
            {
                if (book != null)
                {
                    book.Display();
                }
            }
        }
    }
    class Question1
    {
        static void Main(string[] args)
        {
            BookShelf bookShelf = new BookShelf();
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter details for book {i + 1}: ");

                Console.WriteLine("Enter Book Name: ");
                string bookName = Console.ReadLine();

                Console.WriteLine("Enter Author Name: ");
                string authorName = Console.ReadLine();

                bookShelf[i] = new Book(bookName, authorName);
                Console.WriteLine();
            }

            Console.WriteLine("Books in the Bookshelf: ");
            bookShelf.DisplayBooks();

            Console.ReadLine();
        }
    }
}
