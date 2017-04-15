using Bangazon_Terminal_Interface.Bangazon.Models;
using Bangazon_Terminal_Interface.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.DAL
{
    public class CartRepository : ICartRepository
    {
        IDbConnection _cartConnection;

        public CartRepository()
        {
            _cartConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RavenClausBangazon"].ConnectionString);
        }
        public void addNewCart(int paymentId, int customerId, int cartTotalPrice)
        {
            _cartConnection.Open();

            try
            {
                var addNewCartCommand = _cartConnection.CreateCommand();
                addNewCartCommand.CommandText = "INSERT INTO RavenClausBangazon.dbo.Cart(paymentId, customerId, cartTotalPrice) VALUES(@paymentId, @customerId, @cartTotalPrice )"; // (row or columns )  --> (@ is the parameters)

                var newPaymentParameter = new SqlParameter("paymentId", SqlDbType.Int); //THIS NEEDS TO CROSS REF YOUR SQL DATA
                newPaymentParameter.Value = paymentId; //this needs to be your first parameter
                addNewCartCommand.Parameters.Add(newPaymentParameter);

                var customerParameter = new SqlParameter("customerId", SqlDbType.Int); //THIS NEEDS TO CROSS REF YOUR SQL DATA
                customerParameter.Value = customerId; //this needs to be your first parameter
                addNewCartCommand.Parameters.Add(customerParameter);

                var cartTotalPriceParameter = new SqlParameter("cartTotalPrice", SqlDbType.Int); //THIS NEEDS TO CROSS REF YOUR SQL DATA
                cartTotalPriceParameter.Value = cartTotalPrice; //this needs to be your first parameter
                addNewCartCommand.Parameters.Add(cartTotalPriceParameter);

                addNewCartCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _cartConnection.Close();
            }
        }


        public Cart getCart(int cartId)
        {
            _cartConnection.Open();

            try
            {

                var getCartCommand = _cartConnection.CreateCommand();
                getCartCommand.CommandText = @"
                SELECT cartId, paymentId, customerId, cartTotalPrice 
                FROM Cart 
                WHERE CartId = @cartId";
                var cartIdParam = new SqlParameter("cartId", SqlDbType.Int);
                cartIdParam.Value = cartId;
                getCartCommand.Parameters.Add(cartIdParam);

                var reader = getCartCommand.ExecuteReader();
                if (reader.Read())
                {
                    var cart = new Cart
                    {
                        CartId = reader.GetInt32(0),
                        PaymentId = reader.GetInt32(1),
                        CustomerId = reader.GetInt32(2),
                        CartTotalPrice = reader.GetInt32(3)
                    };
                    return cart;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("This is not working!");
            }
            finally
            {
                _cartConnection.Close();
            }
            return null;
        }
    }
}

