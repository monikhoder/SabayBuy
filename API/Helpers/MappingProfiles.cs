using AutoMapper;
using API.Dtos;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryDto>()
            .ForMember(d => d.ProductCount, o => o.MapFrom(s =>
                s.SubCategories != null && s.SubCategories.Any()
                    ? s.SubCategories.Sum(subCategory => subCategory.Products.Count)
                    : s.Products.Count));
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<Product, ProductDto>()
        .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category!.CategoryName))
        .ForMember(d => d.Price, o => o.MapFrom(s => s.Variants != null && s.Variants.Count > 0 ? s.Variants.First().Price : 0))
        .ForMember(d => d.Stock, o => o.MapFrom(s => s.Variants != null ? s.Variants.Sum(v => v.StockQuantity) : 0));
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
        CreateMap<Order, OrderDto>()
            .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()))
            .ForMember(d => d.PaymentMethod, o => o.MapFrom(s => s.PaymentMethod.ToString()))
            .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
            .ForMember(d => d.DeliveryPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductId))
            .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
            .ForMember(d => d.ProductVariantId, o => o.MapFrom(s => s.ItemOrdered.ProductVariantId))
            .ForMember(d => d.VariantName, o => o.MapFrom(s => s.ItemOrdered.VariantName));

    }

}
