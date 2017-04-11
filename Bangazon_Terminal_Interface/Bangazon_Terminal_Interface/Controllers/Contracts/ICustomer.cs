using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.Controllers.Contracts
{
    interface ICustomer
    {
        void AddNewCustomerAccount(string userFirstName, string userLastName, string userStreet, string userCity, string userState, int userZipCode, int userPhone);
        /*
        Customer GetCustomerById(int customerId);
        List<Customer> GetListOfExisitingCustomers();
        */
    }
}
