using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.DataAnnotationAttribute.OnetoManyMapping
{
    [Table("Customer")]
    public class Customer
    {
        #region Properties
        //Scalar Properties
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CustomerId", Order = 0, TypeName = "INT")]
        public int CustomerId { get; set; }
        
        [Required]
        [MinLength(5, ErrorMessage = "First Name shouldn't be less than 5 chars & not exceed more than 50 chars.")]
        [MaxLength(50, ErrorMessage = "First Name shouldn't be less than 5 chars & not exceed more than 50 chars.")]
        [Column("FirstName", Order = 1, TypeName = "VARCHAR")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Last Name should not exceed 50 chars.")]
        [Column("LastName", Order = 2, TypeName = "VARCHAR")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { 
            get 
            {
                return string.Format("{0} {1}",this.FirstName, this.LastName);
            } 
        }

        [Column("Gender", Order = 3, TypeName = "INT")]
        public Gender? Gender { get; set; }

        //Navigational Properties
        public virtual ICollection<Order> Orders { get; set; }
        #endregion

        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
    }
}
