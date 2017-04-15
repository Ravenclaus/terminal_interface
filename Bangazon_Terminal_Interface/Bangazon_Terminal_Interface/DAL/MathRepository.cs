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

        //total # of orders place

        public void FindOrderTotal(int totalCost)
        {
            _mathConnection.Open();

            try
            {
                var addOrderTotalCommand = _mathConnection.CreateCommand();
                addOrderTotalCommand.CommandText = "GET stuff";
                var totalCostParameter = new SqlParameter("totalCost", SqlDbType.Float);
                totalCostParameter.Value = totalCost;
                addOrderTotalCommand.Parameters.Add(totalCostParameter);

                addOrderTotalCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _mathConnection.Close();
            }
        }

        public string FindPopularity(string rank)
        {
            //GetMostPopularItem ? 
            _mathConnection.Open();

            try
            {
                var addPopularityCommand = _mathConnection.CreateCommand();
                addPopularityCommand.CommandText = "SELECT * FROM Product ORDER BY ProductPrice DESC;";
                // CHECK OUT BELOW STUFF -- do we need a PRODUCTS, ORDERS, CUSTOMERS, and REVENUE parameter? 
                var rankParameter = new SqlParameter("rank", SqlDbType.Float);
                rankParameter.Value = rank;
                addPopularityCommand.Parameters.Add(rankParameter);

                addPopularityCommand.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _mathConnection.Close();
            }
        }

        public void TotalRevenue(int totalRevenue)
        {
            throw new NotImplementedException();
        }
    }
}
