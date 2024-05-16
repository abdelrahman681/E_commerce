using E_Commerce.Domain.Entity.OrderEntity;

namespace E_Commerce.Domain.DataTransfareObject_DTO_
{
    public class OrderItemDto
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string PictureUrl { get; set; }

    }
}