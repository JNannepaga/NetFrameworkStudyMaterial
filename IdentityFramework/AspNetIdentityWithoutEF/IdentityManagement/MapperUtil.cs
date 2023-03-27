using IdentityOwinIntegrationWithoutEF.Models;
using Microsoft.AspNet.Identity;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public static class MapperUtil
    {
        public static MyUser Map(this User user)
        {
            return user == null ? default(MyUser) :
            new MyUser()
            {
                Id = user.Id,
                Email = user.Email,
                EmailVerified = user.EmailVerified,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password,
                Phone = user.Phone,
                PhoneVerified = user.PhoneVerified,
                SecurityStamp = user.SecurityStamp,
                TwoFactorAuthEnabled = user.TwoFactorAuthEnabled
            };
        }

        public static User Map(this MyUser myUser)
        {
           return  myUser == null ? default(User) : 
            new User()
            {
                Id = myUser.Id,
                Email = myUser.Email,
                EmailVerified = myUser.EmailVerified,
                FirstName = myUser.FirstName,
                LastName = myUser.LastName,
                UserName = myUser.UserName,
                Password = myUser.Password,
                Phone = myUser.Phone,
                PhoneVerified = myUser.PhoneVerified,
                SecurityStamp = myUser.SecurityStamp,
                TwoFactorAuthEnabled = myUser.TwoFactorAuthEnabled
            };
        }

        public static UserLoginInfo Map(this MyUserLogins myUser)
        {
            return myUser == null ? default(UserLoginInfo) :
                new UserLoginInfo(myUser.LoginProvider, myUser.ProviderKey);
        }
    }
}