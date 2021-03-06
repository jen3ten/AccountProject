﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8_BankAccountProject_02252016
{
    class Clients
    {
        //Fields
        private string name = "Jane Doe";
        private string accountNum = "";
        
        //Properties
        public string ClientName { get; set; }
        public string AccountNumber { get; set; }

        //Constructor
        public Clients ()
        {
            this.ClientName = name;
            this.AccountNumber = accountNum;
        }

        //Method
        //Get random account number
        public string GetAcctNumber ()
        {
            Random random1 = new Random();
            StringBuilder acctNumSB = new StringBuilder();
            acctNumSB = acctNumSB.Clear();

            acctNumSB = acctNumSB.Append(Convert.ToString(random1.Next(100,1000)));
            acctNumSB = acctNumSB.Append("-");
            acctNumSB = acctNumSB.Append(Convert.ToString(random1.Next(10000,100000)));
            return acctNumSB.ToString();
        }
    }
}
