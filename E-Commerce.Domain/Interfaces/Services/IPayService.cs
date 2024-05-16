using E_Commerce.Domain.DataTransfareObject_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces.Services
{
    public interface IPayService
    {
        public Task<CustomerBasketDto> CreateOrUpdatepayforeExistorder(CustomerBasketDto basket);
        public Task<CustomerBasketDto> CreateOrUpdatepayforeNeworder(string basketid);

        public Task<OrderResultDto> UpdatePayStatusesFaild(string paymentintentId);
        public Task<OrderResultDto> UpdatePayStatusesSucsed(string paymentintentId);
    }
}
