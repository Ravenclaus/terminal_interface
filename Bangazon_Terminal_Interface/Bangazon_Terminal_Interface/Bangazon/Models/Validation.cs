using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bangazon_Terminal_Interface.Bangazon.Models
{
    public class Validation
    {

        public bool ValidateName(string userName)
        {
            Match m = Regex.Match(userName, @"((?:[A-Z]+[a-z]*)(?:\s[A-z]+[a-z]*)*)");
            if (m.Success)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Name Entered");
                return false;
            }
        }

        public bool ValidateZip(string userZip)
        {
            Match m = Regex.Match(userZip, @"(^[0-9]{5})");
            if (m.Success)
            {
                return true;
               
            }
            else
            {
                Console.WriteLine("Invalid Zip Code");
                return false;
            }

        }

        public bool ValidateState(string userState)
        {
            Match m = Regex.Match(userState, @"(^[A-Z]{2})");
            if (m.Success)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid State Entered");
                return false;
            }
        }

        public bool ValidateAddress(string userAddress)
        {
            Match m = Regex.Match(userAddress, @"(\d+\s+\w+(?:\s+\w+)*)");
            if (m.Success)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Address Entered");
                return false;
            }
        }

        public bool ValidateCity(string userCity)
        {
            Match m = Regex.Match(userCity, @"([A-Z]+[a-z]+(?:\s+\w+)*)");
            if (m.Success)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid City Entered");
                return false;
            }
        }

        public bool ValidatePhone(string userPhone)
        {
            Match m = Regex.Match(userPhone, @"((?:\d{3}-){2}\d{4})");
            if (m.Success)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Phone Number Entered");
                return false;
            }
        }

        public bool ValidateCard(string userCardNum)
        {
            Match m = Regex.Match(userCardNum, @"((?:\d{4})(?:\s\d{4}){3})");
            if (m.Success)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Card Number Entered");
                return false;
            }

        }
    }
}
