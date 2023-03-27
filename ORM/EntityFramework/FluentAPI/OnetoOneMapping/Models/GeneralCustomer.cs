using System.ComponentModel.DataAnnotations;

namespace EntityFramework.FluentAPI.OnetoOneMapping
{
    public class GeneralCustomer : Customer
    {
        #region Properties
        //Scalar Properties
        public decimal Credits { get; set; }

        [MaxLength(30, ErrorMessage = "Shouldn't exceed morethan 30 chars")]
        public string NormalCoupon { get; set; }
        #endregion
    }
}
