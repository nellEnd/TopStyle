using Microsoft.EntityFrameworkCore;
using TopStyle_Inlamning2.Data.Interfaces;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Data.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly TopStyleContext _context;

        public OrderRepo(TopStyleContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrders(int userId)
        {
            var orders = _context.Orders.Where(o => o.User.UserId == userId)
                .Include(o => o.Products)
                .ThenInclude(p => p.Category)
                .ToListAsync();
            return await orders;
        }

        public async Task<List<Product>> GetProductsById(List<int> productIds)
        {
            return await _context.Products.Where(p => productIds.Contains(p.ProductId)).ToListAsync();
        }

        public async Task PlaceOrder(Order order)
        {
            //var orderList = _context
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }


    }
}
