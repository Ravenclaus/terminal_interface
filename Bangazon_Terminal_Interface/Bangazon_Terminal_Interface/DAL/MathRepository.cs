using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bangazon_Terminal_Interface.Controllers;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Bangazon_Terminal_Interface.DAL
{
    public class MathRepository : IMath
    {
        IDbConnection _mathConnection; 

        public MathRepository()
        {
            _mathConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RavenClausBangazon"].ConnectionString);
        }

        public void FindOrderTotal(int totalCost)
        {
            throw new NotImplementedException();
        }

        public void FindPopularity(int rank)
        {
            throw new NotImplementedException();
        }
    }
}
