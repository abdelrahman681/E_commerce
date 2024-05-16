using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entity
{
    public class Products :BaseEntity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
        [Column(TypeName ="money")]
        public decimal Price { get; set; }

        public int TypeId { get; set; }

        public int BrandId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public ProductType ProductType { get; set; }
    }
}
