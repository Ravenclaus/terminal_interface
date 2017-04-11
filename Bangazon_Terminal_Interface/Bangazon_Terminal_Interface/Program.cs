using Bangazon_Terminal_Interface.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface
{
    public class Program
    {
        static void Main(string[] args)
        {
            CartRepository cartRepository = new CartRepository();

            //GETS CART INFORMATION

            //ADDS NEW CUSTOMER CART
            Console.WriteLine("Pick Payment, Customer, Price");
            int PayId = int.Parse(Console.ReadLine());

            Console.WriteLine(" Customer");
            int CustomerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Price");
            int PriceId = int.Parse(Console.ReadLine());

            cartRepository.addNewCart(PayId, CustomerId, PriceId);

        }
    }
}
