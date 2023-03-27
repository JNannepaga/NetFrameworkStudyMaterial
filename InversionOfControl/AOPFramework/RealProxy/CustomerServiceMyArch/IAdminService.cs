
namespace AOPFramework.RealProxy
{
    public interface IAdminService
    {
        void AddCustomerDetails(Customer customer);

        void DeleteCustomer(int id);
    }
}
