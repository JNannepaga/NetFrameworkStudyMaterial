using System.ComponentModel.DataAnnotations;

namespace EntityFramework.FluentAPI.OnetoManyMapping
{
    public class MenuItem
    {
        //Scalar Properties
        public int ItemId { get; set; }

        [MaxLength(50, ErrorMessage = "First Name shouldn't be less than 5 chars & not exceed more than 50 chars.")]
        public string ItemName { get; set; }
        
        public decimal? Price { get; set; }

        public int? OrderRefId { get; set; }

        //Navigational Properties
        public virtual Order Order { get; set; }

    }
}
