using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.Controllers.Contracts
{
    public interface IPayment
    {
        void AddPaymentType(string name);

        //void AddPaymentId (int paymentId)

        //Void AddAcctNumber (int acctNumber)

    }
}
