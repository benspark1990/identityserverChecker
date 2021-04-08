using Ardalis.Specification;
using IdentityServer.Api.Entities;
using System;
using System.Linq;

namespace IdentityServer.Api.Specifications
{
    public class ProductsSpecification : Specification<ProductEntity>
    {
        public ProductsSpecification()
        {
            Query.Where(c => !c.IsDeleted);
        }
    }
}
