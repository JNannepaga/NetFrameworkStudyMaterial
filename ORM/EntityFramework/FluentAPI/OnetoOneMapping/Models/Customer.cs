using System.ComponentModel.DataAnnotations;

namespace EntityFramework.FluentAPI.OnetoOneMapping
{
    public class Customer
    {
        #region Properties
        //Scalar Properties
        public int CustomerId { get; set; }

        [MinLength(5, ErrorMessage = "First Name shouldn't be less than 5 chars & not exceed more than 50 chars.")]
        [MaxLength(50, ErrorMessage = "First Name shouldn't be less than 5 chars & not exceed more than 50 chars.")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Last Name should not exceed 50 chars.")]
        public string LastName { get; set; }
        public string FullName { 
            get 
            {
                return string.Format("{0} {1}",this.FirstName, this.LastName);
            } 
        }
        public Gender? Gender { get; set; }

        //Navigational Properties
        public virtual CustomerRequisite CustomerRequisites { get; set; }
        #endregion
    }
}
