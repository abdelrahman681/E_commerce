using E_Commerce.Domain.Entity.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.DataTransfareObject_DTO_
{
    public class CustomerBasketDto
    {
        public string Id { get; set; }
        public decimal ShippingPrice { get; set; }
        public int? DeliveryMethodId { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        public string? PaymentIntentId { get; set; }
        public string? ClintSecret { get; set; }
    }
}
