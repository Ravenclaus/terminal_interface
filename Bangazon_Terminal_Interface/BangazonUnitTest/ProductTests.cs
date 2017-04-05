using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bangazon_Terminal_Interface.Bangazon.Models;

namespace BangazonUnitTest
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void EnsureCanCreateProduce()
        {
            Product product = new Product();
            Assert.IsNotNull(product);
        }
    }
}
