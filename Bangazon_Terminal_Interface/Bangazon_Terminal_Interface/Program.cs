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
            bool addingNewProducts = true;
            ProductRepository productRepo = new ProductRepository();

            //while (addingNewProducts)
            //{
                Console.WriteLine("Enter product: ");

                string productName = Console.ReadLine();


                Console.WriteLine("Enter price: ");

                double productPrice = double.Parse(Console.ReadLine());

                productRepo.AddProduct(productName, productPrice);
            //}

        }
    }
}
