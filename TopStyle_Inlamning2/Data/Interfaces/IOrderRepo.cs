using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Data.Interfaces
{
    public interface IOrderRepo
    {
        Task PlaceOrder(Order order);
        Task<List<Order>> GetOrders(int userId);
        Task <List<Product>> GetProductsById(List<int> productIds);
    }
}
