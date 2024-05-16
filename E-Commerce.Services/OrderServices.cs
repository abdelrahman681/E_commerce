using AutoMapper;
using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Entity.OrderEntity;
using E_Commerce.Domain.Interfaces.Repositry;
using E_Commerce.Domain.Interfaces.Services;
using E_Commerce.Repositry.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class OrderServices : IOrderService
    {
        private readonly IBasketServices _basket;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly IPayService _pay;

        public OrderServices(IBasketServices basket, IMapper mapper, IUnitOfWork unit, IPayService pay)
        {
            _basket = basket;
            _mapper = mapper;
            _unit = unit;
            _pay = pay;
        }
        public async Task<OrderResultDto> CreateOrderAsync(OrderDto orderDto)
        {
            var basket=await _basket.GetBasketAsync(orderDto.BasketId);
            if (basket == null) throw new Exception($"No Basket With id {orderDto.BasketId} in DataBase");
            var orderItmes= new List<OrderItem>();
            foreach (var item in basket.BasketItems)
            {
                var productitem = new productItemOrder
                {
                    PictureUrl = item.PictureUrl,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                };
                var orderitem = new OrderItem
                {
                    Price= item.Price,
                    Quantity= item.Quantity,
                    productItemOrder=productitem
                };
                orderItmes.Add(orderitem);
       
            }
            if (!orderItmes.Any())
                throw new Exception("No Basket Item Found");
            if(!orderDto.DeliveryMethodId.HasValue)
                throw new Exception("No Delivery Method Selected");
            var deilvery = await _unit.Reposity<DeliveryMethod, int>().GetByIdAsync(orderDto.DeliveryMethodId!.Value);
            if (deilvery == null)
                throw new Exception("InValid Delivery Method Id");
            var shippingAddres = _mapper.Map<ShippingAddress>(orderDto.ShippingAddress);
            var spec = new OrderWithPaymentIntentSpec(basket.PaymentIntentId!);
            var existorder = await _unit.Reposity<Order, Guid>().GetByIdwithspecificationAsync(spec);
            if(existorder == null)
            {
                 _unit.Reposity<Order, Guid>().Delete(existorder);
                await _pay.CreateOrUpdatepayforeExistorder(basket);
            }
            else
            {
                basket = await _pay.CreateOrUpdatepayforeExistorder(basket);
            }
            var subtotal= orderItmes.Sum(i=>i.Price*i.Quantity);
            var mappeditem = _mapper.Map<List<OrderItem>>(orderItmes);
            var order = new Order
            {
                BuyerEmail = orderDto.BuyerEmail,
                ShippingAddress = shippingAddres,
                SubPrice = subtotal,
                OrderItems = mappeditem,
                PaymentIntentId = basket.PaymentIntentId,
                BasketId = basket.Id
            };
            await _unit.Reposity<Order,Guid>().AddAsync(order);
            await _unit.CompleteAsync();
            return _mapper.Map<OrderResultDto>(order);
        }

        public async Task<IEnumerable<OrderResultDto>> GetAllOrderAsync(string Emaill)
        {
            var spec=new OrderSpec(Emaill);
            var order = await _unit.Reposity<Order, Guid>().GetAllwithspecififcationAsync(spec);
            if (!order.Any()) throw new Exception("No order yet for user");
            return _mapper.Map<IEnumerable<OrderResultDto>>(order);
        }

        public async Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync()=>await _unit.Reposity<DeliveryMethod,int>().GetAllAsync();
        

        public async Task<OrderResultDto> GetOrderAsync(Guid Id, string Emaill)
        {
            var spec = new OrderSpec(Id,Emaill);
            var order = await _unit.Reposity<Order, Guid>().GetByIdwithspecificationAsync(spec);
            if (order is null) throw new Exception("No order yet for user");
            return _mapper.Map<OrderResultDto>(order);
        }
    }
}
