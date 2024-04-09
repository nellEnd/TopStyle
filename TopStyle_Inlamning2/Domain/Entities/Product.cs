using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TopStyle_Inlamning2.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public int Price { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
