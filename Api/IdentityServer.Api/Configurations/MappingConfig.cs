using AutoMapper;
using IdentityServer.Api.Dto;
using IdentityServer.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Api.Configurations
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AllowNullCollections = true;
                config.AllowNullDestinationValues = true;

                config.CreateMap<ProductEntity, ProductDto>();
                config.CreateMap<ProductDto, ProductEntity>();

            });
            return mappingConfig;
        }
    }
}
