using IdentityServer.Web.ApiServices.Interfaces;
using IdentityServer.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SecureProductController : Controller
    {
        private readonly ILogger<SecureProductController> _logger;
        private readonly IProductsWebService _productsWebService;
        public SecureProductController(ILogger<SecureProductController> logger, IProductsWebService productsWebService)
        {
            _logger = logger;
            _productsWebService = productsWebService;
        }
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            List<ProductDto> list = new List<ProductDto>();
            var resp = await _productsWebService.GetActiveProductsAsync<ResponseDto>(accessToken);
            if (resp != null && resp.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(resp.Result));
            }
            return View(list);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductDto model)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var resp = await _productsWebService.UpdateProductAsync<ResponseDto>(model, accessToken);
                if (resp != null && resp.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }

        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ProductDto model = new ProductDto();
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var resp = await _productsWebService.GetProductByIdAsync<ResponseDto>(id, accessToken);
                if (resp != null && resp.IsSuccess)
                {
                    model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(resp.Result));
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductDto model)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var resp = await _productsWebService.UpdateProductAsync<ResponseDto>(model, accessToken);
                if (resp != null && resp.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }

        }


        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            ProductDto model = new ProductDto();
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var resp = await _productsWebService.GetProductByIdAsync<ResponseDto>(id, accessToken);
                if (resp != null && resp.IsSuccess)
                {
                    model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(resp.Result));
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ProductDto productDto)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var resp = await _productsWebService.DeleteProductAsync<ResponseDto>(productDto.ID, accessToken);
                if (resp != null && resp.IsSuccess)
                {
                    TempData["ListMessage"] = "Data deleted.";
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
