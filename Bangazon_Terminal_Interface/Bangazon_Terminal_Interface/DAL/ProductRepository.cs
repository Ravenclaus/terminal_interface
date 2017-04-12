using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _productConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RavenClausBangazon"].ConnectionString);
        }
        

        public void AddProduct(string productName, double productPrice)
        {
            _productConnection.Open();

            try
            {
                var addProductCommand = _productConnection.CreateCommand();
                addProductCommand.CommandText = "Insert Into RavenClausBangazon.dbo.Product(productName, productPrice) Values(@productName, @productPrice)";

                var productNameParameter = new SqlParameter("productName", SqlDbType.VarChar);
                productNameParameter.Value = productName;
                addProductCommand.Parameters.Add(productNameParameter);

                var productPriceParameter = new SqlParameter("productPrice", SqlDbType.VarChar);
                productPriceParameter.Value = productPrice;
                addProductCommand.Parameters.Add(productPriceParameter);

                addProductCommand.ExecuteNonQuery();
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

        public int GetProduct(int productId)
        {
            _productConnection.Open();

            try
            {
                var getProductCommand = _productConnection.CreateCommand();
                getProductCommand.CommandText = @"
                    SELECT productId, productName, productPrice 
                    FROM RavenClausBangazon.dbo.Product 
                    WHERE productId = @productId";

                var productIdParameter = new SqlParameter("productId", SqlDbType.Int);
                productIdParameter.Value = productId;
                getProductCommand.Parameters.Add(productIdParameter);

                var reader = getProductCommand.ExecuteReader();

                if (reader.Read())
                {
                    var product = new Product
                }
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
            return 0;
        }
    }
}
