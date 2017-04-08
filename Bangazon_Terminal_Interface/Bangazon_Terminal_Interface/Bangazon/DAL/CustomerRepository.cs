using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.Bangazon.DAL
{
    class CustomerRepository
    {
        //Option 1. Create a customer account
        public void CreateNewCustomer()
        {
            Customer customer = new Customer();

            Console.WriteLine("Let's start with your name. Enter your first name below and press Enter:");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("Hi there, " + customer.FirstName + "! Good to meet you. Now, enter your last name below and press Enter:");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("Great name. Let's get your address next. Type your street address first and press Enter:");
            customer.Street = Console.ReadLine();

            Console.WriteLine("Type the city you're located in and press Enter:");
            customer.City = Console.ReadLine();

            Console.WriteLine("Now enter your 5-digit zipcode and press Enter:");
            customer.Zipcode = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Awesome. Last item: just give use your 10-digit phone number (no hyphens, spaces, or parenthesis) and press Enter:");
            customer.Phone = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Thank you - your Customer Profile has been set up!");

            //Need to figure this out:
            //look at FakeTrello
            string command = @"
                    ADD TO  
                        (FirstName, LastName, Street, City, Zipcode, Phone)
                    VALUES
                        ('" + customer.FirstName + "', '" + customer.LastName + "', '" + customer.Street + "', '" + customer.City + "', '" + customer.Zipcode + "', '" + customer.Phone + "')";

            System.Data.SqlClient.SqlConnection sqlConnection1 =
            new System.Data.SqlClient.SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"c:\\users\\kaylee cummings\\documents\\visual studio 2015\\Projects\\Bangazon\\Bangazon\\Invoices.mdf\";Integrated Security=True");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = command;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();

            Console.Clear();
        }

        //Option 2. Choose active customer
        public string GetExistingCustomers()
        {
            return "List of Existing Customers";
        }

        /* Customer will select customers from list */
        public string AcknowledgeUserSelection()
        {
            return "Welcome back, XXXXXX";
        }
    }
}
