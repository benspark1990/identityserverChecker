using IdentityServer.Web.Models;
using System;
using System.Threading.Tasks;

namespace IdentityServer.Web.ApiServices.Interfaces
{
    public interface IProductsWebService : IDisposable
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetActiveProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(long id);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(long id);
    }
}
