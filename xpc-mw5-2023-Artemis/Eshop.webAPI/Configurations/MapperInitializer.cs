using AutoMapper;
using Eshop.webAPI.DTO;
using Eshop.webAPI.Models;

namespace Eshop.webAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            // todo-other autoampper je fajn, ale potom do buducna bacha na tieto automatiky, byva to nebezpečne do buducna 
            CreateMap<CategoryModel, CategoryDTO>().ReverseMap();
            CreateMap<CategoryModel, CreateCategoryDTO>().ReverseMap();
            
            // toto je fajn rychle riesenie ale bacha na to aby ste nezamiešali business logiku sem
            CreateMap<ManufacturerModel, ManufacturerDTO>().ForMember(dest => dest.CommodityIds, opt => opt.MapFrom(src => src.Commodities.Select(c => c.Id))).ReverseMap(); 

            CreateMap<ManufacturerModel, CreateManufacturerDTO>().ReverseMap();
            CreateMap<CommodityModel, CommodityDTO>().ReverseMap();
            CreateMap<CommodityModel, CreateCommodityDTO>().ReverseMap();
            CreateMap<ReviewModel, ReviewDTO>().ReverseMap();
            CreateMap<ReviewModel, CreateReviewDTO>().ReverseMap();

        }  
    }
}
