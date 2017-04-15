﻿using Bangazon_Terminal_Interface.Bangazon;
using Bangazon_Terminal_Interface.Bangazon.DAL;
using Bangazon_Terminal_Interface.DAL;
using System;
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
            Console.WriteLine("3. View Products");
            Console.WriteLine("4. Create a payment option");
            Console.WriteLine("5. Add product to shopping cart");
            Console.WriteLine("6. Complete an order");
            Console.WriteLine("7. See product popularity");
            Console.WriteLine("8. Leave Bangazon!");

            Customer activeCustomer = new Customer();
            int customerAccoutId = activeCustomer.CustomerId;

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
                    var userZipCode = int.Parse(Console.ReadLine());

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
                    CustomerRepository customerRepository = new CustomerRepository();
                    Console.WriteLine("Which customer will be active?");
                    customerRepository.PickFromListOfExisitingCustomers();
                    customerAccoutId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Your selected customer is " + customerAccoutId);


                }

                if (userSelection == "3")
                {
                    //list out all the products
                    // ProductRepository products = new ProductRepository();
                    List<ProductRepository> products2 = new List<ProductRepository>();
                    Console.WriteLine("Here is a list of the products.");

                    //products2.GetProduct(productId, string productName, double productPrice);

                    //give option to pick a product by id
                }
                if (userSelection == "4")
                {
                    Console.WriteLine("Enter Payment Type (Amex, Visa, Checking)");
                    var userPaymentType = Console.ReadLine();
                    Console.WriteLine("Please enter 5 Digit Account Number");
                    var userAccountNumber = int.Parse(Console.ReadLine());
                    PaymentRepository paymentRepository = new PaymentRepository();
                    paymentRepository.AddPaymentType(userPaymentType, userAccountNumber,customerAccoutId);
                }


                if (userSelection == "4")
                {
                    var paymentRepository = new PaymentRepository();
                    paymentRepository.GetPaymentList(activeCustomer.CustomerId);
                }

                if (userSelection == "5")
                {
                    Console.WriteLine("Choose Payment Type");
                    var chooseType = Console.ReadLine();
                    var paymentRepository = new PaymentRepository();
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