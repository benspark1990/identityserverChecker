using IdentityServer.Api.Dto;
using IdentityServer.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityServer.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class SecureProductController : BaseController
    {

        private readonly ILogger<SecureProductController> _logger;
        private readonly IProductService _productService;
        public SecureProductController(ILogger<SecureProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
            this._response = new ResponseDto();
        }

        // GET: api/<SecureProductController>
        [HttpGet]
        [Route("api/SecureProduct")]
        public async Task<object> Get()
        {
            try
            {

                var data = await _productService.GetAllProducts();
                _response.Result = data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString()  };
            }
            return _response;
        }
        // GET: api/<SecureProductController>
        [HttpGet]
        [Route("api/SecureProduct/Active")]
        public async Task<object> GetActive()
        {
            try
            {

                var data = await _productService.GetActiveProducts();
                _response.Result = data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        // GET api/<SecureProductController>/5
        [HttpGet]
        [Route("api/SecureProduct/{id}")]
        public async Task<object> Get(long id)
        {
            try
            {

                var data = await _productService.GetProductById(id);
                _response.Result = data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<SecureProductController>
        [HttpPost]
        [Route("api/SecureProduct")]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                var data = await _productService.CreateUpdateProduct(productDto);
                _response.Result = data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // PUT api/<SecureProductController>/5
        [HttpPut]
        [Route("api/SecureProduct")]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                var data = await _productService.CreateUpdateProduct(productDto);
                _response.Result = data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE api/<SecureProductController>/5
        [HttpDelete]
        [Route("api/SecureProduct/{id}")]
        public async Task<object> Delete(long id)
        {
            try
            {
                var data = await _productService.DeleteProduct(id);
                _response.Result = data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
