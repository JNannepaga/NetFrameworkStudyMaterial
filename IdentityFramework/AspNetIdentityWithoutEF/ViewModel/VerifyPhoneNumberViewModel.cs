using System.ComponentModel.DataAnnotations;


namespace IdentityOwinIntegrationWithoutEF.ViewModel
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
        
        [Phone]
        [Display(Name = "Code")]
        public string Code { get; set; }
    }

}