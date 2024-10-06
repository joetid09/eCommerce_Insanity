using AutoMapper;
using eCommerce_Insanity.DTOs;
using eCommerce_Insanity.Models;

namespace eCommerce_Insanity.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>();
        }
    }
}
