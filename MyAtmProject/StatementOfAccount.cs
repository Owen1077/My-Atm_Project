using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Task
{
    public class StatementOfAccount
    {
       //static string num;
        public static void AccountDetails()
        {
            string num;

            point:
            Console.WriteLine("Please enter your account number:");
             num = Console.ReadLine();

            foreach(var t in Menu.customers)
            {
                if (!num.Equals(t.cardNumber))
                {
                    Console.WriteLine("Invalid account number");
                    goto point;
                } break;
            }

            Console.WriteLine("ACCOUNT DETAILS\n");

        Console.WriteLine("\n|----------|--------------|-------------|----------------|\n" +
                            "|FULL NAME |ACCOUNT NUMBER|ACCOUNT TYPE |ACCOUNT BALANCE |\n" +
                            "|----------|--------------|-------------|----------------|");
            foreach (var z in Menu.customers)
            {
                if (num.Equals(z.cardNumber))
                {
                    Console.WriteLine($"|{(z.firstName).ToUpper() + " " + (z.lastName).ToUpper()} |{z.cardNumber} |{z.accountType} |{z.balance}      |");

                }
            }
          Console.WriteLine("|----------|--------------|-------------|----------------|");



            Console.WriteLine($"ACCOUNT STATEMENT ON ACCOUNT NO {num}\n");

            Console.WriteLine("\n|---------|-----------|---------|----------|\n" +
                                "|DATE     |DESCRIPTION|AMOUNT   |BALANCE   |\n" +
                                "|---------|-----------|---------|----------|");
            foreach (var n in Menu.secondList)
            {
                //if (num.Equals(z.cardNumber))
                //{
                Console.WriteLine($"|{n.date} |{n.description}   |{n.amount}    |{n.balance}    |");
                //}
            }
            Console.WriteLine("|---------|-----------|---------|----------|");



        }
        public static void AccountStatement()
        {
           

        }
    }
}
