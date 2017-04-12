using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bangazon_Terminal_Interface.Bangazon.Models;
using System.Data;
using System.Data.SqlClient;

namespace Bangazon_Terminal_Interface.Bangazon
{
    public class ProductRepository : IProductRepository
    {
        IDbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RavenClausBangazon"].ConnectionString);


        public ProductRepository()
        {

        }


        public List<Product> GetProduct()
        {
            throw new NotImplementedException();
        }

    }
}
