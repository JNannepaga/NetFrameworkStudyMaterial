using IdentityOwinIntegrationWithoutEF.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class UserStore
        : IUserStore<User, int>, IUserPasswordStore<User, int>, IUserRoleStore<User, int>, IUserLoginStore<User, int>,
          IUserEmailStore<User, int>, IUserPhoneNumberStore<User, int>,
          IClaimsIdentityFactory<User, int>, IUserLockoutStore<User, int>, IUserTwoFactorStore<User, int>,
          IUserSecurityStampStore<User, int>
    {

        private readonly AuthAPI _authAPI;
        public UserStore(AuthAPI authAPI)
        {
            _authAPI = authAPI;
        }

        #region UserStore Implementation
        public Task CreateAsync(User user)
        {
            _authAPI.CreateUser(user);
            return Task.FromResult(0);
        }

        public Task DeleteAsync(User user)
        {
            //Don't remove the User
            return Task.FromResult(0);
        }

        public Task<User> FindByIdAsync(int userId)
        {
            if (userId <= 0)
                return Task.FromResult<User>(default(User));

            User result = _authAPI.FindUserById(userId).Map();
            return Task.FromResult<User>(result ?? default(User));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return Task.FromResult<User>(default(User));

            User result = _authAPI.FindUserByName(userName).Map();
            return Task.FromResult<User>(result ?? default(User));
        }

        public Task UpdateAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            _authAPI.Dispose();
        }

        #endregion

        #region UserPasswordStore Implementation

        public Task<string> GetPasswordHashAsync(User user)
        {
            if (user?.Id <= 0)
                return Task.FromResult<string>(string.Empty);

            return Task.FromResult<string>(_authAPI.GetPasswordHash(user));
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            if (user == null)
                return Task.FromResult<bool>(false);

            return Task.FromResult<bool>(_authAPI.HasPassword(user));
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            if (user?.Id <= 0)
                return Task.FromResult(0);

            _authAPI.SetPasswordHash(user, passwordHash);
            user.Password = passwordHash;
            return Task.FromResult(0);
        }
        #endregion

        #region UserRoleStore Implementation

        public Task AddToRoleAsync(User user, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            return Task.FromResult<IList<string>>(_authAPI.GetRoles(user));
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            return Task.FromResult<bool>(_authAPI.IsInRole(user, roleName));
        }
        #endregion

        #region IUserEmail Implementation

        public Task SetEmailAsync(User user, string email)
        {
            if (user != null)
                _authAPI.SetUserEmail(user, email);

            user.Email = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(User user)
        {
            if (user?.Id <= 0)
                return Task.FromResult<string>(user.Email);

            MyUser result = _authAPI.FindUserById(user.Id);
            user.Email = result.Email;
            return Task.FromResult<string>(result.Email ?? string.Empty);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            if (user?.Id <= 0)
                return Task.FromResult<bool>(user.EmailVerified);

            MyUser myUser = _authAPI.FindUserById(user.Id);
            user.EmailVerified = myUser.EmailVerified;
            return Task.FromResult<bool>(myUser.PhoneVerified);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            _authAPI.SetUserEmailConfirmed(user, confirmed);
            return Task.FromResult(0);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                return Task.FromResult<User>(_authAPI.FindByUserEmail(email).Map());

            return Task.FromResult<User>(default(User));
        }
        #endregion

        #region IUserPhoneNumberStore
        public Task SetPhoneNumberAsync(User user, string phoneNumber)
        {
            if (user.Id <= 0)
                return Task.FromResult(0);

            _authAPI.SetPhoneNumber(user, phoneNumber);
            return Task.FromResult(0);
        }

        public Task<string> GetPhoneNumberAsync(User user)
        {
            if (user?.Id <= 0)
                return Task.FromResult<string>(user.Phone);

            MyUser myUser = _authAPI.FindUserById(user.Id);
            user.Phone = myUser.Phone;
            return Task.FromResult<string>(myUser.Phone);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(User user)
        {
            if (user?.Id <= 0)
                return Task.FromResult<bool>(user.PhoneVerified);

            MyUser myUser = _authAPI.FindUserById(user.Id);
            user.PhoneVerified = myUser.PhoneVerified;
            return Task.FromResult<bool>(myUser.PhoneVerified);
        }

        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed)
        {
            if (user.Id <= 0)
                return Task.FromResult(0);

            _authAPI.SetPhoneNumberConfirmed(user, confirmed);
            return Task.FromResult(0);
        }
        #endregion

        #region IClaimsStoreImplementation
        public Task<ClaimsIdentity> CreateAsync(UserManager<User, int> manager, User user, string authenticationType)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName, ClaimValueTypes.String),
                new Claim(ClaimTypes.Name, user.FullName, ClaimValueTypes.String),
                new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.String),
            };

            foreach (MyRole role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name, ClaimValueTypes.String));
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(authenticationType, ClaimTypes.Name, ClaimTypes.Role);
            claimsIdentity.AddClaims(claims);
            return Task.FromResult(claimsIdentity);
        }
        #endregion

        #region IUserLockOutStore
        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserTwoFactor

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            user.TwoFactorAuthEnabled = true;
            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            user.TwoFactorAuthEnabled = true;
            return Task.FromResult<bool>(true);
        }
        #endregion

        #region IUserSeacurityStamp

        public Task SetSecurityStampAsync(User user, string stamp)
        {
            if (user.Id <= 0)
            {
                user.SecurityStamp = stamp;
                return Task.FromResult(0);
            }
                
            _authAPI.SetSecurityStamp(user, stamp);
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(User user)
        {
            if (user.Id <= 0)
                return Task.FromResult<string>(user.SecurityStamp);

            MyUser myuser =_authAPI.FindUserById(user.Id);
            return Task.FromResult<string>(myuser.SecurityStamp);
        }
        #endregion

        #region Implement IUserLoginStore
        public Task AddLoginAsync(User user, UserLoginInfo login)
        {
            MyUserLogins myUserLogins = new MyUserLogins()
            {
                User = user.Map(),
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey
            };
            _authAPI.CreateUserLogin(myUserLogins);

            return Task.FromResult(0);
        }

        public Task RemoveLoginAsync(User user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            IList<UserLoginInfo> userLoginInfos = new List<UserLoginInfo>();
            List<MyUserLogins> myUserLogins = _authAPI.GetLoginsById(user.Id);
            foreach (MyUserLogins userLogin in myUserLogins)
            {
                userLoginInfos.Add(userLogin.Map());
            }

            return Task.FromResult<IList<UserLoginInfo>>(userLoginInfos);
        }

        public Task<User> FindAsync(UserLoginInfo login)
        {
            MyUserLogins myUserLogins = new MyUserLogins()
            {
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey
            };
            return Task.FromResult<User>(_authAPI.GetUser(myUserLogins).Map());
        }
        #endregion
    }
}