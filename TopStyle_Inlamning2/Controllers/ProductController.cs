using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopStyle_Inlamning2.Core.Interfaces;
using TopStyle_Inlamning2.Data;
using TopStyle_Inlamning2.Data.Repos;

namespace TopStyle_Inlamning2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _service.GetProducts();
            return Ok(products);
        }

        [HttpGet("{searchCondition}")]
        public async Task<IActionResult> SearchProducts(string searchCondition)
        {
            var result = await _service.SearchProduct(searchCondition);
            return Ok(result);
        }
    }
}
