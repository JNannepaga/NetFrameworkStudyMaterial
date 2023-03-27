using System;

namespace AOPFramework.RealProxy
{
    internal class AddCustomerDetailsHandler
    {
        public void Invoke()
        {
            Console.WriteLine("Adding a customer to the List");
        }
    }
}
