using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class Accounts
    {
        private int accountNo;
        private string customerName;
        private string accountType;
        private int balance;

        public Accounts(int accNo, string custName, string accType)
        {
            accountNo = accNo;
            customerName = custName;
            accountType = accType;
            balance = 0;
        }

        public void UpdateBalance(char transType, int amt)
        {
            if (transType == 'D' || transType == 'd')
                Credit(amt);

            else if (transType == 'W' || transType == 'w')
                Debit(amt);

            else
                Console.WriteLine("Invalid Transaction type!");
        }

        private void Credit(int amt)
        {
            balance = balance + amt;
            Console.WriteLine("Amount Deposited: " + amt);
        }

        private void Debit(int amt)
        {
            if (amt > balance)
                Console.WriteLine("Insufficient Balance!");

            else
            {
                balance = balance - amt;
                Console.WriteLine("Amount withdrawn: " + amt);
            }
        }

        public void ShowData()
        {
            Console.WriteLine("Account No: " + accountNo);
            Console.WriteLine("Customer Name: " + customerName);
            Console.WriteLine("Account Type: " + accountType);
            Console.WriteLine("Current Balance: " + balance);
        }
    }
    class AccountsQ1
    {
        static void Main()
        {
            Console.WriteLine("Enter Account No.: ");
            int accNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Customer Name: ");
            string custName = Console.ReadLine();

            Console.WriteLine("Enter Account Type: ");
            string accType = Console.ReadLine();

            Accounts account = new Accounts(accNo, custName, accType);

            char transType;
            do
            {
                Console.WriteLine("Enter Transaction Type (D/W) or E to exit: ");
                transType = Convert.ToChar(Console.ReadLine().ToUpper());

                if(transType=='D' || transType == 'E')
                {
                    Console.Write("Enter Amount: ");
                    int amt = Convert.ToInt32(Console.ReadLine());
                    account.UpdateBalance(transType, amt);
                }

                else if(transType!='E')
                    Console.WriteLine("Invalid Transaction type!");

            } while (transType != 'E');

            account.ShowData();

            Console.ReadLine();

        }
    }

}
