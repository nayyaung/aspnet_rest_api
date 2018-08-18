using aspnet_rest_api.data.Model;
using aspnet_rest_api.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_rest_api.Configurations
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Product, ProductDto>().ReverseMap();
            });
        }
    }
}