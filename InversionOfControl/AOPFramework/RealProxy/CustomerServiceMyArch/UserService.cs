
namespace AOPFramework.RealProxy
{
    public class UserService : IUserService
    {
        public void AddUser(User user)
        {
            new AddUserDetailsHandler().Invoke();
        }

        public void DeleteUser(int Id)
        {
            throw new System.NotImplementedException();
        }

    }
}
