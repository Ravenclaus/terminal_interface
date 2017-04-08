using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.Controllers.Contracts
{
    interface ICustomer
    {
        void AddNewCustomerAccount(int customerId, string firstName, string lastName, string street, string city, string state, int zipCode, int phone);

        /*
        Customer GetCustomerById(int customerId);
        List<Customer> GetListOfExisitingCustomers();
        */
    }
}
