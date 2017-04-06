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

        public void AddPaymentType(string name)
        {
            _paymentConnection.Open();

            try
            {
                var addPaymentTypeCommand = _paymentConnection.CreateCommand();
                addPaymentTypeCommand.CommandText = "INSERT INTO PaymentType(name) VALUES(@name)";
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
    }
}
