using E_Commerce.Domain.DataTransfareObject_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces.Services
{
    public interface IBasketServices
    {
        Task<CustomerBasketDto?> GetBasketAsync(string id);
        Task<CustomerBasketDto?> UpdateBasketAsync(CustomerBasketDto basket);
        Task<bool> DeletBasketAsync(string id);
    }
}
