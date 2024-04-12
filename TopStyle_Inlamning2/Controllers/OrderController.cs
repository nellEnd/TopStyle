using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopStyle_Inlamning2.Core.Interfaces;
using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Admin")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task <IActionResult> Get(int userId)
        {
            var orders = await _service.GetOrders(userId);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(PlaceOrderDTO order)
        {
            try
            {
                await _service.PlaceOrder(order);
                return Ok("Order made.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
