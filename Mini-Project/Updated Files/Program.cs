using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TrainReservation
{
    class Program
    {
        static SqlConnection con;
        static bool isAdmin = false;
        static string userName = "";
        static int userID;

        static SqlConnection getConnection()
        {
            con = new SqlConnection(@"Data Source=ICS-LT-D244D6GR\SQLEXPRESS;Initial Catalog=TrainReservationSystem;Integrated Security=true;");
            con.Open();
            return con;
        }


        static void Main(string[] args)
        {
            con = getConnection();
            
            Console.WriteLine("Welcome to the NV Train Reservation System!");

            Console.Write("What is your name?: ");
            string responseName = Console.ReadLine();
            Console.WriteLine($"Welcome {responseName}");


            if (responseName == "Admin")
            {
                Console.Write("Are you an AdminUser? (yes/no): ");
                string response = Console.ReadLine().ToLower();
                if (response == "yes")
                {
                    VerifyAdmin();
                }
                else
                {
                    Console.WriteLine($"Please Try Again, {responseName}");
                }
                
            }


            if (!isAdmin)
            {
                Console.Write("Are you an existing user? (yes/no): ");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    UserLogin();
                }

                else if (answer == "no")
                {
                    RegisterUser();
                }

                else
                {
                    Console.WriteLine("Invalid Response. Please try again!");
                }

            }        


            if (isAdmin||userID > 0)
            {
                Console.WriteLine("Type help to view available commands");
                ShowHelp();

                while (true)
                {
                    Console.Write("\n>");
                    string input = Console.ReadLine().Trim();
                    string[] commandParts = input.Split(' ');
                    string command = commandParts[0].ToLower();

                    switch (command)
                    {
                        case "help":
                            ShowHelp();
                            break;

                        case "viewtrains":
                            ViewTrains();
                            break;

                        case "bookticket":
                            BookTicket();
                            break;

                        case "viewbookings":
                            if (isAdmin)
                                AdminViewAllBookings();
                            else
                                ViewBookings();
                            break;

                        case "ticketdetails":
                            if (isAdmin) AdminViewAllTicketDetails();
                            else DisplayTickets();
                            break;

                        case "viewcancelledbookings":
                            if (isAdmin) AdminViewAllCancelledBookings();
                            else ViewCancelledBookings();
                            break;

                        case "checkavailability":
                            CheckAvailability();
                            break;

                        case "cancelbooking":
                            CancelBooking();
                            break;

                        case "addtrain":
                            if (isAdmin)
                                AddTrain();
                            else
                                Console.WriteLine("Need to be an Admin to access this section");
                            break;

                        case "updatetrain":
                            if (isAdmin)
                                UpdateTrain();
                            else
                                Console.WriteLine("Need to be an Admin to access this section");
                            break;

                        case "deletetrain":
                            if (isAdmin)
                                SoftDeleteTrain();
                            else
                                Console.WriteLine("Need to be an Admin to access this section");
                            break;

                        case "viewallusers":
                            if (isAdmin) AdminViewAllUsers();
                            else Console.WriteLine("Admin Privileges required to view all users!");
                            break;

                        case "exit":
                            Console.WriteLine("Thank you for using the NV Train Reservation System!");
                            return;
                        default:
                            Console.WriteLine("Unknown Command. Type 'help' to see the available commands!");
                            break;
                    }
                }

            }  
        }

        static void VerifyAdmin()
        {
            
                Console.Write("Enter Admin Password: ");
                string password = Console.ReadLine();
                if (password == "Admin@123")
                {
                    isAdmin = true;
                    Console.WriteLine("Admin Verified!");
                }
                else
                {
                    Console.WriteLine("Incorrect credentials!");
                } 
        }

        static void RegisterUser()
        {
            try
            {
                Console.Write("Enter your Name: ");
                string name = Console.ReadLine().Trim();

                Console.Write("Enter User Name: ");
                string userName = Console.ReadLine().Trim();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine().Trim();

                using(SqlCommand cmd = new SqlCommand("RegisterUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Password", password);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userID = Convert.ToInt32(result);
                        Console.WriteLine($"Registration Successful! Your User ID is : {userID}");
                    }
                    else
                    {
                        Console.WriteLine("Registration Failed. Please try again!");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occured during registration: {ex.Message}");
            }
        }


        static void UserLogin()
        {
            try
            {
                Console.Write("Enter User Name: ");
                string userName = Console.ReadLine().Trim();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine().Trim();
                
                using(SqlCommand cmd = new SqlCommand("UserLogin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Password", password);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userID = Convert.ToInt32(result);
                        Console.WriteLine($"Login Successful! Your User ID is : {userID}");
                    }
                    else
                    {
                        Console.WriteLine("Login Failed. Invalid Username or Password!");
                    }
                }
            }
            catch(SqlException ex)
            {
                if (ex.Number == 50000)
                {
                    Console.WriteLine(ex.Message);
                }
                else
                {
                    Console.WriteLine("An error occured during login: {ex.Message}");
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred during login: {ex.Message}");
            }
        }


        static void ShowHelp()
        {
            Console.WriteLine("\nAvailable Commands:");
            Console.WriteLine("help                     -> Show this Help Message");
            Console.WriteLine("viewtrains               -> View all Trains");
            Console.WriteLine("bookticket               -> Book a Ticket");
            Console.WriteLine("viewbookings             -> View all Bookings");
            Console.WriteLine("ticketdetails            -> View Ticket Details");
            Console.WriteLine("viewcancelledbookings    -> View all Cancelled Bookings");
            Console.WriteLine("checkavailability        -> Check Seat Availability");
            Console.WriteLine("cancelbooking            -> Cancel a Booking");

            if (isAdmin)
            {
                Console.WriteLine("addtrain                 -> Add a new Train");
                Console.WriteLine("updatetrain              -> Update Train Details");
                Console.WriteLine("deletetrain              -> Delete a Train");
                Console.WriteLine("viewallusers             -> View all Users info");
            }
            Console.WriteLine("exit                     -> Exit the Application");
        }


        static void ViewTrains()
        {
            try
            {
                using(SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("ViewTrains", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Connection = con;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nTrains:");
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["TrainID"]}, Number: {reader["TrainNumber"]}, Name:{reader["TrainName"]}, Source: {reader["Source"]}, Destination: {reader["Destination"]}");

                            }
                        }
                    }
                }
               
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occured while fetching train data: {ex.Message}");
            }
        }


        static void BookTicket()
        {
            try
            {
                Console.Write("Enter Train ID: ");
                int trainID = int.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("Class ID -> Type");
                Console.WriteLine("1 -> First A/C");
                Console.WriteLine("2 -> Second A/C");
                Console.WriteLine("3 -> Third A/C");
                Console.WriteLine("4 -> Sleeper");
                Console.WriteLine();

                Console.Write("Enter Class ID: ");
                int classID = int.Parse(Console.ReadLine());

                Console.Write("Enter User ID: ");
                int userID = int.Parse(Console.ReadLine());

                Console.Write("Enter Number of Tickets: ");
                int numberOfTickets = int.Parse(Console.ReadLine());

                using(SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("BookTicket", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@TrainID", trainID);
                        cmd.Parameters.AddWithValue("@ClassID", classID);
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@NumberOfTickets", numberOfTickets);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Ticket Booked Successfully!");
                    }

                }

            }
            catch(SqlException ex)
            {
                if (ex.Number == 50000)
                {
                    Console.WriteLine(ex.Message);
                }
                else
                {
                    Console.WriteLine($"An error occured while booking ticket: {ex.Message}");
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine($"An error occured while booking ticket: {ex.Message}");
            }
  
        }


        static void ViewBookings()
        {
            try
            {
                using(SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("ViewBookings", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nBookings:");
                            while (reader.Read())
                            {
                                Console.WriteLine($"User ID: {reader["UserID"]}, Train ID: {reader["TrainID"]}, ClassID: {reader["ClassID"]}, PNR: {reader["PNR"]}, Booking Date: {reader["BookingDate"]}");
                            }
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occured while fetching booking data: {ex.Message}");
            }
        }

        static void DisplayTickets()
        {
            try
            {
                Console.Write("Enter PNR: ");
                string pnr = Console.ReadLine().Trim();

                using(SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("GetTicketDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@PNR", pnr);
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("\nTicket Details:");
                                while (reader.Read())
                                {
                                    Console.WriteLine($"PNR: {reader["PNR"]}");
                                    Console.WriteLine($"Booked By: {reader["BookedBy"]}");
                                    Console.WriteLine($"Train Name: {reader["TrainName"]}");
                                    Console.WriteLine($"Source: {reader["Source"]}");
                                    Console.WriteLine($"Destination: {reader["Destination"]}");
                                    Console.WriteLine($"Number of Tickets: {reader["NumberOfTickets"]}");
                                    Console.WriteLine($"Class Type: {reader["ClassType"]}");
                                    Console.WriteLine($"Booking Date: {reader["BookingDate"]}");
                                    Console.WriteLine($"Is Cancelled: {reader["IsCancelled"]}");
                                    Console.WriteLine("------------------------END----------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No Ticket found with the given PNR!");
                            }
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching ticket details: {ex.Message}");
            }
        }

        static void ViewCancelledBookings()
        {
            try
            {
                using(SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("ViewCancelledBookings", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nCancelled Bookings: ");
                            while (reader.Read())
                            {
                                Console.WriteLine($"Booking ID: {reader["BookingID"]}, TrainID: {reader["TrainID"]}, Class ID: {reader["ClassID"]}, User ID: {reader["UserID"]}, Booking Date: {reader["BookingDate"]}, Cancelled: {reader["IsCancelled"]} ");
                            }
                        }
                    }
                }
                
            }

            catch(Exception ex)
            {
                Console.WriteLine($"An error occured while fetching Cancelled Booking data: {ex.Message}");
            }
        }

        static void CheckAvailability()
        {
            try
            {
                Console.Write("Enter Train ID: ");
                int trainID = int.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("Class ID -> Type");
                Console.WriteLine("1 -> First A/C");
                Console.WriteLine("2 -> Second A/C");
                Console.WriteLine("3 -> Third A/C");
                Console.WriteLine("4 -> Sleeper");
                Console.WriteLine();

                Console.Write("Enter Class ID: ");
                int classID = int.Parse(Console.ReadLine());

                using(SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CheckAvailability", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@TrainID", trainID);
                        cmd.Parameters.AddWithValue("@ClassID", classID);



                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int availableBerths = (int)reader["AvailableBerths"];

                                Console.WriteLine($"Available Berths: {availableBerths}");

                            }

                            else
                            {
                                Console.WriteLine("No data found for the Train ID and Class ID!");
                            }
                        }
                    }

                }

               
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occured while checking availability: {ex.Message}");
            }
        }

        static void AdminViewAllBookings()
        {
            try
            {
                using (SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("AdminViewAllBookings", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nAll Bookings:");
                            while (reader.Read())
                            {
                                Console.WriteLine($"PNR: {reader["PNR"]}, Booked By: {reader["UserName"]}, Train Name: {reader["TrainName"]}, Source: {reader["Source"]}, Destination: {reader["Destination"]}");
                            }
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching all booking details: {ex.Message}");
            }
        }

        static void AdminViewAllCancelledBookings()
        {
            try
            {
                using(SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("AdminViewAllCancelledBookings", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nAll Cancelled Bookings:");
                            while (reader.Read())
                            {
                                Console.WriteLine($"PNR: {reader["PNR"]}, Booked By: {reader["UserName"]}, Train Name: {reader["TrainName"]}, No of Tickets: {reader["NumberOfTickets"]}, Booking Date: {reader["BookingDate"]}");
                            }
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching all cancelled booking data: {ex.Message}");
            }
        }

        static void AdminViewAllTicketDetails()
        {
            try
            {
                using(SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("AdminViewAllTicketDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nAll Ticket Details:");
                            while (reader.Read())
                            {
                                Console.WriteLine($"PNR: {reader["PNR"]}");
                                Console.WriteLine($"Booked By: {reader["BookedBy"]}");
                                Console.WriteLine($"Train Name: {reader["TrainName"]}");
                                Console.WriteLine($"Source: {reader["Source"]}");
                                Console.WriteLine($"Destination: {reader["Destination"]}");
                                Console.WriteLine($"Number of Tickets: {reader["NumberOfTickets"]}");
                                Console.WriteLine($"Class Type: {reader["ClassType"]}");
                                Console.WriteLine($"Booking Date: {reader["BookingDate"]}");
                                Console.WriteLine($"Is Cancelled: {reader["IsCancelled"]}");
                                Console.WriteLine("------------------------END----------------------------");
                            }
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occured while trying to fetch all Ticket Details: {ex.Message}");
            }
        }
        static void CancelBooking()
        {
            try
            {
                Console.Write("Enter PNR: ");
                string pnr = Console.ReadLine();

                Console.Write("Enter Number of Tickets to Cancel: ");
                int numberOfTickets = int.Parse(Console.ReadLine());

                using(SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CancelBooking", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@PNR", pnr);
                        cmd.Parameters.AddWithValue("@NumberOfTickets", numberOfTickets);

                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Booking Cancelled Successfully!");

                    }
                }
                
            }

            catch(SqlException ex)
            {
                if (ex.Number == 50000)
                {
                    Console.WriteLine(ex.Message);
                }
                else
                {
                    Console.WriteLine($"An error occurred while cancelling the booking!");
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine($"An error occured while cancelling the booking: {ex.Message}");
            }
        }

        static void AdminViewAllUsers()
        {
            try
            {
                using(SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("AdminViewAllUsers", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nAll Users:");
                            while (reader.Read())
                            {
                                Console.WriteLine($"UserID: {reader["UserID"]}, User Name: {reader["UserName"]}, Password: {reader["Password"]}");
                            }
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occured while trying to get User details: {ex.Message}");
            }
        }

        static void AddTrain()
        {
            try
            {
                Console.Write("Enter Train Number: ");
                string trainNumber = Console.ReadLine().Trim();
                Console.Write("Enter Train Name: ");
                string trainName = Console.ReadLine().Trim();
                Console.Write("Enter Source: ");
                string source = Console.ReadLine().Trim();
                Console.Write("Enter Destination: ");
                string destination = Console.ReadLine().Trim();
                DataTable classesBerths = new DataTable();
                classesBerths.Columns.Add("ClassID", typeof(int));
                classesBerths.Columns.Add("TotalBerths", typeof(int));
                classesBerths.Columns.Add("AvailableBerths", typeof(int));
                // Prompt user for each class's details
                for (int i = 1; i <= 4; i++)
                {
                    Console.Write($"Enter Total Berths for Class {i}: ");
                    int totalBerths = int.Parse(Console.ReadLine().Trim());
                    Console.Write($"Enter Available Berths for Class {i}: ");
                    int availableBerths = int.Parse(Console.ReadLine().Trim());
                    classesBerths.Rows.Add(i, totalBerths, availableBerths);
                }
                using (SqlConnection con = getConnection())
                {
                    // Temporary table creation and data insertion
                    string tempTableCommands = @"
           CREATE TABLE #ClassesBerths (
               ClassID INT,
               TotalBerths INT,
               AvailableBerths INT
           );";
                    using (SqlCommand cmd = new SqlCommand(tempTableCommands, con))
                    {
                        cmd.ExecuteNonQuery();
                        foreach (DataRow row in classesBerths.Rows)
                        {
                            string insertCommand = "INSERT INTO #ClassesBerths (ClassID, TotalBerths, AvailableBerths) VALUES (@ClassID, @TotalBerths, @AvailableBerths);";
                            SqlCommand insertCmd = new SqlCommand(insertCommand, con);
                            insertCmd.Parameters.AddWithValue("@ClassID", row["ClassID"]);
                            insertCmd.Parameters.AddWithValue("@TotalBerths", row["TotalBerths"]);
                            insertCmd.Parameters.AddWithValue("@AvailableBerths", row["AvailableBerths"]);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("AddTrain", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TrainNumber", trainNumber);
                        cmd.Parameters.AddWithValue("@TrainName", trainName);
                        cmd.Parameters.AddWithValue("@Source", source);
                        cmd.Parameters.AddWithValue("@Destination", destination);
                        // Debugging output to verify parameters
                        Console.WriteLine("Parameters being sent to the stored procedure:");
                        foreach (SqlParameter param in cmd.Parameters)
                        {
                            Console.WriteLine($"{param.ParameterName}: {param.Value}");
                        }
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Train and classes added successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the train: {ex.Message}");
            }
        }


        static void UpdateTrain()
        {
            try
            {
                Console.Write("Enter Train ID: ");
                int trainID = int.Parse(Console.ReadLine());

                Console.Write("Enter Train Number: ");
                int trainNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter Train Name: ");
                string trainName = Console.ReadLine();

                Console.Write("Enter Source: ");
                string source = Console.ReadLine();

                Console.Write("Enter Destination: ");
                string destination = Console.ReadLine();

                using(SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateTrain", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@TrainID", trainID);
                        cmd.Parameters.AddWithValue("@TrainNumber", trainNumber);
                        cmd.Parameters.AddWithValue("@TrainName", trainName);
                        cmd.Parameters.AddWithValue("@Source", source);
                        cmd.Parameters.AddWithValue("@Destination", destination);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            Console.WriteLine("Train Updated Successfully!");
                        }

                        else
                        {
                            Console.WriteLine("Failed to update Train!");
                        }
                    }
                }

                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occured while updating the train: {ex.Message}");
            }
        }


        static void SoftDeleteTrain()
        {
            try
            {
                Console.Write("Enter Train ID: ");
                int trainID = int.Parse(Console.ReadLine());

                using(SqlConnection con = getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("SoftDeleteTrain", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@TrainID", trainID);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            Console.WriteLine("Train marked as inactive!");
                        }

                        else
                        {
                            Console.WriteLine("Failed to mark train as inactive!");
                        }
                    }
                }

                
            }

            catch(Exception ex)
            {
                Console.WriteLine($"An error occured while marking the train as inactive: {ex.Message}");
            }
        }
        
    }
}

