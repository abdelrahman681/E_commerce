using E_Commerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.DataTransfareObject_DTO_
{
    public class ProductToReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public string BrandName { get; set; }

        public string TypeName { get; set; }

    }
}
