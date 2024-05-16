using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Entity.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync();
        Task<OrderResultDto> CreateOrderAsync(OrderDto orderDto); 
        Task<OrderResultDto> GetOrderAsync(Guid Id,string Emaill); 
        Task<IEnumerable<OrderResultDto>> GetAllOrderAsync(string Emaill); 
    }
}
