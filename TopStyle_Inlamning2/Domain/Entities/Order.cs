using System.ComponentModel.DataAnnotations;

namespace TopStyle_Inlamning2.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual User User { get; set; }
    }
}