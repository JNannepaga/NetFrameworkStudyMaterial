using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class AppUserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public AppUserInfo(int id, string userName, string name, string email, string phone)
        {
            this.Id = id;
            this.UserName = userName;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
        }

        public static AppUserInfo SystemLogger = new AppUserInfo(0, "system", "system@sytem.com", "DefaultLogger", string.Empty);
    }
}