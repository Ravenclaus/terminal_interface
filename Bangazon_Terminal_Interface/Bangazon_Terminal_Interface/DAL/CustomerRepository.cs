using Bangazon_Terminal_Interface.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;

namespace Bangazon_Terminal_Interface.DAL
{
    public class CustomerRepository : ICustomer
    {
        IDbConnection _customerConnection;

        public CustomerRepository()
        {
            _customerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RavenClausBangazon"].ConnectionString);
        }

        public void AddNewCustomerAccount(string userFirstName, string userLastName, string userStreet, string userCity, string userState, int userZipCode, int userPhone)
        {
            /*
            Console.WriteLine("Let's start with your name. Enter your first name below and press Enter:");
            userFirstName = Console.ReadLine();

            Console.WriteLine("Hi there, " + userFirstName + "! Good to meet you. Now, enter your last name below and press Enter:");
            userLastName = Console.ReadLine();

            Console.WriteLine("Great name. Let's get your address next. Type your street address first and press Enter:");
            userStreet = Console.ReadLine();

            Console.WriteLine("Type the city you're located in and press Enter:");
            userCity = Console.ReadLine();

            Console.WriteLine("Now enter the two-letter abbreviation of your state and press Enter:");
            userState = Console.ReadLine();

            Console.WriteLine("And finally, enter your 5-digit zipcode and press Enter:");
                userZipCode = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Awesome. Last item: just give use your 10-digit phone number (no hyphens, spaces, or parenthesis) and press Enter:");
                userPhone = Convert.ToInt32(Console.ReadLine());

                //Future Possibility: Add in confirmation of account information
                Console.WriteLine("Thank you - your Customer Profile is now being created...");
            */

            //Database Interaction:
            _customerConnection.Open();

            try
            {
                var addNewCustomerCommand = _customerConnection.CreateCommand();
                addNewCustomerCommand.CommandText = @"
                    INSERT INTO RavenClausBangazon.dbo.Customer(FirstName, LastName, Street, City, State, ZipCode, Phone) 
                    VALUES(@userFirstName, @userLastName, @userStreet, @userCity, @userState, @userZipCode, @userPhone)
                    ";

                var firstNameParameter = new SqlParameter("userFirstName", SqlDbType.VarChar);
                firstNameParameter.Value = userFirstName;
                addNewCustomerCommand.Parameters.Add(firstNameParameter);

                var lastNameParameter = new SqlParameter("userLastName", SqlDbType.VarChar);
                lastNameParameter.Value = userLastName;
                addNewCustomerCommand.Parameters.Add(lastNameParameter);

                var streetParameter = new SqlParameter("userStreet", SqlDbType.VarChar);
                streetParameter.Value = userStreet;
                addNewCustomerCommand.Parameters.Add(streetParameter);

                var cityParameter = new SqlParameter("userCity", SqlDbType.VarChar);
                cityParameter.Value = userCity;
                addNewCustomerCommand.Parameters.Add(cityParameter);

                var stateParameter = new SqlParameter("userState", SqlDbType.VarChar);
                stateParameter.Value = userState;
                addNewCustomerCommand.Parameters.Add(stateParameter);

                var zipCodeParameter = new SqlParameter("userZipCode", SqlDbType.Int);
                zipCodeParameter.Value = userZipCode;
                addNewCustomerCommand.Parameters.Add(zipCodeParameter);

                var phoneParameter = new SqlParameter("userPhone", SqlDbType.Int);
                phoneParameter.Value = userPhone;
                addNewCustomerCommand.Parameters.Add(phoneParameter);



                addNewCustomerCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _customerConnection.Close();
            }
        }
    }
}
