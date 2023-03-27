using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.DataAnnotationAttribute.OnetoOneMapping
{
    [Table("CustomerRequisite")]
    public class CustomerRequisite
    {
        #region Properties
        //Scalar Properties
        [Key]
        [Column("CustomerId", Order = 0, TypeName = "INT")]
        public int CustomerRequisiteId { get; set; }
        
        [Required]
        [Column("MobileNum", Order = 1, TypeName = "VARCHAR")]
        [StringLength(10)]
        [RegularExpression("^[0-9]{10}$",ErrorMessage ="Mobile Number should be of 10 digits")]
        public string Mobile { get; set; }

        [Column("IdProofType", Order = 2, TypeName = "INT")]
        public IdProofType? IdProofType { get; set; }

        [Column("IdProof", Order = 3, TypeName = "VARCHAR")]
        [StringLength(25, ErrorMessage = "Proof should be of 25chars only")]
        public string IdProof { get; set; }

        //Navigation Properties
        [Required]
        [ForeignKey("CustomerRequisiteId")]
        public virtual Customer Customer { get; set; }
        #endregion

        #region Constructors
        public CustomerRequisite()
        {

        }

        public CustomerRequisite(string mobile, IdProofType idProofType, string idProof)
        {
            this.Mobile = mobile;
            this.IdProofType = idProofType;
            this.IdProof = idProof;
        }
        #endregion
    }
}
