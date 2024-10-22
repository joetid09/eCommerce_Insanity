using AutoMapper;
using eCommerce_Insanity.DTOs;
using eCommerce_Insanity.Models;

namespace eCommerce_Insanity.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
