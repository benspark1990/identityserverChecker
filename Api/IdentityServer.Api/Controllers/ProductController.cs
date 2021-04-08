using IdentityServer.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            return new List<ProductDto>()
            { new ProductDto { ID = 1, Name = "P1", Description = "Product 1", CreatedOn = DateTimeOffset.Now, ModifiedOn = DateTimeOffset.Now },
              new ProductDto { ID = 2, Name = "P2", Description = "Product 2", CreatedOn = DateTimeOffset.Now, ModifiedOn = DateTimeOffset.Now } };
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            return new ProductDto { ID = 1, Name = "P1", Description = "Product 1", CreatedOn = DateTimeOffset.Now, ModifiedOn = DateTimeOffset.Now };
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductDto productDto)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDto productDto)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
