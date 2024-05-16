using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entity.OrderEntity
{
    public class Order :BaseEntity<Guid>
    {
        public string? BuyerEmail{ get; set; }
        public DateTime OrderDate{ get; set; } = DateTime.Now;
        public ShippingAddress ShippingAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public int? DeliveryMethodId { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public PayMentStatus PayMentStatus { get; set; } = PayMentStatus.pending;
        public decimal SubPrice { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? BasketId { get; set; }
        public decimal TotalPrice => SubPrice +DeliveryMethod.Price;


    }
}
