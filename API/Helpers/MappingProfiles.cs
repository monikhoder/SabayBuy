using System;
using AutoMapper;
using Core.Dtos;
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
        .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category!.CategoryName));
        CreateMap<ProductVariant, ProductVariantDto>();
        CreateMap<VariantAttribute, VariantAttributeDto>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<CreateProductVariantDto, ProductVariant>();
        CreateMap<CreateVariantAttributeDto, VariantAttribute>();
        CreateMap<UpdateProductDto, Product>();
        CreateMap<UpdateProductVariantDto, ProductVariant>();
    }

}
