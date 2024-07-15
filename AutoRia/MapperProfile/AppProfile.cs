using AutoMapper;
using AutoRia.Dtos;
using AutoRia.Entities;

namespace ShopMvcApp_PV212.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<CarDto, Car>().ReverseMap();
        }
    }
}