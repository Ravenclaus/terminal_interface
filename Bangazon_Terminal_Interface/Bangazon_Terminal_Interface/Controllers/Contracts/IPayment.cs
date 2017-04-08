using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.Controllers.Contracts
{
    public interface IPayment
    {
        void AddPaymentType(string name, int acctNum, int customerId);

        void AddPaymentId(int paymentId);

        void AddAcctNumber(int acctNumber);

        //void GetCustomerId(int customerId);

    }
}
