using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Bangazon_Terminal_Interface.DAL;

namespace BangazonUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void EnsureIcanCreateInstance()
        {
            PaymentRepository repo = new PaymentRepository();
            Assert.IsNotNull(repo);
 
    }
    }
}
