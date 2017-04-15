using Bangazon_Terminal_Interface.Bangazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bangazon_Terminal_Interface.Bangazon.Models;

namespace Bangazon_Terminal_Interface.Controllers.Contracts
{
    public interface IPayment
    {
        Payment AddPaymentType(string name, int acctNum, int customerId);

        Customer GetCustomer( int customerId);

        List<Payment> GetPaymentList (int customerId);

    }
}
