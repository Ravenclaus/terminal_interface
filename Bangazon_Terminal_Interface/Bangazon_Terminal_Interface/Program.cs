using Bangazon_Terminal_Interface.Bangazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            Console.WriteLine("*********************************************************");
            Console.WriteLine("**  Welcome to Bangazon! Command Line Ordering System  **");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2. Create a payment option");
            Console.WriteLine("3. Order a product");
            Console.WriteLine("4. Complete an order");
            Console.WriteLine("5. See product popularity");
            Console.WriteLine("6. Leave Bangazon!");

            Customer customer = new Customer();

            while (isRunning)
            {
                string userSelection = Console.ReadLine();

                if (userSelection == "1")
                {
                    Console.WriteLine("Great! Let's get you signed up!");
                    customer.CreateNewCustomer();
                }
                else if (userSelection == "6")
                {
                    Console.WriteLine("Thanks for visiting FakeAmazon! Have a nice day!");
                    isRunning = false;
                    break;
                }
                else
                {
                    Console.WriteLine("I'm sorry, that option is not valid. Please choose and option 1 through 6.");
                }
            }
        }
    }
}
