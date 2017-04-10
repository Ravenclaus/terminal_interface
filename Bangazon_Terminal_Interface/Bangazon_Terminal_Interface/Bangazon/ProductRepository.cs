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
        

        public void AddProductId(int productId)
        {
            _productConnection.Open();

            try
            {
                var addProductIdCommand = _productConnection.CreateCommand();
                addProductIdCommand.CommandText = "Insert Into RavenClausBangazon.dbo.Product(productId) Values(@productId)";
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

        
        public void GetProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public void GetProductName(string name)
        {
            throw new NotImplementedException();
        }

        public void GetProductPrice(int price)
        {
            throw new NotImplementedException();
        }
    }
}
