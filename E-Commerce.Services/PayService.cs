using AutoMapper;
using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Entity.OrderEntity;
using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Interfaces.Repositry;
using E_Commerce.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Repositry.Specification;

namespace E_Commerce.Services
{
    public class PayService : IPayService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketServices _basket;
        private readonly IMapper _maper;
        private readonly IConfiguration _configuration;

        public PayService(IUnitOfWork unitOfWork, IBasketServices basket, IMapper maper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _basket = basket;
            _maper = maper;
            _configuration = configuration;
        }
        public async Task<CustomerBasketDto> CreateOrUpdatepayforeExistorder(CustomerBasketDto basket)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:Key"];
            foreach (var item in basket.BasketItems)
            {
                var product = await _unitOfWork.Reposity<Products, int>().GetByIdAsync(item.ProductId);
                if (product.Price != item.Price)
                    item.Price = product.Price;
            }
            var total = basket.BasketItems.Sum(item => item.Quantity * item.Price);
            if (!basket.DeliveryMethodId.HasValue) throw new Exception("No Dlivery mEthod Selected");
            var dilvery = await _unitOfWork.Reposity<DeliveryMethod, int>().GetByIdAsync(basket.DeliveryMethodId.Value);
            var shippingprice = dilvery.Price;
            basket.ShippingPrice = dilvery.Price;
            long amount = (long)((total * 100) + (shippingprice * 100));
            var service = new PaymentIntentService();
            PaymentIntent paymentIntent;
            if (string.IsNullOrWhiteSpace(basket.PaymentIntentId))
            {
                var option = new PaymentIntentCreateOptions()
                {
                    Amount = amount,
                    Currency = "USD",
                    PaymentMethodTypes = new List<string> { "Card" }
                };
                paymentIntent = await service.CreateAsync(option);
                basket.PaymentIntentId = paymentIntent.Id;
                basket.ClintSecret = paymentIntent.ClientSecret;
            }
            else
            {
                var option = new PaymentIntentUpdateOptions()
                {
                    Amount = amount,

                };
                await service.UpdateAsync(basket.PaymentIntentId, option);
            }
            await _basket.UpdateBasketAsync(basket);
            return basket;
        }

        public async Task<CustomerBasketDto> CreateOrUpdatepayforeNeworder(string basketid)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:Key"];
            var basket = await _basket.GetBasketAsync(basketid);
            foreach (var item in basket.BasketItems)
            {
                var product = await _unitOfWork.Reposity<Products, int>().GetByIdAsync(item.ProductId);
                if (product.Price != item.Price)
                    item.Price = product.Price;
            }
            var total = basket.BasketItems.Sum(item => item.Quantity * item.Price);
            if (!basket.DeliveryMethodId.HasValue) throw new Exception("No Dlivery mEthod Selected");
            var dilvery = await _unitOfWork.Reposity<DeliveryMethod, int>().GetByIdAsync(basket.DeliveryMethodId.Value);
            var shippingprice = dilvery.Price;
            basket.ShippingPrice = dilvery.Price;
            long amount = (long)((total * 100) + (shippingprice * 100));
            var service = new PaymentIntentService();
            PaymentIntent paymentIntent;
            if (string.IsNullOrWhiteSpace(basket.PaymentIntentId))
            {
                var option = new PaymentIntentCreateOptions()
                {
                    Amount = amount,
                    Currency = "USD",
                    PaymentMethodTypes = new List<string> { "Card" }
                };
                paymentIntent = await service.CreateAsync(option);
                basket.PaymentIntentId = paymentIntent.Id;
                basket.ClintSecret = paymentIntent.ClientSecret;
            }
            else
            {
                var option = new PaymentIntentUpdateOptions()
                {
                    Amount = amount,

                };
                await service.UpdateAsync(basket.PaymentIntentId, option);
            }
            await _basket.UpdateBasketAsync(basket);
            return basket;
        }

        public async Task<OrderResultDto> UpdatePayStatusesFaild(string paymentintentId)
        {
            var spec = new OrderWithPaymentIntentSpec(paymentintentId);
            var order=await _unitOfWork.Reposity<Order,Guid>().GetByIdwithspecificationAsync(spec);
            if (order is null) throw new Exception($"No Order With value {paymentintentId}");
            order.PayMentStatus = PayMentStatus.Filed;
            _unitOfWork.Reposity<Order, Guid>().Update(order);
            await _unitOfWork.CompleteAsync();
            return _maper.Map<OrderResultDto>(order);
        }

        public async Task<OrderResultDto> UpdatePayStatusesSucsed(string paymentintentId)
        {
            var spec = new OrderWithPaymentIntentSpec(paymentintentId);
            var order = await _unitOfWork.Reposity<Order, Guid>().GetByIdwithspecificationAsync(spec);
            if (order is null) throw new Exception($"No Order With value {paymentintentId}");
            order.PayMentStatus = PayMentStatus.Receved;
            _unitOfWork.Reposity<Order, Guid>().Update(order);
            await _unitOfWork.CompleteAsync();
            await _basket.DeletBasketAsync(order.BasketId!);
            return _maper.Map<OrderResultDto>(order);
        }
    }
}
