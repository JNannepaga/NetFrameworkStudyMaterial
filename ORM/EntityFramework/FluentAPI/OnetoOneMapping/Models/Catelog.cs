
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.FluentAPI.OnetoOneMapping
{
    public class Catelog
    {
        #region Properties
        //Scalar Properties
        public int CatelogId { get; set; }

        [MaxLength(25, ErrorMessage = "Shouldn't exceed morethan 20 chars")]
        public string CatelogName { get; set; }
        
        [MaxLength(25, ErrorMessage = "Shouldn't exceed morethan 20 chars")]
        public string CatelogPassword { get; set; }
        public bool? isActive { get; set; }

        //Navigational Properties
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
