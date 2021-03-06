﻿using System;
using System.Collections.Generic;
using System.Linq;
using EComponent.DataAccess.DataModels;
using EComponent.Services.Responses;
using AutoMapper;

namespace EComponent.DataAccess.Mappings
{
    public class MappingProfiles : Profile
    {
        protected override void Configure()
        {
            ConfigureDataModelToResponseMappings();

            base.Configure();
        }

        private static void ConfigureDataModelToResponseMappings()
        {
            Mapper.CreateMap<ProductCategory, ProductCategoryResponse>();
            Mapper.CreateMap<Product, ProductResponse>();
            Mapper.CreateMap<Attribute, AttributeResponse>();
            Mapper.CreateMap<AttributeValue, AttributeValueResponse>();
            Mapper.CreateMap<ProductPrice, ProductPriceResponse>();
        }
    }
}
