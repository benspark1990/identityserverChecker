using IdentityServer.Api.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Api.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateProduct(ProductDto viewModel);
        Task<List<ProductDto>> GetAllProducts();
    }
}
