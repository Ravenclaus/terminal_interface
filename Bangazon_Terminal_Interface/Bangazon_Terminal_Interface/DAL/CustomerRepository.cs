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
using Bangazon_Terminal_Interface.Bangazon;

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

        public List<Customer> GetListOfExisitingCustomers()
        {
            //throw new NotImplementedException();
            _customerConnection.Open();

            try
            {
                var getAllExistingCustomersCommand = _customerConnection.CreateCommand();
                getAllExistingCustomersCommand.CommandText = @"
                    SELECT CustomerId, FirstName, LastName, Street, City, State, ZipCode, Phone
                    FROM Customer
                    ";

                var reader = getAllExistingCustomersCommand.ExecuteReader();

                var existingCustomers = new List<Customer>();

                while (reader.Read())
                {
                    var individualCustomer = new Customer
                    {
                        CustomerId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Street = reader.GetString(3),
                        City = reader.GetString(4),
                        State = reader.GetString(5),
                        ZipCode = reader.GetInt32(6),
                        Phone = reader.GetInt32(7)
                    };

                    existingCustomers.Add(individualCustomer);
                    //Console.WriteLine(existingCustomers[0]);
                    Console.WriteLine(individualCustomer.FirstName);
                }


                return existingCustomers;

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

            return new List<Customer>();
        }
    }
}
