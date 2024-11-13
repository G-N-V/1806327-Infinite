using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    //Q2.Create a Class called Products with Productid, Product Name, Price.
    //Accept 10 Products, sort them based on the price, and display the sorted Products.

    class Products
    {
        public int Productid { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }

        public Products(int productID, string productName, float price)
        {
            Productid = productID;
            ProductName = productName;
            Price = price;
        }
    }
    class Question2
    {

        static void Main()
        {
            List<Products> productList = new List<Products>();

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"\nEnter details for product {i+1}: ");
                Console.Write("Product ID: ");
                int productID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Product Price: ");
                float price = float.Parse(Console.ReadLine());

                productList.Add(new Products(productID, productName, price));
            }

            for(int i = 0; i < productList.Count - 1; i++)
            {
                for(int j = 0; j < productList.Count - i - 1; j++)
                {
                    if (productList[j].Price > productList[j + 1].Price)
                    {
                        var temp = productList[j];
                        productList[j] = productList[j + 1];
                        productList[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\nSorted Products by Price: ");
            foreach(var product in productList)
                Console.WriteLine($"ID: {product.Productid}, Name: {product.ProductName}, Price: {product.Price}");

            Console.ReadLine();
        }
    }
}
