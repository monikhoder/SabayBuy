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
        CreateMap<ProductVariant, POSProductVariantDto>()
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductId))
            .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product != null ? s.Product.ProductName : string.Empty))
            .ForMember(d => d.ProductImageUrl, o => o.MapFrom(s => s.Product != null ? s.Product.BaseImageUrl : null))
            .ForMember(d => d.Brand, o => o.MapFrom(s => s.Product != null ? s.Product.Brand : string.Empty))
            .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Product != null && s.Product.Category != null ? s.Product.Category.CategoryName : string.Empty))
            .ForMember(d => d.VariantId, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.VariantName, o => o.MapFrom(s => string.Join(" / ", s.Attributes.Select(a => $"{a.AttributeName}: {a.AttributeValue}"))))
            .ForMember(d => d.VariantImageUrl, o => o.MapFrom(s => s.ImageUrl));
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
