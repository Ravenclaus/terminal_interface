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
            _paymentConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RavenClausBangazon2"].ConnectionString);

        }

        public void AddPaymentType(string name)
        {
            _paymentConnection.Open();

            try
            {
                var addPaymentTypeCommand = _paymentConnection.CreateCommand();
                addPaymentTypeCommand.CommandText = "INSERT INTO RavenClausBangazon2.dbo.Payment(paymentType) VALUES(@name)";
                var nameParameter = new SqlParameter("name", SqlDbType.VarChar);
                nameParameter.Value = name;
                addPaymentTypeCommand.Parameters.Add(nameParameter);

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
    }
}
