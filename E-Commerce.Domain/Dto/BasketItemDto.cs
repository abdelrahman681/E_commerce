using E_Commerce.Domain.Entity.Basket;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.DataTransfareObject_DTO_
{
    public class BasketItemDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1,50)]
        public int Quantity { get; set; }
        [Required]

        public string ProductName { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public string PictureUrl { get; set; }
        [Required]

        public string TypeName { get; set; }
        [Required]

        public string BrandName { get; set; }
        [Required]
        
        public decimal Price { get; set; }

    }
}
