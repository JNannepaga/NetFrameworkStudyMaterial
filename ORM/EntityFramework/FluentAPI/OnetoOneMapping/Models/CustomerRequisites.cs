using System.ComponentModel.DataAnnotations;

namespace EntityFramework.FluentAPI.OnetoOneMapping
{
    public class CustomerRequisite
    {
        #region Properties
        //Scalar Properties
        public int CustomerRequisiteId { get; set; }

        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Mobile Number should be of 10 digits")]
        public string Mobile { get; set; }
        public IdProofType? IdProofType { get; set; }
        public string IdProof { get; set; }

        //Navigation Properties
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
