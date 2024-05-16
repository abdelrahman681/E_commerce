using AutoMapper;
using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Entity.OrderEntity;

namespace E_commerce.API.Helper
{
    public class OrderItemResorver : IValueResolver<OrderItem, OrderItemDto, string>
    {
    
        private readonly IConfiguration _configuration;

        public OrderItemResorver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrWhiteSpace(source.productItemOrder.PictureUrl) ? $"{_configuration["BaseUrl"]}{source.productItemOrder.PictureUrl}" : string.Empty;
        }
    }
}

