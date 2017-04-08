using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.Contollers.Contracts
{
    public interface ICart
    {
       void AddOrderId(int orderId);

       void AddPaymentId(int paymentId);

       void AddPayType(string payType);

       void  AddCustomerId(int customerId); 

      void AddOrderTotalPrice(int otp); 


    }
}
