using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bangazon_Terminal_Interface.Controllers.Contracts;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Bangazon_Terminal_Interface.DAL
{
    public class PaymentRepository : IPayment
    {
        IDbConnection _paymentConnection;
        
      public PaymentRepository()
        {
            //_paymentConnection = paymentConnection;
            _paymentConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RavenClausBangazon"].ConnectionString);

        }

        public void AddPaymentType(string payType, int acctNum, int customerId = 1)
        {
            _paymentConnection.Open();

            try
            {
                var addPaymentTypeCommand = _paymentConnection.CreateCommand();
                addPaymentTypeCommand.CommandText = "INSERT INTO RavenClausBangazon.dbo.Payment(paymentType, accountNumber, customerId) VALUES(@paymentType, @accountNumber, @customerId)";

                var payTypeParameter = new SqlParameter("paymentType", SqlDbType.VarChar);
                payTypeParameter.Value = payType;
                addPaymentTypeCommand.Parameters.Add(payTypeParameter);

                var accountNumParameter = new SqlParameter("accountNumber", SqlDbType.Int);
                accountNumParameter.Value = acctNum;
                addPaymentTypeCommand.Parameters.Add(accountNumParameter);

                var customerIdParameter = new SqlParameter("customerId", SqlDbType.Int);
                customerIdParameter.Value = customerId;
                addPaymentTypeCommand.Parameters.Add(customerIdParameter);

                addPaymentTypeCommand.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _paymentConnection.Close();
            }
        }

        public string GetCustomerName(string customerName)
        {
            var customName = "";
            _paymentConnection.Open();

            try
            {
               
                var getCustomerNameCommand = _paymentConnection.CreateCommand();
                getCustomerNameCommand.CommandText = @"
                                                    SELECT FirstName
                                                    FROM Customer 
                                                    WHERE FirstName = @customerName";
                var customerParameter = new SqlParameter("customerName", SqlDbType.VarChar);
                customerParameter.Value = customerName;
                getCustomerNameCommand.Parameters.Add(customerParameter);

                var reader = getCustomerNameCommand.ExecuteReader();
                
                while (reader.Read())
                {
                    customName = reader.GetString(0);
                }
                // string newName = getCustomerNameCommand.ExecuteScalar().ToString();
                //Console.WriteLine(newName);

            }

            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            
            finally
            {
                _paymentConnection.Close();
                
            }
            return customName;
        }

        public void GetCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
