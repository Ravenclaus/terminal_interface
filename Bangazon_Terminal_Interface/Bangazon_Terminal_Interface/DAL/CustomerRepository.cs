using Bangazon_Terminal_Interface.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.DAL
{
    class CustomerRepository : ICustomer
    {
        IDbConnection _customerConnection;

        public CustomerRepository()
        {
            _customerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public void AddNewCustomerAccount(int customerId, string firstName, string lastName, string street, string city, string state, int zipCode, int phone)
        {
            _customerConnection.Open();

            try
            {
                var addNewCustomerCommand = _customerConnection.CreateCommand();
                addNewCustomerCommand.CommandType = "INSERT INTO RavenClausBangazon2.dbo.Customer(customerId) VALUES(@customerId)";
                var customerParameter = new SqlParameter("customerId", SqlDbType.Int);
                customerParameter.Value = customerId;

                addNewCustomerCommand.Parameters.Add(customerParameter);
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
