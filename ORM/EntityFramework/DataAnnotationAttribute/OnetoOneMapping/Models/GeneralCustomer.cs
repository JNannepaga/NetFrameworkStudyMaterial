using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.DataAnnotationAttribute.OnetoOneMapping
{
    [Table("GeneralCustomer")]
    public class GeneralCustomer : Customer
    {
        #region Properties
        //Scalar Properties
        [Column("Credits", TypeName = "MONEY")]
        public decimal Credits { get; set; }

        [Column("NormalCoupon", TypeName = "VARCHAR")]
        [StringLength(30, ErrorMessage = "Shouldn't exceed morethan 30 chars")]
        public string NormalCoupon { get; set; }
        #endregion
    }
}
