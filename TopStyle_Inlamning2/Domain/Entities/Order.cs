using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopStyle_Inlamning2.Domain.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public virtual List<Product> Products { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}