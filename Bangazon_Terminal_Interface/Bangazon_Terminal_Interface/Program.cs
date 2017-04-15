using System;
using Bangazon_Terminal_Interface.Bangazon;
using Bangazon_Terminal_Interface.DAL;
using System.Collections.Generic;

namespace Bangazon_Terminal_Interface
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var isRunning = true;
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

            var activeCustomer = new Customer();
            var customerAccountId = activeCustomer.CustomerId;
            var paymentAccountId = customerAccountId;

            List<string> activeProductSelections = new List<string>();

            while (isRunning)
            {
                var userSelection = Console.ReadLine();
                if (userSelection == "1")
                {
                    //Create New Customer Account
                    Console.WriteLine("Great! Let's get you signed up!");

                    var customerRepo = new CustomerRepository();

                    Console.WriteLine("Let's start with your name. Enter your first name below and press Enter:");
                    var userFirstName = Console.ReadLine();

                    Console.WriteLine("Hi there, " + userFirstName +
                                      "! Good to meet you. Now, enter your last name below and press Enter:");
                    var userLastName = Console.ReadLine();

                    Console.WriteLine(
                        "Great name. Let's get your address next. Type your street address first and press Enter:");
                    var userStreet = Console.ReadLine();

                    Console.WriteLine("Type the city you're located in and press Enter:");
                    var userCity = Console.ReadLine();

                    Console.WriteLine("Now enter the two-letter abbreviation of your state and press Enter:");
                    var userState = Console.ReadLine();

                    Console.WriteLine("And finally, enter your 5-digit zipcode and press Enter:");

                    int userZipCode = int.Parse(Console.ReadLine());


                    Console.WriteLine(
                        "Awesome. Last item: just give use your 10-digit phone number (no hyphens, spaces, or parenthesis) and press Enter:");
                    var userPhone = int.Parse(Console.ReadLine());

                    activeCustomer = customerRepo.AddNewCustomerAccount(userFirstName, userLastName, userStreet,
                        userCity, userState,
                        userZipCode, userPhone);
                    Console.WriteLine(activeCustomer.CustomerId);
                    
                    //customList = activeCustomer.;
                }

                if (userSelection == "2")
                {
                    var customerRepository = new CustomerRepository();
                    Console.WriteLine("Which customer will be active?");
                    customerRepository.PickFromListOfExisitingCustomers();
                    customerAccountId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Your selected customer is " + customerAccountId);
                }

                if (userSelection == "3")
                {
                    Console.WriteLine("Enter Payment Type (Amex, Visa, Checking)");
                    var userPaymentType = Console.ReadLine();
                    Console.WriteLine("Please enter 5 Digit Account Number");
                    var userAccountNumber = int.Parse(Console.ReadLine());
                    var paymentRepository = new PaymentRepository();
                    paymentRepository.AddPaymentType(userPaymentType, userAccountNumber, customerAccountId);
                }

                if (userSelection == "4")
                {
                    Console.WriteLine("********  PRODUCTS AVAILABLE **********");
                    Console.WriteLine("1. Apples       $1.50");
                    Console.WriteLine("2. Nelly CD       $2.00");
                    Console.WriteLine("3. Toaster       $25.00");
                    Console.WriteLine("4. Fish Tank       $75.00");
                    Console.WriteLine("5. Salmon Flakes Cereal       $10.00");
                    Console.WriteLine("  ");
                    var selection = true;
            
                    while (selection)
                    {
                        Console.WriteLine("Select Product By Number or hit 'X' to Exit");
                        string productSelection = Console.ReadLine();

                        if(productSelection == "x")
                        {
                            selection = false;
                            break;
                        }
                        else
                        {
                            activeProductSelections.Add(productSelection);
            
                        }



                    }
                }

                if (userSelection == "5")
                {
                    Console.WriteLine("Choose Payment Type");
                    var chooseType = Console.ReadLine();
                    var paymentRepository = new PaymentRepository();
                    paymentRepository.GetPaymentList(customerAccountId);
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