using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TopStyle_Inlamning2.Data.Interfaces;
using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Data.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly TopStyleContext _context;

        public ProductRepo(TopStyleContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
           return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<List<Product>> SearchProduct(string searchCondition)
        {
            var products = _context.Products.Include(p => p.Category).Where(s => s.ProductName.Contains(searchCondition)).ToListAsync();

            return await products;
        }
    }
}
