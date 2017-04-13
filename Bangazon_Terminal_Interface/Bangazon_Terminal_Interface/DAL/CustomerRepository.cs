using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Bangazon_Terminal_Interface.Bangazon;
using Bangazon_Terminal_Interface.Controllers.Contracts;

namespace Bangazon_Terminal_Interface.DAL
{
    public class CustomerRepository : ICustomer
    {
        Customer _newCustomer = new Customer();
        private readonly IDbConnection _customerConnection;

        public CustomerRepository()
        {
            _customerConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["RavenClausBangazon"].ConnectionString);
        }

        public Customer AddNewCustomerAccount(string userFirstName, string userLastName, string userStreet,
            string userCity, string userState, int userZipCode, int userPhone)
        {
            //Database Interaction:
            _customerConnection.Open();

            try
            {
                var addNewCustomerCommand = _customerConnection.CreateCommand();
                addNewCustomerCommand.CommandText = @"
                    INSERT INTO RavenClausBangazon.dbo.Customer(FirstName, LastName, Street, City, State, ZipCode, Phone) 
                    VALUES( @userFirstName, @userLastName, @userStreet, @userCity, @userState, @userZipCode, @userPhone);
                    SELECT SCOPE_IDENTITY()";


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

                var reader = addNewCustomerCommand.ExecuteScalar();

                if (reader != null)
                {
                    var id = reader.ToString();
                    _newCustomer.CustomerId = Convert.ToInt32(id);
                    _newCustomer.FirstName = userFirstName;
                    _newCustomer.LastName = userLastName;
                    _newCustomer.City = userCity;
                    _newCustomer.Phone = userPhone;
                    _newCustomer.ZipCode = userZipCode;
                    _newCustomer.Street = userStreet;
                    _newCustomer.State = userState;

                    Console.WriteLine("Your Name is " + userFirstName + userLastName);
                    Console.WriteLine("Your Address is " + userStreet);
                    Console.WriteLine(userCity + userState + userZipCode);

                    Console.WriteLine("Record inserted successfully ID = " + id);
                    Console.WriteLine(_newCustomer.CustomerId);
                }
                return _newCustomer;
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
           
            return null;
        }
    }

}