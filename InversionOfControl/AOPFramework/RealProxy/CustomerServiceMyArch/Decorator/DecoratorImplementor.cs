using System;

namespace AOPFramework.RealProxy.CustomerServiceMyArch
{
    public class DecoratorImplementor
    {
        public static void Encounter()
        {
            IAdminService adminService = new AdminServiceLogger();
            Customer customer = new Customer()
            {
                Id = 1,
                Name = "Joseph",
                Address = "Guntur"
            };
            adminService.AddCustomerDetails(customer);

            IUserService userService = new UserServiceLogger();
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
