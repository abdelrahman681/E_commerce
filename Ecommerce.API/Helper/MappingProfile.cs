using AutoMapper;
using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Entity.Basket;
using E_Commerce.Domain.Entity.NewFolder;
using E_Commerce.Domain.Entity.OrderEntity;

namespace E_commerce.API.Helper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductBrand, BrandTypeDto>();
            CreateMap<ProductType, BrandTypeDto>();

            CreateMap<Products, ProductToReturnDTO>()
                .ForMember(d=>d.BrandName,o=>o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(d=>d.TypeName,o=>o.MapFrom(s=>s.ProductType.Name))
                .ForMember(d=>d.PictureUrl,o=>o.MapFrom<PictureURLResolver>());

            CreateMap<CustomerBasket,CustomerBasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();


            CreateMap<Order, OrderResultDto>().ForMember(d=>d.DeliveryMethod,op=>op.MapFrom(src=>src.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, op => op.MapFrom(src => src.DeliveryMethod.Price));

            CreateMap<OrderItem, OrderItemDto>().ForMember(d=>d.ProductId,m=>m.MapFrom(src=>src.productItemOrder.ProductId))
                .ForMember(d => d.ProductName, m => m.MapFrom(src => src.productItemOrder.ProductName))
                .ForMember(d => d.PictureUrl, m => m.MapFrom<OrderItemResorver>());
            CreateMap<ShippingAddress, AddressDto>().ReverseMap();


        }
    }
}
