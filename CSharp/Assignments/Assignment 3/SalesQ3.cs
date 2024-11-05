using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class Saledetails
    {
        public int Salesno { get; set; }
        public int Productno { get; set; }
        public double Price { get; set; }
        public DateTime Dateofsale { get; set; }
        public int Qty { get; set; }
        public double TotalAmount { get; private set; }

        public Saledetails(int salesno, int productno, double price, DateTime dateofsale, int qty)
        {
            Salesno = salesno;
            Productno = productno;
            Price = price;
            Dateofsale = dateofsale;
            Qty = qty;
            Sales();
        }

        public void Sales()
        {
            TotalAmount = Qty * Price;
        }

        public void ShowData()
        {
            Console.WriteLine($"Sales No: {Salesno}");
            Console.WriteLine($"Product No: {Productno}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Date of Sale: {Dateofsale.ToShortDateString()}");
            Console.WriteLine($"Quantity: {Qty}");
            Console.WriteLine($"Total Amount: {TotalAmount}");
        }
    }

    class SalesQ3
    {
        public static void Main()
        {
            Console.Write("Enter Sales No: ");
            int salesno = int.Parse(Console.ReadLine());

            Console.Write("Enter Product No: ");
            int productno = int.Parse(Console.ReadLine());

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Date of Sale (yyyy-mm-dd): ");
            DateTime dateofsale = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            Saledetails sale = new Saledetails(salesno, productno, price, dateofsale, qty);
            sale.ShowData();

            Console.ReadLine();
        }
    }
}
