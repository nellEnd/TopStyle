using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Core.Interfaces
{
    public interface IOrderService
    {
        Task PlaceOrder(PlaceOrderDTO order);
        Task <List<OrderViewDTO>> GetOrders(string userId);

    }
}
