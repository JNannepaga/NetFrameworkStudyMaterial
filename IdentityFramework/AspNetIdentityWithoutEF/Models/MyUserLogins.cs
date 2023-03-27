using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityOwinIntegrationWithoutEF.Models
{
    public class MyUserLogins
    {
        [Required]
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }
        [Required]
        [Key]
        [Column(Order = 1)]
        public string LoginProvider { get; set; }
        [Required]
        [Key]
        [Column(Order = 2)]
        public string ProviderKey { get; set; }

        //Navigation Properties
        [ForeignKey("UserId")]
        public MyUser User { get; set; }
    }
}