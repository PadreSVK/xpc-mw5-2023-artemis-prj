﻿using AutoMapper;
using Eshop.webAPI.DTO;
using Eshop.webAPI.Models;

namespace Eshop.webAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<CategoryModel, CategoryDTO>().ReverseMap();
            CreateMap<CategoryModel, CreateCategoryDTO>().ReverseMap();

            CreateMap<ManufacturerModel, ManufacturerDTO>().ReverseMap();
            CreateMap<ManufacturerModel, CreateManufacturerDTO>().ReverseMap();

            
        }  
    }
}
