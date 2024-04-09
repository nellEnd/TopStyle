using Microsoft.EntityFrameworkCore;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Data
{
    public class TopStyleContext:DbContext
    {
        public TopStyleContext(DbContextOptions<TopStyleContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }


    }
}
