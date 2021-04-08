using IdentityServer.Api.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Api.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateUpdateProduct(ProductDto viewModel);
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<IEnumerable<ProductDto>> GetActiveProducts();
        Task<ProductDto> GetProductById(long Id);
        Task<bool> DeleteProduct(long Id);

    }
}
