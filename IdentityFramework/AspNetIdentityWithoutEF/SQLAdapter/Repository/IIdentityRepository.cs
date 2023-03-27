using IdentityOwinIntegrationWithoutEF.Models;
using System.Collections.Generic;

namespace IdentityOwinIntegrationWithoutEF.SQLAdapter
{
    public interface IIdentityRepository : IRepository<MyUser>, IRepository<MyRole>, IRepository<MyUserLogins>
    {
        MyUser FindUserByEmail(string email);

        IList<MyRole> GetUserRoles(int userId);
    }
}