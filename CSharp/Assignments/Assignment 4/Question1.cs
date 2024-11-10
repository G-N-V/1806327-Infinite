using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException() { }
        public InsufficientBalanceException(string message):base(message) { }
        public InsufficientBalanceException(string message, Exception inner): base(message, inner) { }

    }

    public class Accounts
    {
        private int accountNo;
        private string customerName;
        private string accountType;
        private double balance;


        public Accounts(int accNo, string custName, string accType, double initialBalance)
        {
            accountNo = accNo;
            customerName = custName;
            accountType = accType;
            balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive!");

            balance = balance + amount;
            Console.WriteLine("Deposited: " + amount);
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive!");
            }
            if (amount > balance)
                throw new InsufficientBalanceException("Insufficient Balance for withdrawal!");

            balance = balance - amount;
        }

        public double GetBalance()
        {
            return balance;
        }

        public void ShowData()
        {
            Console.WriteLine("Account No: " + accountNo);
            Console.WriteLine("Customer Name: " + customerName);
            Console.WriteLine("Account Type: " + accountType);
            Console.WriteLine("Current Balance: " + balance);
        }
    }
    class Question1
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Account No: ");
                int accNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Customer Name: ");
                string custName = Console.ReadLine();

                Console.WriteLine("Enter Account Type: ");
                string accType = Console.ReadLine();

                Console.WriteLine("Enter Initial Balance: ");
                double initialBalance = Convert.ToDouble(Console.ReadLine());

                Accounts accounts = new Accounts(accNo, custName, accType, initialBalance);

                char transactionType;

                do
                {
                    Console.WriteLine("Enter Transaction Type(D for deposit and W for withdraw and E for Exit): ");
                    transactionType = Convert.ToChar(Console.ReadLine().ToUpper());

                    if (transactionType == 'D' || transactionType == 'W')
                    {
                        Console.WriteLine("Enter Amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        try
                        {
                            if (transactionType == 'D')
                                accounts.Deposit(amount);

                            else if (transactionType == 'W')
                                accounts.Withdraw(amount);

                            Console.WriteLine("Current Balance: "+accounts.GetBalance());
                        }

                        catch(InsufficientBalanceException ex)
                        {
                            Console.WriteLine("Error!"+ex.Message);
                        }

                        catch(ArgumentException ex)
                        {
                            Console.WriteLine("Error: "+ex.Message);
                        }
                    }
                    else if(transactionType!='E')
                        Console.WriteLine("Invalid Transaction Type!");
                } while (transactionType != 'E');

                accounts.ShowData();
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Error: Invalid input format!");
            }

            catch(Exception ex)
            {
                Console.WriteLine("An unexpected error occured!"+ex.Message);
            }

            finally
            {
                Console.WriteLine("Press any key to exit");
            }
            Console.ReadLine();
        }
    }
}
