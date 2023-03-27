using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.DataAnnotationAttribute.OnetoOneMapping
{
    [Table("CustomerCateloges")]
    public class Catelog
    {
        #region Properties
        //Scalar Properties
        [Key]
        public int CatelogId { get; set; }

        [Column("CatelogName", TypeName = "VARCHAR")]
        [StringLength(25, ErrorMessage = "Shouldn't exceed morethan 30 chars")]
        public string CatelogName { get; set; }

        [Column("CatelogPassword", TypeName = "VARCHAR")]
        [StringLength(25, ErrorMessage = "Shouldn't exceed morethan 20 chars")]
        public string CatelogPassword { get; set; }

        [Column("isActivated", TypeName = "BIT")]
        public bool? isActive { get; set; }

        //Navigational Properties
        [Required]
        [ForeignKey("CatelogId")]
        public virtual RegularCustomer RegularCustomer { get; set; }
        #endregion

        #region Constructors
        public Catelog()
        {

        }

        public Catelog(string catelogName, string catelogPassword, bool isActive)
        {
            this.CatelogName = catelogName;
            this.CatelogPassword = catelogPassword;
            this.isActive = isActive;
        }
        #endregion
    }
}
