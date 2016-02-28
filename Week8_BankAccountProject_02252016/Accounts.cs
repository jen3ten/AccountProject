using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Week8_BankAccountProject_02252016
{
    class Accounts
    {
        //Fields
        private string transInput = "";
        private string sign = " ";
        StringBuilder transLine = new StringBuilder();
        List<string> transList = new List<string>();
        private bool validInput = false;
        private bool firstLine = true;

        //Properties
        public double Balance { get; set; }
        public string AccountNumber { get; set; }
        public string ClientName { get; set; }

        //Constructor
        public Accounts(string name, string account)
        {
            this.Balance = 100.00;
            this.AccountNumber = account;
            this.ClientName = name;
            transList.Clear();
            AddTransToList();
            firstLine = false;
        }

        //Methods
        //Deposit funds method
        public void DepositFunds()
        {
            sign = "+";
            validInput = false;
            transLine.Clear();
            Console.Clear();
            Console.WriteLine("*******************************");
            Console.WriteLine("FIRST THIRD BANKING APPLICATION");
            Console.WriteLine("*******************************");
            Console.WriteLine();
            Console.WriteLine("Deposit Funds");
            Console.WriteLine();
            do
            {
                Console.Write("Enter the amount to deposit: + $");
                transInput = Console.ReadLine();
                if (!Regex.IsMatch(transInput, @"^[0-9]*\.[0-9]{2}$"))
                {
                    Console.WriteLine("INVALID ENTRY: Please enter a number in decimal format <0.00>");
                    validInput = false;
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);
            this.Balance = this.Balance + (double.Parse(transInput));
            AddTransToList();
            Console.Clear();
        }

        //Withdraw funds method
        public void WithdrawFunds()
        {
            sign = "-";
            validInput = false;
            transLine.Clear();
            Console.Clear();
            Console.WriteLine("*******************************");
            Console.WriteLine("FIRST THIRD BANKING APPLICATION");
            Console.WriteLine("*******************************");
            Console.WriteLine();
            Console.WriteLine("Withdraw Funds");
            Console.WriteLine();
            do
            {
                Console.Write("Enter the amount to withdraw: - $");
                transInput = Console.ReadLine();
                if (!Regex.IsMatch(transInput,@"^[0-9]*\.[0-9]{2}$"))
                {
                    Console.WriteLine("INVALID ENTRY: Please enter a number in decimal format <0.00>");
                    validInput = false;
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);
            this.Balance = this.Balance - (double.Parse(transInput));
            AddTransToList();
            Console.Clear();
        }

        //Add to transaction list method
        public void AddTransToList()
        {
            transLine = transLine.Append(DateTime.Now);
            transLine = transLine.Append("\t\t");
            transLine = transLine.Append(sign);
            if (!firstLine)
            {
                transLine = transLine.Append("   $");
                transLine = transLine.Append(transInput);
            }
            else
                transLine = transLine.Append("\t");
            transLine = transLine.Append("\t$");
            transLine = transLine.Append(this.Balance.ToString("F2"));
            transList.Add(transLine.ToString());
        }

        //Update text file method
        public void UpdateAcctFile()
        {
            StreamWriter accountFile = new StreamWriter("AccountSummary.txt");
            accountFile.WriteLine("***************************");
            accountFile.WriteLine("FIRST THIRD ACCOUNT SUMMARY");
            accountFile.WriteLine("***************************");
            accountFile.WriteLine();
            accountFile.WriteLine("Account Holder: \t{0}", ClientName);
            accountFile.WriteLine("Account Number: \t{0}", AccountNumber);
            accountFile.WriteLine("Account Balance: \t${0:f2}", Balance);
            accountFile.WriteLine();
            accountFile.WriteLine("TRANSACTION HISTORY");
            accountFile.WriteLine("Date\t\t\t\tTransaction\tBalance");
            foreach(string line in transList)
            {
                accountFile.WriteLine(line);
            }
            accountFile.Close();
        }
    }
}
