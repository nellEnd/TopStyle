using AutoMapper;
using TopStyle_Inlamning2.Core.Interfaces;
using TopStyle_Inlamning2.Data.Interfaces;
using TopStyle_Inlamning2.Domain.DTO;

namespace TopStyle_Inlamning2.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            var products = await _repo.GetProducts();

            var dtoList = new List<ProductDTO>();

            foreach (var product in products)
            {
                dtoList.Add(_mapper.Map<ProductDTO>(product));
            }

            return dtoList;
        }

        public async Task<List<ProductDTO>> SearchProduct(string searchCondition)
        {
            var results = await _repo.SearchProduct(searchCondition);

            var dtoList = new List<ProductDTO>();

            foreach (var product in results)
            {
                dtoList.Add(_mapper.Map<ProductDTO>(product));
            }

            return dtoList;
        }
    }
}
