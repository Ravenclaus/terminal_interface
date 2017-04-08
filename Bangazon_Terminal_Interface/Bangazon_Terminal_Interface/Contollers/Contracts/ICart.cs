using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.Contollers.Contracts
{
    public interface ICart
    {
       void addNewCart (int paymentId, int customerId, int cartTotalPrice);

        void editCart(int paymentId, int customerId, int cartTotalPrice);

        void deleteCart(int cartId);

        void retrieveCart(int cartId);
      
    }
}
