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

        //void AddProductId(int productId);

        void AddProduct(string productName, double productPrice);

        int GetProduct(int productId);
        
    }
}
