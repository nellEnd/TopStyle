using System.ComponentModel.DataAnnotations;

namespace TopStyle_Inlamning2.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}