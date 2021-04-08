using IdentityServer.Web.ApiServices.Interfaces;
using IdentityServer.Web.Constants;
using IdentityServer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
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
            //var client = new HttpClient();

            //var content = await client.GetStringAsync(GlobalConstants.ApiBase + "/Product");

            //ViewBag.Json = content;// JArray.Parse(content).ToString();
            var list = await _productsWebService.GetAllProductsAsync<ProductDto>();
            ViewBag.Json = JsonConvert.SerializeObject(list);
            return View("json");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorDto { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
