using IdentityServer.Web.ApiServices.Interfaces;
using IdentityServer.Web.Constants;
using IdentityServer.Web.Models;
using System.Threading.Tasks;

namespace IdentityServer.Web.ApiServices
{
    public class ProductsWebService : BaseWebService, IProductsWebService
    {
        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = "Product",
                ApiType = ApiType.GET,
                AccessToken= token
            });
        }
        public async Task<T> GetActiveProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = "Product/Active",
                ApiType = ApiType.GET,
                AccessToken = token
            });
        }
        public async Task<T> GetProductByIdAsync<T>(long id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = "Product/" + id,
                ApiType = ApiType.GET,
                AccessToken = token
            });
        }
        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Data = productDto,
                Url = "Product",
                ApiType = ApiType.POST,
                AccessToken = token
            });
        }
        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Data = productDto,
                Url = "Product",
                ApiType = ApiType.PUT,
                AccessToken = token
            });
        }
        public async Task<T> DeleteProductAsync<T>(long eventid, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = "Product/" + eventid,
                ApiType = ApiType.DELETE,
                AccessToken = token
            });
        }
    }
}
