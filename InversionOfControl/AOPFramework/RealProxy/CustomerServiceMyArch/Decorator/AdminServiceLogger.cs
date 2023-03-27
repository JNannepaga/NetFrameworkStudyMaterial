using System;

namespace AOPFramework.RealProxy.CustomerServiceMyArch
{
    public class AdminServiceLogger : IAdminService
    {
        private readonly IAdminService _adminService;

        public AdminServiceLogger()
            : this(null)
        {

        }

        public AdminServiceLogger(IAdminService adminService)
        {
            _adminService = adminService ?? new AdminService();
        }

        public void AddCustomerDetails(Customer customer)
        {
            Log("Before Adding a customer");
            _adminService.AddCustomerDetails(customer);
            Log("After Adding a customer");
        }

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }
    }
}
