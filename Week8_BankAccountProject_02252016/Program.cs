using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8_BankAccountProject_02252016
{
    class Program
    {
        static void Main(string[] args)
        {
            Clients client = new Clients();
            client.AccountNumber = client.GetAcctNumber();
            Accounts account = new Accounts(client.ClientName, client.AccountNumber);
            bool exit = false;

            do
            {
                int menuOption = Menu();
                switch(menuOption)
                {
                    case 1:
                        {
                            ViewAcctInfo(client.ClientName, client.AccountNumber, account.Balance);
                            break;
                        }
                    case 2:
                        {
                            ViewAcctBalance(account.Balance);
                            break;
                        }
                    case 3:
                        {
                            account.DepositFunds();
                            account.UpdateAcctFile();
                            break;
                        }
                    case 4:
                        {
                            account.WithdrawFunds();
                            account.UpdateAcctFile();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Thanks for banking with us.");
                            Console.WriteLine("Good bye!");
                            Console.WriteLine();
                            Console.ReadKey();
                            exit = true;
                            break;
                        }
                    default: break;
                }
            } while (!exit);
        }

        static int Menu()
        {
            bool validChoice = true;
            int choice = 0;
            do
            {
                ResetScreen();
                Console.WriteLine("Banking Menu");
                Console.WriteLine();
                Console.WriteLine("\t1. View Client Information");
                Console.WriteLine("\t2. View Account Balance");
                Console.WriteLine("\t3. Deposit Funds");
                Console.WriteLine("\t4. Withdrawal Funds");
                Console.WriteLine("\t5. Exit");
                Console.WriteLine();
                Console.Write("What would you like to do? (enter number of choice) ");
                validChoice = int.TryParse(Console.ReadLine(), out choice);
                if (choice < 1 || choice > 5)
                    validChoice = false;
                Console.Clear();
                if (!validChoice)
                {
                    Console.WriteLine("INVALID ENTRY:  Please enter a number between 1-5.");
                    Console.WriteLine();
                }
            } while (!validChoice);
            return choice;
        }

        static void ViewAcctInfo(string name, string number, double balance)
        {
            ResetScreen();
            Console.WriteLine("Account Information");
            Console.WriteLine();
            Console.WriteLine("Account Holder: \t{0}", name);
            Console.WriteLine("Account Number: \t{0}", number);
            Console.WriteLine("Account Balance: \t${0:f2}", balance);
            Console.WriteLine();
            Console.Write("Press a key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }

        static void ViewAcctBalance(double balance)
        {
            ResetScreen();
            Console.WriteLine("Balance Information");
            Console.WriteLine();
            Console.WriteLine("Account Balance: \t${0:f2}", balance);
            Console.WriteLine();
            Console.Write("Press a key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }

        static void ResetScreen()
        {
            Console.Clear();
            Console.WriteLine("*******************************");
            Console.WriteLine("FIRST THIRD BANKING APPLICATION");
            Console.WriteLine("*******************************");
            Console.WriteLine();
        }
    }
}
