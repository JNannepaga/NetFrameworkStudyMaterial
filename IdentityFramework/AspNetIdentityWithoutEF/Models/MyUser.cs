using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityOwinIntegrationWithoutEF.Models
{
    public class MyUser
    {
        //Properties
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get 
            {
                return this.FirstName + this.LastName;
            } 
        } 
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool PhoneVerified { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorAuthEnabled { get; set; }
        
        //Navigational Properties
        public ICollection<MyRole> Roles { get; set; }
        public ICollection<MyUserLogins> UserLogins { get; set; }
        public MyUser()
        {
            Roles = new List<MyRole>();
            UserLogins = new List<MyUserLogins>();
        }
    }
}