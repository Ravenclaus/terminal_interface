using Bangazon_Terminal_Interface.Bangazon;
using Bangazon_Terminal_Interface.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface
{
    public class Program
    {

        static void Main(string[] args)
        {
            bool isRunning = true;
            Console.WriteLine("*********************************************************");
            Console.WriteLine("**  Welcome to Bangazon! Command Line Ordering System  **");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2. Choose active customer");
            Console.WriteLine("3. Create a payment option");
            Console.WriteLine("4. Add product to shopping cart");
            Console.WriteLine("5. Complete an order");
            Console.WriteLine("6. See product popularity");
            Console.WriteLine("7. Leave Bangazon!");

            Customer activeCustomer = new Customer();

            while (isRunning)
            {
                string userSelection = Console.ReadLine();
                if (userSelection == "1")
                {
                    //Create New Customer Account
                    Console.WriteLine("Great! Let's get you signed up!");

                    CustomerRepository customerRepo = new CustomerRepository();

                    Console.WriteLine("Let's start with your name. Enter your first name below and press Enter:");
                    string userFirstName = Console.ReadLine();

                    Console.WriteLine("Hi there, " + userFirstName +
                                      "! Good to meet you. Now, enter your last name below and press Enter:");
                    string userLastName = Console.ReadLine();

                    Console.WriteLine(
                        "Great name. Let's get your address next. Type your street address first and press Enter:");
                    string userStreet = Console.ReadLine();

                    Console.WriteLine("Type the city you're located in and press Enter:");
                    string userCity = Console.ReadLine();

                    Console.WriteLine("Now enter the two-letter abbreviation of your state and press Enter:");
                    string userState = Console.ReadLine();

                    Console.WriteLine("And finally, enter your 5-digit zipcode and press Enter:");
                    int userZipCode = int.Parse(Console.ReadLine());

                    Console.WriteLine(
                        "Awesome. Last item: just give use your 10-digit phone number (no hyphens, spaces, or parenthesis) and press Enter:");
                    int userPhone = int.Parse(Console.ReadLine());

                     activeCustomer =  customerRepo.AddNewCustomerAccount(userFirstName, userLastName, userStreet, userCity, userState,
                        userZipCode, userPhone);
                    Console.WriteLine(activeCustomer.CustomerId);

                    
                   

                }
                if (userSelection == "2")
                {

                }
                if (userSelection == "3")
                {
                    Console.WriteLine("Enter Payment Type (Amex, Visa, Checking)");
                    string userPaymentType = Console.ReadLine();
                    Console.WriteLine("Please enter 5 Digit Account Number");
                    int userAccountNumber = int.Parse(Console.ReadLine());
                    PaymentRepository paymentRepository = new PaymentRepository();
                    paymentRepository.AddPaymentType(userPaymentType, userAccountNumber, activeCustomer.CustomerId );
                }
                if (userSelection == "4")
                {
                    PaymentRepository paymentRepository = new PaymentRepository();
                    paymentRepository.GetPaymentList(activeCustomer.CustomerId);
                }
                if (userSelection == "5")
                {
                    Console.WriteLine("Choose Payment Type");
                    string chooseType = Console.ReadLine();
                    PaymentRepository paymentRepository = new PaymentRepository();
                    paymentRepository.GetPaymentList(activeCustomer.CustomerId);

                }
                if (userSelection == "6")
                {

                }
                else if (userSelection == "7")
                {
                    Console.WriteLine("Thanks for visiting FakeAmazon! Have a nice day!");
                    isRunning = false;
                    break;
                }
                else
                {
                    Console.WriteLine("I'm sorry, that option is not valid. Please choose and option 1 through 7.");

                }

              
               
                
            }
        }
    }
}