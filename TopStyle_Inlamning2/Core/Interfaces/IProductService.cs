﻿using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Core.Interfaces
{
    public interface IProductService
    {

        Task<List<ProductDTO>> GetProducts();
        Task<List<ProductDTO>> SearchProduct(string searchCondition);
    }
}
