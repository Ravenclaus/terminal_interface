using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Bangazon_Terminal_Interface.Bangazon.Models;

namespace Bangazon_Terminal_Interface.Bangazon.DAL
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

                var productPriceParameter = new SqlParameter("productPrice", SqlDbType.Int);
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

        public List<Product> GetProduct(int productId, string productName, double productPrice)
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

                var productNameParameter = new SqlParameter("productName", SqlDbType.VarChar);
                productNameParameter.Value = productName;
                getProductCommand.Parameters.Add(productNameParameter);

                var productPriceParameter = new SqlParameter("productPrice", SqlDbType.Int);
                productPriceParameter.Value = productPrice;
                getProductCommand.Parameters.Add(productPriceParameter);

                var reader = getProductCommand.ExecuteReader();

                var products = new List<Product>();
                while (reader.Read())
                {
                    var product = new Product
                    {
                        ProductId = reader.GetInt32(0),
                        //ProductId = Convert.ToInt32(reader),
                        ProductName = reader.GetString(1),
                        ProductPrice = reader.GetDouble(2)
                        //, Cart = new Cart { CartId = reader.GetInt32(3)}
                    };
                    products.Add(product);
                }
                return products;
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
            return null;
        }
    }
}
