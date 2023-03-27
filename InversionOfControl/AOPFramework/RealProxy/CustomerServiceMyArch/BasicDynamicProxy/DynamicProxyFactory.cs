
namespace AOPFramework.RealProxy.CustomerServiceMyArch
{
    public class DynamicProxyFactory
    {
        public static IAdminService CreateAdminService()
        {
            IAdminService adminService = new AuthProxy<IAdminService>(new AdminService())
                                        .GetTransparentProxy() as IAdminService; 
            adminService = new LoggerProxy<IAdminService>(adminService)
                                        .GetTransparentProxy() as IAdminService;
            return adminService;
        }

        public static IUserService CreateUserService()
        {
            IUserService userService = new AuthProxy<IUserService>(new UserService())
                                        .GetTransparentProxy() as IUserService;
            userService = new LoggerProxy<IUserService>(userService)
                                        .GetTransparentProxy() as IUserService;
            return userService;
        }
    }
}
