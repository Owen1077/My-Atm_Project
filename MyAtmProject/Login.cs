using System;
using ATM_Task;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Task
{
    public class Login
    {
        public static void login()
        {
            Customer customer;

            if (Menu.customers.Count() > 0)
            {
                Console.WriteLine("Please enter your card number: ");

                string newcardNumber = "";

                while (true)
                {
                    try
                    {
                        newcardNumber = Console.ReadLine();
                        customer = Menu.customers.FirstOrDefault(a => a.cardNumber == newcardNumber);

                        if (customer != null)
                        {
                            Console.WriteLine($"Welcome {customer.firstName}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Not recognized");
                        }
                    }
                    catch { Console.WriteLine("Not recognized"); }
                }
                Console.WriteLine("Please enter your pin");
                string newpin;

                while (true)
                {
                    try
                    {
                        newpin = Console.ReadLine();
                        if (customer.pin == newpin) { break; }
                        else { Console.WriteLine("Incorrect pin... Try again"); }
                    }
                    catch { Console.WriteLine("Incorrect pin... Try again"); }
                }
                Console.WriteLine($"Welcome {(customer.firstName).ToUpper()}");

                int options = 0;
                do
                {
                    Options.menuOptions();

                    options = int.Parse(Console.ReadLine());
                    if (options == 1)
                    {
                        Options.depositing(customer);
                    }
                    else if (options == 2)
                    {
                        Options.withdrawal(customer);
                    }
                    else if (options == 3)
                    {
                        Options.transferring(customer);
                    }else if(options == 4)
                    {
                        Options.checkBalance(customer);
                    }else if (options == 5)
                    {
                        StatementOfAccount.AccountDetails();
                        StatementOfAccount.AccountStatement();
                    }
                    else if (options == 6) { Menu.MainMenu(); }
                    else { Console.WriteLine("Please select a valid option"); 
                    }
                } while (options != 6);
            }
            else
            {
                Console.WriteLine("You need to have an account with us to log in");
                Menu.MainMenu();
            }
        }
       
    }
    }

