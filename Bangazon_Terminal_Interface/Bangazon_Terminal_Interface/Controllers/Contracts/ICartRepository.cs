using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.Controllers.Contracts
{
    public interface ICartRepository
    {
        void addNewCart(int paymentId, int customerId, int cartTotalPrice);

        Cart getCart(int cartId);

    }
}
