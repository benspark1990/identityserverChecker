using IdentityServer.Web.ApiServices.Interfaces;
using IdentityServer.Web.Constants;
using IdentityServer.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IdentityServer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsWebService _productsWebService;
        public HomeController(ILogger<HomeController> logger, IProductsWebService productsWebService)
        {
            _logger = logger;
            _productsWebService = productsWebService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> CallApi()
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var content = await client.GetStringAsync("https://localhost:44303/api/product");

                var resObj = JsonConvert.DeserializeObject<ResponseDto>(content);

                ViewBag.Json = JsonConvert.SerializeObject(resObj);
            }
            finally
            {
                    
            }
            return View("json");

        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorDto { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
