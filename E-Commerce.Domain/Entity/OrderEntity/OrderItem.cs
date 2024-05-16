namespace E_Commerce.Domain.Entity.OrderEntity
{
    public class OrderItem :BaseEntity<Guid>
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public productItemOrder productItemOrder { get; set; }

    }
}