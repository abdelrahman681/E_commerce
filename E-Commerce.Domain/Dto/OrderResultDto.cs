using E_Commerce.Domain.Entity.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.DataTransfareObject_DTO_
{
    public class OrderResultDto
    {
        public Guid Id { get; set; }
        public string? BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public string DeliveryMethod { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
        public PayMentStatus PayMentStatus { get; set; } = PayMentStatus.pending;
        public decimal SubPrice { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? BasketId { get; set; }

    }
}
