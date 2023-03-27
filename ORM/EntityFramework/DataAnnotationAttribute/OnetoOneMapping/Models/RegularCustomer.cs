using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.DataAnnotationAttribute.OnetoOneMapping
{
    [Table("RegularCustomer")]
    public class RegularCustomer : Customer
    {
        #region Properties
        //Scalar Properties
        [Column("AdvCredits", TypeName = "MONEY")]
        public decimal AdvCredits { get; set; }

        [Column("Perks", TypeName = "VARCHAR")]
        [StringLength(30, ErrorMessage = "Shouldn't exceed morethan 30 chars")]
        public string Perks { get; set; }

        //Navigational Properties
        public virtual Catelog Catelog { get; set; }
        #endregion
    }
}
