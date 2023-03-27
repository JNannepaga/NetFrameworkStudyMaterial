using System;

namespace AOPFramework.RealProxy.CustomerServiceRepoPattern
{
    public class DynamicProxyImplementor
    {
        public static void Encounter()
        {
            Console.WriteLine("***\r\n Begin program - logging\r\n");
            IRepository<Customer> customerRepository = new DynamicProxy<IRepository<Customer>>(new Repository<Customer>()).GetTransparentProxy()
                                                       as IRepository<Customer>;
            var customer = new Customer
            {
                Id = 1,
                Name = "Customer 1",
                Address = "Address 1"
            };

            customerRepository.Add(customer);
            customerRepository.Update(customer);
            customerRepository.Delete(customer);
            Console.WriteLine("\r\nEnd program - logging\r\n***");
            Console.ReadLine();
        }
    }
}
