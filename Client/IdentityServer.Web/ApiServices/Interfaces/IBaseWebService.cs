using IdentityServer.Web.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServer.Web.ApiServices.Interfaces
{
    public interface IBaseWebService : IDisposable
    {
        HttpClient httpClient { get; set; }
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
