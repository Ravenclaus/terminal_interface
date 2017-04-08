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

        public void AddPaymentId(int paymentId)
        {
            _paymentConnection.Open();

            try
            {
                var addPaymentIdCommand = _paymentConnection.CreateCommand();
                addPaymentIdCommand.CommandText = "INSERT INTO RavenClausBangazon2.dbo.Payment(paymentType) VALUES(@paymentId)";
                var idParameter = new SqlParameter("paymentId", SqlDbType.Int);
                idParameter.Value = paymentId;
                addPaymentIdCommand.Parameters.Add(idParameter);

                addPaymentIdCommand.ExecuteNonQuery();

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

        public void AddAcctNumber(int acctNumber)
        {
            _paymentConnection.Open();

            try
            {
                var addAccountCommand = _paymentConnection.CreateCommand();
                addAccountCommand.CommandText = "INSERT INTO RavenClausBangazon2.dbo.Payment(AccountNumber) VALUES(@accountNumber)";
                var acctParameter = new SqlParameter("accountNumber", SqlDbType.Int);
                acctParameter.Value = acctNumber;
                addAccountCommand.Parameters.Add(acctParameter);

                addAccountCommand.ExecuteNonQuery();

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
    }
}
