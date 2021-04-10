using IdentityServer.Web.Models;
using System;
using System.Threading.Tasks;

namespace IdentityServer.Web.ApiServices.Interfaces
{
    public interface IProductsWebService : IDisposable
    {
        Task<T> GetAllProductsAsync<T>(string token);
        Task<T> GetActiveProductsAsync<T>(string token);
        Task<T> GetProductByIdAsync<T>(long id, string token);
        Task<T> CreateProductAsync<T>(ProductDto productDto, string token);
        Task<T> UpdateProductAsync<T>(ProductDto productDto, string token);
        Task<T> DeleteProductAsync<T>(long id, string token);
    }
}
