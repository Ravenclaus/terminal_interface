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
            PaymentRepository paymentRepository = new PaymentRepository();

            // GETS CUSTOMER NAME
            //Console.WriteLine("Type in Customer Name");
            //string customerNameReturn = Console.ReadLine();
            ////int customerIdReturn = Int32.Parse(Console.ReadLine());
            //paymentRepository.GetCustomerName(customerNameReturn);
            //Console.WriteLine(customerNameReturn);

            var returnName = paymentRepository.GetCustomerName("Bob");
            
            Console.WriteLine(returnName);

            // ADDS PAYMENT TYPE AND ACCOUNT NUMBER
            Console.WriteLine("Enter payment type (Amex, Visa, Checking)");
            string userPaymentType = Console.ReadLine();
            Console.WriteLine("Please enter account number");
            int userAccountNumber = int.Parse(Console.ReadLine());
            paymentRepository.AddPaymentType(userPaymentType, userAccountNumber);



            // ADDS ACCOUNT NUMBER
            //paymentRepository.AddAcctNumber(userAccountNumber);
        }
    }
}
