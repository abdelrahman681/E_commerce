using AutoMapper;
using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Entity.NewFolder;
using E_Commerce.Domain.Interfaces.Repositry;
using E_Commerce.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class BasketServices : IBasketServices
    {
        private readonly IBasketItemRepositpry _repositpry;
        private readonly IMapper _mapped;

        public BasketServices(IBasketItemRepositpry repositpry, IMapper mapped)
        {
            _repositpry = repositpry;
            _mapped = mapped;
        }
        public async Task<bool> DeletBasketAsync(string id) =>await _repositpry.DeleteCustomerBasketAsync(id);
        

        public async Task<CustomerBasketDto?> GetBasketAsync(string id)
        {
            var basket = await _repositpry.GetCustomerBasketAsync(id);

            var mappedbasket = _mapped.Map<CustomerBasketDto?>(basket);
            return basket is not null? mappedbasket : null;
        }

        public async Task<CustomerBasketDto?> UpdateBasketAsync(CustomerBasketDto basket)
        {
            var mappedbasket = _mapped.Map<CustomerBasket?>(basket);

            var updatebasket = await _repositpry.UpdateCustomerBasketAsync(mappedbasket);

            return updatebasket is not null? _mapped.Map<CustomerBasketDto?>(updatebasket) : null;
        }
    }
}
