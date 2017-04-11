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
        

        public void AddProduct(string productName, int productPrice)
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

        public void AddProductId(int productId)
        {
            throw new NotImplementedException();
        }

    }
}
