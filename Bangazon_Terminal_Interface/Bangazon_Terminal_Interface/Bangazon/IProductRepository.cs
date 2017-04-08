using Bangazon_Terminal_Interface.Bangazon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.Bangazon
{
    public interface IProductRepository
    {
        // Read methods
        //List<Product> GetProduct();

        void AddProductId(int productId);

        void AddProductName(string name);

        void AddProductPrice(int price);
    }
}
