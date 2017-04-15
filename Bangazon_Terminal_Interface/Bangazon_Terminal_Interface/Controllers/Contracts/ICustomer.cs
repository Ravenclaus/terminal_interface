using Bangazon_Terminal_Interface.Bangazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.Controllers.Contracts
{
    public interface ICustomer
    {
        Customer AddNewCustomerAccount(string userFirstName, string userLastName, string userStreet, string userCity, string userState, int userZipCode, int userPhone);

        

        List<Customer> PickFromListOfExisitingCustomers();

        

        //Customer GetCustomerById(int customerId);



    }
}
