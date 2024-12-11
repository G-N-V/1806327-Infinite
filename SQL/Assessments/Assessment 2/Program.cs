using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADOProc
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static IDataReader dr;
        static void Main(string[] args)
        {
            InsertData();
            SelectData();
            Console.ReadLine();
        }

        static SqlConnection getConnection()
        {
            con = new SqlConnection(@"Data Source = ICS-LT-D244D6GR\SQLEXPRESS;Initial Catalog=assessment2;" + "Integrated Security=true;");
            con.Open();
            Console.WriteLine("Connected Successfully!");
            return con;
        }

        static void InsertData()
        {
            Console.WriteLine("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter Price: ");
            int price = Convert.ToInt32(Console.ReadLine());
            con = getConnection();
            cmd = new SqlCommand("ProdDetailsInsertion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", productName);
            cmd.Parameters.AddWithValue("@Price", price);

            SqlParameter productIdParam = new SqlParameter("@ProductID" ,SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            cmd.Parameters.Add(productIdParam);

            cmd.ExecuteNonQuery();

            int newProductId = (int)productIdParam.Value;

            Console.WriteLine("Product ID : "+newProductId);

            cmd = new SqlCommand("SELECT DiscountedPrice FROM ProductsDetails WHERE ProductID = @ProductID", con);
            cmd.Parameters.AddWithValue("@ProductID", newProductId);

            decimal discountedPrice = (decimal)cmd.ExecuteScalar();
            Console.WriteLine("Discounted Price: "+discountedPrice);
        }

        static void SelectData()
        {
            con = getConnection();
            cmd = new SqlCommand("SELECT * FROM ProductDetails", con);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine(dr["ProductID"]+" "+dr["ProductName"]+" "+dr["Price"]+" "+dr["DiscountedPrice"]);

            }
        }
    }
}
