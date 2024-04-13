using AutoMapper;
using TopStyle_Inlamning2.Core.Interfaces;
using TopStyle_Inlamning2.Data.Interfaces;
using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _repo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<OrderViewDTO>> GetOrders(string userId)
        {

            var dtoList = new List<OrderViewDTO>();

            var orders = await _repo.GetOrders(int.Parse(userId));

            foreach (var order in orders)
            {
                dtoList.Add(_mapper.Map<OrderViewDTO>(order));
            }

            return dtoList;
            //return orders;
        }

        public async Task PlaceOrder(PlaceOrderDTO order)
        {
            List<Product> products = await _repo.GetProductsById(order.Products);

            var newOrder = _mapper.Map<Order>(order);
            newOrder.Products = products;

            await _repo.PlaceOrder(newOrder);
        }
    }
}
