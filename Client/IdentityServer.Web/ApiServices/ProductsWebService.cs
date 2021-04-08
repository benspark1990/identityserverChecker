using IdentityServer.Web.ApiServices.Interfaces;
using IdentityServer.Web.Constants;
using IdentityServer.Web.Models;
using System.Threading.Tasks;

namespace IdentityServer.Web.ApiServices
{
    public class ProductsWebService : BaseWebService, IProductsWebService
    {
        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = "Product",
                ApiType = ApiType.GET
            });
        }
        public async Task<T> GetActiveProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = "Product/Active",
                ApiType = ApiType.GET
            });
        }
        public async Task<T> GetProductByIdAsync<T>(long id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = "Product/" + id,
                ApiType = ApiType.GET
            });
        }
        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Data = productDto,
                Url = "Product",
                ApiType = ApiType.POST
            });
        }
        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Data = productDto,
                Url = "Product",
                ApiType = ApiType.PUT
            });
        }
        public async Task<T> DeleteProductAsync<T>(long eventid)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Url = "Product/" + eventid,
                ApiType = ApiType.DELETE
            });
        }
    }
}
