using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bangazon_Terminal_Interface.Bangazon.Models;

namespace BangazonUnitTest
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void EnsuretNameIsValid()
        {
            Validation validation = new Validation();
            string name = "John 08";

            bool expectedResult = true;
            bool actualResult = validation.ValidateName(name);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void EnsureStreetIsValid()
        {
            Validation validation = new Validation();
            string street = "6578 Smith St";

            bool actualResult = validation.ValidateAddress(street);

            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void EnsureCityIsValid()
        {
            Validation validation = new Validation();
            string city = "East Tawas";

            bool actualResult = validation.ValidateCity(city);

            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void EnsureStateIsValid()
        {
            Validation validation = new Validation();
            string state = "MI";

            bool actualResult = validation.ValidateState(state);

            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void EnsureZipIsValid()
        {
            Validation validation = new Validation();
            string zip = "48833";

            bool actualResult = validation.ValidateZip(zip);

            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void EnsurePhoneIsValid()
        {
            Validation validation = new Validation();
            string phone = "615-987-2373";

            bool actualResult = validation.ValidatePhone(phone);

            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void EnsureCardIsValid()
        {
            Validation validation = new Validation();
            string cardNum = "3536 9808 6374 9846";

            bool actualResult = validation.ValidateCard(cardNum);

            Assert.IsTrue(actualResult);
        }
    }
}
