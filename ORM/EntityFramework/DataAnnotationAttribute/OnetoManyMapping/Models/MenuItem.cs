using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.DataAnnotationAttribute.OnetoManyMapping
{
    [Table("MenuItem")]
    public class MenuItem
    {
        //Scalar Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ItemId", Order = 0, TypeName = "INT")]
        public int ItemId { get; set; }

        [Column("ItemName", Order = 1, TypeName = "VARCHAR")]
        [MaxLength(50, ErrorMessage = "First Name shouldn't be less than 5 chars & not exceed more than 50 chars.")]
        public string ItemName { get; set; }

        [Column("Price", Order = 2, TypeName = "MONEY")]
        public decimal? Price { get; set; }

        [Column("OrderId", Order = 3, TypeName = "INT")]
        public int? OrderRefId { get; set; }

        //Navigational Properties
        [ForeignKey("OrderRefId")]
        public virtual Order Order { get; set; }

    }
}
