namespace E_Commerce.Domain.Entity.OrderEntity
{
    public class ShippingAddress
    {
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}