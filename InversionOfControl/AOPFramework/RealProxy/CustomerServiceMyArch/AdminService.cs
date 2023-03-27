using System;

namespace AOPFramework.RealProxy
{
    public class AdminService : IAdminService
    {
        public void AddCustomerDetails(Customer customer)
        {
            new AddCustomerDetailsHandler().Invoke();
        }

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

    }
}
