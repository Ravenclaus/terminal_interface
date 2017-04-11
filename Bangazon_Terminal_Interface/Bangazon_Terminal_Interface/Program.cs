using Bangazon_Terminal_Interface.Bangazon;
using Bangazon_Terminal_Interface.DAL;
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
            CustomerRepository customerRepo = new CustomerRepository();
            Console.WriteLine("Let's start with your name. Enter your first name below and press Enter:");
            string userFirstName = Console.ReadLine();

            Console.WriteLine("Hi there, " + userFirstName + "! Good to meet you. Now, enter your last name below and press Enter:");
            string userLastName = Console.ReadLine();

            Console.WriteLine("Great name. Let's get your address next. Type your street address first and press Enter:");
            string userStreet = Console.ReadLine();

            Console.WriteLine("Type the city you're located in and press Enter:");
            string userCity = Console.ReadLine();

            Console.WriteLine("Now enter the two-letter abbreviation of your state and press Enter:");
            string userState = Console.ReadLine();

            Console.WriteLine("And finally, enter your 5-digit zipcode and press Enter:");
            int userZipCode = int.Parse(Console.ReadLine());

            Console.WriteLine("Awesome. Last item: just give use your 10-digit phone number (no hyphens, spaces, or parenthesis) and press Enter:");
            int userPhone = int.Parse(Console.ReadLine());


            customerRepo.AddNewCustomerNameStreetCityState(userFirstName, userLastName, userStreet, userCity, userState, userZipCode, userPhone);
        }
    }
}
