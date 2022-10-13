using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Task
{
    public class Options
    {
      
        static string date;
        static string description;
        static double amount;
        static double balance = 0;
  public static void addingList()
        {

            NewCustomerList newCustomerList = new NewCustomerList(date, description, amount, balance);
            Menu.secondList.Add(newCustomerList);


        }

        public static void menuOptions()
        {
            Console.WriteLine("Welcome! Please choose one of the following options");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Show balance");
            Console.WriteLine("5. Show statement of account");
            Console.WriteLine("6. Log out");
        }
        public static void depositing(Customer currentUser)
        {
            Console.WriteLine("How much do you want to deposit? ");
            amount = Double.Parse(Console.ReadLine());
            currentUser.balance += amount;
            Console.WriteLine($"Thank you for your money. Your new balance is {currentUser.balance}");
            description = "Deposit";
            balance = balance + amount;
            date = DateTime.Now.ToString("dd/MM/yyyy");

            addingList();
            //Menu.secondList.Add(newCustomerList);

        }
        public static void withdrawal(Customer customer)
        {
            Console.WriteLine("How much do you want to withdraw? ");
            amount = Double.Parse(Console.ReadLine());
            if (amount > customer.balance)
            {
                Console.WriteLine("Insufficient funds");
                menuOptions();
            } else if (customer.accountType == "Savings" && customer.balance <= 1000)
                {
                    Console.WriteLine("Your account is too low for this transaction");
                withdrawal(customer);
                }
            else
            {
                customer.balance = customer.balance - amount;
                Console.WriteLine($"Your new balance is {customer.balance}");
                description = "Withdrawal";
                balance = balance - amount;
                date = DateTime.Now.ToString("dd/MM/yyyy");

                addingList();

            }

        }
        public static void transferring(Customer customer)
        {
            Customer customer1;
            Console.WriteLine("Enter the account number you would like to transfer to:");
            try {
                string number = Console.ReadLine();
                customer1 = Menu.customers.FirstOrDefault(a => a.cardNumber == number);

                if (customer1 != null)
                {
                    Console.WriteLine($"Let's proceed {customer.firstName}");


                    Console.WriteLine("Enter the amount you want to transfer:");
                     amount = Double.Parse(Console.ReadLine());

                    if (customer.balance > amount)
                    {
                        customer.balance -= amount;
                        customer1.balance += amount;

                        Console.WriteLine("Done");
                        description = "Transfer";
                        balance = balance - amount;
                        date = DateTime.Now.ToString("dd/MM/yyyy");

                        addingList();

                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds");
                    }
                }
                else
                {
                    Console.WriteLine("Account number not detected");
                    menuOptions();
                }
            }
            catch { Console.WriteLine("Not found"); }
        }
        public static void checkBalance(Customer currentUser)
        {
            Console.WriteLine($"Your current balance is {currentUser.balance}");
        }

       
    }
}
