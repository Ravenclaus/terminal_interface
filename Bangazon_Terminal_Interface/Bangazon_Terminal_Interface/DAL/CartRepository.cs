using Bangazon_Terminal_Interface.Contollers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Bangazon_Terminal_Interface.DAL
{
    public class OrderRepository : IOrder
    {
        IDbConnection _paymentConnection;

        public OrderRepository()
        {
            _paymentConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

    }
}
