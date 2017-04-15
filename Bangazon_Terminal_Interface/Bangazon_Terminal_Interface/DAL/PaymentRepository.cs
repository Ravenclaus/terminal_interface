using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Bangazon_Terminal_Interface.Bangazon;
using Bangazon_Terminal_Interface.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Bangazon_Terminal_Interface.Bangazon.Models;

namespace Bangazon_Terminal_Interface.DAL
{
    public class PaymentRepository : IPayment
    {

        Payment _newCustomerPayment = new Payment();
        Customer _customer = new Customer();

        private readonly IDbConnection _paymentConnection;

        public PaymentRepository()
        {
            //_paymentConnection = paymentConnection;
            _paymentConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["RavenClausBangazon"].ConnectionString);
        }

        public Payment AddPaymentType(string payType, int acctNum, int customerId)
        {
            _paymentConnection.Open();

            try
            {
                var addPaymentTypeCommand = _paymentConnection.CreateCommand();
                addPaymentTypeCommand.CommandText =
                    "INSERT INTO RavenClausBangazon.dbo.Payment(paymentType, accountNumber, customerId) VALUES(@paymentType, @accountNumber, @customerId);SELECT SCOPE_IDENTITY()";

                var payTypeParameter = new SqlParameter("paymentType", SqlDbType.VarChar);
                payTypeParameter.Value = payType;
                addPaymentTypeCommand.Parameters.Add(payTypeParameter);

                var accountNumParameter = new SqlParameter("accountNumber", SqlDbType.Int);
                accountNumParameter.Value = acctNum;
                addPaymentTypeCommand.Parameters.Add(accountNumParameter);

                var customerIdParameter = new SqlParameter("customerId", SqlDbType.Int);
                customerIdParameter.Value = customerId;
                addPaymentTypeCommand.Parameters.Add(customerIdParameter);

                var reader = addPaymentTypeCommand.ExecuteScalar();

                if (reader != null)
                {
                    var id = reader.ToString();
                    //customer.CustomerId = _newCustomerPayment
                    _newCustomerPayment.PaymentTypeId = Convert.ToInt32(id);
                    _newCustomerPayment.AccountNumber = acctNum;
                    _newCustomerPayment.PaymentType = payType;
                   
                    Console.WriteLine("Your Payment Id is " + id);
                }
                return _newCustomerPayment;

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _paymentConnection.Close();
            }
            return null;
        }

        public Customer GetCustomer(int customerId)
        {
            _paymentConnection.Open();

            try
            {
                var getCustomerIdCommand = _paymentConnection.CreateCommand();
                getCustomerIdCommand.CommandText = @"
                                                    SELECT CustomerId
                                                    FROM Customer 
                                                    WHERE CustomerId = @customerId";
                var customerParameter = new SqlParameter("customerId", SqlDbType.Int);
                customerParameter.Value = customerId;
                getCustomerIdCommand.Parameters.Add(customerParameter);

                var reader = getCustomerIdCommand.ExecuteReader();

                if (reader.Read())
                    return new Customer
                    {
                        CustomerId = Convert.ToInt32(reader)
                    };
            }

            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

            finally
            {
                _paymentConnection.Close();
            }
            return null;
        }

        public List<Payment> GetPaymentList(int customerId)
        {
            _paymentConnection.Open();
            try
            {
                var getPaymentListCommand = _paymentConnection.CreateCommand();
                getPaymentListCommand.CommandText = @"
                                                    SELECT PaymentId, PaymentType, AccountNumber
                                                    FROM Payment 
                                                    WHERE CustomerId = @customerId";

                var paymentParameter = new SqlParameter("customerId", SqlDbType.Int);
                paymentParameter.Value = customerId;
                getPaymentListCommand.Parameters.Add(paymentParameter);

                var reader = getPaymentListCommand.ExecuteReader();
                List<Payment> userPaymentTypes = new List<Payment>();
                while (reader.Read())
                {
                    Payment payObject = new Payment()
                    {
                        PaymentType = reader.GetString(0),
                        PaymentTypeId = reader.GetInt32(1),
                        AccountNumber = reader.GetInt32(2)
                       
                    };
                    userPaymentTypes.Add(payObject);
                  
                    Console.WriteLine(payObject.PaymentType);
                    return userPaymentTypes;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _paymentConnection.Close();
            }

            return new List<Payment>();
        }
    }
}