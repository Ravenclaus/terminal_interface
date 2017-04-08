using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bangazon_Terminal_Interface.Bangazon.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Bangazon_Terminal_Interface.Bangazon
{
    public class ProductRepository : IProductRepository
    {
        IDbConnection _productConnection;

        public ProductRepository()
        {
            _productConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RavenClausBangazon2"].ConnectionString);
        }
        

        public void AddProductId(int productId)
        {
            _productConnection.Open();

            try
            {
                var addProductIdCommand = _productConnection.CreateCommand();
                addProductIdCommand.CommandText = "Insert Into RavenClausBangazon2.dbo.Product(productId) Values(@productId)";
                var idParameter = new SqlParameter("productId", SqlDbType.Int);
                idParameter.Value = productId;
                addProductIdCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _productConnection.Close();
            }
        }

        public void AddProductName(string name)
        {
            throw new NotImplementedException();
        }

        public void AddProductPrice(int price)
        {
            throw new NotImplementedException();
        }
    }
}
