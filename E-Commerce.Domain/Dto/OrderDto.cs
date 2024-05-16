using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.DataTransfareObject_DTO_
{
    public class OrderDto
    {
        public  string BuyerEmail { get; set; }
        public  string BasketId { get; set; }
        public int? DeliveryMethodId { get; set; }
        public AddressDto ShippingAddress { get; set; }

    }
}
