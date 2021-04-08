using AutoMapper;
using IdentityServer.Api.Dto;
using IdentityServer.Api.Entities;
using IdentityServer.Api.Interfaces;
using IdentityServer.Api.Specifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IAsyncRepository<ProductEntity> _productRepository;
        protected IMapper _mapper;

        public ProductService(IAsyncRepository<ProductEntity> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto viewModel)
        {
            var model = this._mapper.Map<ProductDto, ProductEntity>(viewModel);
            if (model.ID > 0)
            {
                model.ModifiedOn = DateTime.Now;
                await _productRepository.UpdateAsync(model);
            }
            else
            {
                model.CreatedOn = DateTime.Now;
                await _productRepository.AddAsync(model);
            }
            viewModel = this._mapper.Map<ProductEntity, ProductDto>(model);
            return viewModel;
        }

        public async Task<bool> DeleteProduct(long Id)
        {
            var model = await _productRepository.GetByIdAsync(Id);
            model.IsDeleted = true;
            model.ModifiedOn = DateTimeOffset.Now;
            await _productRepository.UpdateAsync(model);
            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var model = await _productRepository.ListAllAsync();
            return this._mapper.Map<IEnumerable<ProductEntity>, IEnumerable<ProductDto>>(model);
        }
        public async Task<IEnumerable<ProductDto>> GetActiveProducts()
        {
            var model = await _productRepository.ListAsync(new ProductsSpecification());
            return this._mapper.Map<IEnumerable<ProductEntity>, IEnumerable<ProductDto>>(model);
        }

        public async Task<ProductDto> GetProductById(long Id)
        {
            var model = await _productRepository.GetByIdAsync(Id);
            return this._mapper.Map<ProductEntity, ProductDto>(model);
        }
    }
}
