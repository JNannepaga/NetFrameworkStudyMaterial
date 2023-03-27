using System;

namespace AOPFramework.RealProxy.CustomerServiceMyArch
{
    public class UserServiceLogger : IUserService
    {
        private readonly IUserService _userService;

        public UserServiceLogger()
            : this(null)
        {

        }

        public UserServiceLogger(IUserService userService)
        {
            _userService = userService ?? new UserService(); 
        }

        public void AddUser(User user)
        {
            Log("Before Adding a user");
            _userService.AddUser(user);
            Log("After Adding a user");
        }

        public void DeleteUser(int Id)
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
