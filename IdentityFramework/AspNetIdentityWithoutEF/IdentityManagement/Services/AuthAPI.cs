using IdentityOwinIntegrationWithoutEF.Models;
using IdentityOwinIntegrationWithoutEF.SQLAdapter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class AuthAPI : IDisposable
    {
        private readonly IApplicationDBContext _applicationDBContext;
        private readonly IRepository<Models.MyUser> _userRepos;
        private readonly IRepository<Models.MyRole> _rolesRepos;
        private readonly IRepository<Models.MyUserLogins> _userLoginRepos;

        public AuthAPI()
            : this(new ApplicationDBContext())
        {

        }

        public AuthAPI(IApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
            _userRepos = applicationDBContext.IdentityRepository;
            _rolesRepos = applicationDBContext.IdentityRepository;
            _userLoginRepos = applicationDBContext.IdentityRepository;
        }

        public static AuthAPI Create()
        {
            return new AuthAPI();
        }

        #region User Implementations
        public void CreateUser(MyUser user)
        {
            _applicationDBContext.IdentityRepository.Add(user);
            _applicationDBContext.Save();
            return;
        }
        public void UpdateUser(MyUser user)
        {
            throw new NotImplementedException();
        }

        public MyUser FindUserById(int userId)
        {
            return _userRepos.Get(userId);
        }

        public MyUser FindUserByName(string userName)
        {
            return _userRepos.Get(userName);
        }

        public void SetPasswordHash(MyUser user, string passwordHash)
        {
            MyUser myUser = _userRepos.Get(user.Id);
            if (myUser != null)
                myUser.Password = passwordHash;

            _applicationDBContext.Save();
        }

        public string GetPasswordHash(MyUser user)
        {
            MyUser myUser = _userRepos.Get(user.Id);
            return myUser != null ? myUser.Password : string.Empty;
        }

        public bool HasPassword(MyUser user)
        {
            MyUser myUser = _userRepos.Get(user.Id);
            return !string.IsNullOrEmpty(myUser?.Password);
        }

        public void SetUserEmail(MyUser user, string email)
        {
            MyUser myUser = _userRepos.Get(user.Id);
            myUser.Email = email;

            _applicationDBContext.Save();
        }

        public void SetUserEmailConfirmed(MyUser user, bool confimation)
        {
            MyUser myUser = _userRepos.Get(user.Id);
            myUser.EmailVerified = confimation;

            _applicationDBContext.Save();
        }

        public MyUser FindByUserEmail(string email)
        {
            return _applicationDBContext.IdentityRepository.FindUserByEmail(email);
        }

        public void SetPhoneNumber(MyUser user, string phoneNumber)
        {
            MyUser myUser = _userRepos.Get(user.Id);
            myUser.Phone = phoneNumber;
            _applicationDBContext.Save();

            return;
        }

        public void SetPhoneNumberConfirmed(MyUser user, bool confirmed)
        {
            MyUser myUser = _userRepos.Get(user.Id);
            myUser.PhoneVerified = confirmed;
            _applicationDBContext.Save();

            return;
        }

        public void SetSecurityStamp(MyUser user, string stamp)
        {
            MyUser myUser = _userRepos.Get(user.Id);
            myUser.SecurityStamp = stamp;
            _applicationDBContext.Save();

            return;
        }

        public void CreateUserLogin(MyUserLogins userLogin)
        {
            _userLoginRepos.Add(userLogin);
            _applicationDBContext.Save();

            return;
        }

        public List<MyUserLogins> GetLoginsById(int userId)
        {
            return _userLoginRepos.Filter(i => i.User.Id == userId).ToList();
        }

        public MyUser GetUser(MyUserLogins myUserLogins)
        {
            return _userLoginRepos.Filter(i => i.LoginProvider.Equals(myUserLogins.LoginProvider, StringComparison.OrdinalIgnoreCase) &&
            i.ProviderKey.Equals(myUserLogins.ProviderKey, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.User;
        }
        #endregion

        #region Role Operations
        public void AddToRole(MyUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetRoles(MyUser user)
        {
            IList<string> roles = new List<string>();
            IList<MyRole> myUserRoles = _applicationDBContext.IdentityRepository.GetUserRoles(user.Id);
            foreach (MyRole role in myUserRoles)
            {
                roles.Add(role.Name);
            }

            return roles;
        }

        public bool IsInRole(MyUser user, string roleName)
        {
            IList<MyRole> myUserRoles = _applicationDBContext.IdentityRepository.GetUserRoles(user.Id);
            bool isRoleExists = myUserRoles.Any(x => x.Name.Equals(roleName));
            return isRoleExists;
        }

        public void RemoveFromRole(MyUser user, string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void Dispose()
        {
            _applicationDBContext.Dispose();
        }

    }
}