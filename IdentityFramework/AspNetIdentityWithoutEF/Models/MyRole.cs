using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityOwinIntegrationWithoutEF.Models
{
    public class MyRole
    {
        //Properties
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigational Properties
        [ForeignKey("Id")]
        public ICollection<MyUser> Users { get; set; }

        public MyRole()
        {
            Users = new List<MyUser>();
        }
    }
}