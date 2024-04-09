using System.ComponentModel.DataAnnotations;

namespace TopStyle_Inlamning2.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}