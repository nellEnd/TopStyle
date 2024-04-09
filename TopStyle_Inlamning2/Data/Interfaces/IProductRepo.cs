using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Data.Interfaces
{
    public interface IProductRepo
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> SearchProduct(string searchCondition);

    }
}
