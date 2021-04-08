using IdentityServer.Api.Dto;
using IdentityServer.Api.Entities;
using IdentityServer.Api.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IAsyncRepository<ProductEntity> _productRepository;

        public ProductService(IAsyncRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDto> CreateProduct(ProductDto viewModel)
        {
            return viewModel;
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}
