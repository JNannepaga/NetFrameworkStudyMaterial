using System;
using System.Security.Principal;
using System.Threading;

namespace AOPFramework.RealProxy.CustomerServiceMyArch
{
    public class DynamicProxyImplementor
    {
        public static void Encounter()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity("Administrator"),
                new[] { "ADMIN" });

            IAdminService adminService = DynamicProxyFactory.CreateAdminService();
            Customer customer = new Customer()
            {
                Id = 1,
                Name = "Joseph",
                Address = "Guntur"
            };
            adminService.AddCustomerDetails(customer);

            IUserService userService = DynamicProxyFactory.CreateUserService();
            User user = new User()
            {
                UserID = 1,
                Password = "123abc"
            };
            userService.AddUser(user);

            Console.ReadLine();
        }
    }
}
