using Bangazon_Terminal_Interface.Contollers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace Bangazon_Terminal_Interface.DAL
{
    public class CartRepository : ICart
    {
        IDbConnection _paymentConnection; //SHOULD THIS BE UNIVERSAL? or Should it be called _cartConnection?

        public CartRepository()
        {
            _paymentConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public void AddOrderId(int orderId)
        {
            _paymentConnection.Open();

            try
            {
                var addOrderIdCommand = _paymentConnection.CreateCommand();
                addOrderIdCommand.CommandText = "INSERT INTO RavenClausBangazon2.dbo.Order(orderId) VALUES(@orderId)"; //DOUBLE CHECK THIS dbo.Order and column with NEW SQL DB DATA FROM MIKE
                var orderParameter = new SqlParameter("orderId", SqlDbType.VarChar);
                orderParameter.Value = orderId;

                addOrderIdCommand.Parameters.Add(orderParameter);
                addOrderIdCommand.ExecuteNonQuery();
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

        public void AddPayType(string payType)
        {
            _paymentConnection.Open();

            try
            {
                var addPayTypeCommand = _paymentConnection.CreateCommand();
                addPayTypeCommand.CommandText = "INSERT INTO RavenClausBangazon2.dbo.Order(orderId) VALUES(@orderId)"; //DOUBLE CHECK THIS dbo.Order and column with NEW SQL DB DATA FROM MIKE
                var payTypeParameter = new SqlParameter("orderId", SqlDbType.VarChar);
                payTypeParameter.Value = payType;

                addPayTypeCommand.Parameters.Add(payTypeParameter);
                addPayTypeCommand.ExecuteNonQuery();
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
