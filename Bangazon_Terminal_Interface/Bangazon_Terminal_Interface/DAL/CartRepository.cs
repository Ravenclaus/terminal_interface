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
        IDbConnection _cartConnection; 

        public CartRepository()
        {
            _cartConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public void addNewCart(int paymentId, int customerId, int cartTotalPrice)
        {
            _cartConnection.Open();

            try
            {
                var addNewCartCommand = _cartConnection.CreateCommand();
                addNewCartCommand.CommandText = "INSERT INTO RavenClausBangazon2.dbo.Cart(cartId) VALUES(@cartName)"; 
                var newCartParameter = new SqlParameter("cartName", SqlDbType.VarChar); //THIS NEEDS TO CROSS REF YOUR SQL DATA
                newCartParameter.Value = cartName;

                addNewCartCommand.Parameters.Add(newCartParameter);
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

        public void deleteCart(int cartId)
        {
            throw new NotImplementedException();
        }

        public void editCart(int paymentId, int customerId, int cartTotalPrice)
        {
            throw new NotImplementedException();
        }

        public void retrieveCart(int cartId)
        {
            throw new NotImplementedException();
        }
    }
}
