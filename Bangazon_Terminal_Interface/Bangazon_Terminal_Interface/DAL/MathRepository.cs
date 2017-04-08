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
            _mathConnection.Open();

            try
            {
                var addOrderTotalCommand = _mathConnection.CreateCommand();
                addOrderTotalCommand.CommandText = "INSERT INTO RavenClausBangazon2.dbo.OrderTotalPrice(totalCost) VALUES(@totalCost)";
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

        public void FindPopularity(int rank)
        {
            _mathConnection.Open();

            try
            {
                var addPopularityCommand = _mathConnection.CreateCommand();
                // No column for Popularity in Products table, but do we need one, or are we just, a single time, finding the most popular item (times ordered)?
                addPopularityCommand.CommandText = "INSERT INTO RavenClausBangazon2.dbo.Popularity(rank) VALUES(@rank)";
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
    }
}
