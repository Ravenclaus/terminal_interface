using Bangazon_Terminal_Interface.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Bangazon_Terminal_Interface.DAL
{
    public class CustomerRepository : ICustomer
    {
        IDbConnection _customerConnection;

        public CustomerRepository()
        {
            _customerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RavenClausBangazon"].ConnectionString);
        }

        public void AddNewCustomerAccount(int customerId, string firstName, string lastName, string street, string city, string state, int zipCode, int phone)
        {
            _customerConnection.Open();

            try
            {
                var addNewCustomerCommand = _customerConnection.CreateCommand();
                addNewCustomerCommand.CommandType = @"
                    INSERT INTO 
                    RavenClausBangazon.dbo.Customer(customerId, firstName, lastName, street, city, state, zipCode, phone) 
                    VALUES(@customerId, @firstName, @lastName, @street, @city, @state, @zipCode, @phone)";

                var customerIdParameter = new SqlParameter("customerId", SqlDbType.Int);
                customerIdParameter.Value = customerId;
                addNewCustomerCommand.Parameters.Add(customerIdParameter);
                //do this again for each passing argument


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
