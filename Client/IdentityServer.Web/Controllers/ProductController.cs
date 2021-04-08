using IdentityServer.Web.ApiServices.Interfaces;
using IdentityServer.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductsWebService _productsWebService;
        public ProductController(ILogger<ProductController> logger, IProductsWebService productsWebService)
        {
            _logger = logger;
            _productsWebService = productsWebService;
        }
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            List<ProductDto> list = new List<ProductDto>();
            var resp = await _productsWebService.GetAllProductsAsync<ResponseDto>();
            if (resp.IsSuccess)
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
                var resp = await _productsWebService.UpdateProductAsync<ResponseDto>(model);
                if (resp.IsSuccess)
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
                var resp = await _productsWebService.GetProductByIdAsync<ResponseDto>(id);
                if (resp.IsSuccess)
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
                var resp = await _productsWebService.UpdateProductAsync<ResponseDto>(model);
                if (resp.IsSuccess)
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

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
