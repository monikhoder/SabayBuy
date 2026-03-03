using AutoMapper;
using API.Dtos;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<Product, ProductDto>()
        .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category!.CategoryName))
        .ForMember(d => d.Price, o => o.MapFrom(s => s.Variants != null && s.Variants.Count > 0 ? s.Variants.First().Price : 0));
        CreateMap<ProductVariant, ProductVariantDto>();
        CreateMap<VariantAttribute, VariantAttributeDto>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<CreateProductVariantDto, ProductVariant>();
        CreateMap<CreateVariantAttributeDto, VariantAttribute>();
        CreateMap<UpdateProductDto, Product>();
        CreateMap<UpdateProductVariantDto, ProductVariant>();
        CreateMap<RegisterDto, AppUser>()
            .ForMember(u => u.UserName, r => r.MapFrom(s => s.Email));
        CreateMap<AppUser, UserDto>();
        CreateMap<AddressDto, Address>();
        CreateMap<Address, AddressDto>();
    }

}
