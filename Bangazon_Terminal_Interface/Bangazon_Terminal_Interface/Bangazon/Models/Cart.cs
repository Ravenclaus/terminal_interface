using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.Bangazon.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int PaymentId { get; set; }

        public int CusomerId { get; set; }

        public int OrderTotalPrice { get; set; }
}
}
