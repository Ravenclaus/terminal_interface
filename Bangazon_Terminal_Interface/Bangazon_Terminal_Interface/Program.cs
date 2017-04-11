using Bangazon_Terminal_Interface.Bangazon;
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
            ProductRepository productRepo = new ProductRepository();
            Console.WriteLine("Enter product: ");

            string productName = Console.ReadLine();


            Console.WriteLine("Enter price: ");

            int productPrice = int.Parse(Console.ReadLine());

            productRepo.AddProduct(productName, productPrice);
        }
    }
}
