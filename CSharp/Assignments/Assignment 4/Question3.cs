using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class Doctor
    {
        private int regnNo;
        private string name;
        private double feesCharged;

        public int RegnNo
        {
            get { return regnNo; }
            set { regnNo = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double FeesCharged
        {
            get { return feesCharged; }
            set { feesCharged = value; }
        }
    }

    public class Book
    {
        private string _bookname;
        private string _authorName;

        public string BookName
        {
            get { return _bookname; }
            set { _bookname = value; }
        }

        public string AuthorName
        {
            get { return _authorName; }
            set { _authorName = value; }
        }

        public Book(string bookName, string authorName)
        {
            _bookname = bookName;
            _authorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book: {_bookname}, Author: {_authorName}");
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
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }
            }
        }

        public void DisplayBooks()
        {
            foreach(Book book in books)
            {
                if (book != null)
                    book.Display();
            }
        }
    }
    class Question3
    {
        static void Main()
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("Enter Doctor's Registration Number: ");
            doctor.RegnNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Doctor's Name: ");
            doctor.Name = Console.ReadLine();

            Console.WriteLine("Enter Doctor fee charged: ");
            doctor.FeesCharged = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Doctor Details: ");
            Console.WriteLine($"Regn No: {doctor.RegnNo}, Name: {doctor.Name}, Fees Charged: {doctor.FeesCharged}");


            BookShelf bookShelf = new BookShelf();
            for(int i=0; i<5; i++)
            {
                Console.WriteLine($"Enter details for book {i+1}:");
                Console.Write("Enter Book Name: ");
                string bookName = Console.ReadLine();

                Console.WriteLine("Enter Author Name: ");
                string authorName = Console.ReadLine();

                bookShelf[i] = new Book(bookName, authorName);
                Console.WriteLine();
            }
            Console.WriteLine("Books in the BookShelf: ");
            bookShelf.DisplayBooks();

            Console.ReadLine();
        }
    }
}
