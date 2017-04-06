using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bangazon_Terminal_Interface.DAL;

namespace Bangazon_Terminal_Interface
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("name");
            string test = Console.ReadLine();
            PaymentRepository paymentRepository = new PaymentRepository();
            paymentRepository.AddPaymentType(test);
        }
    }
}
