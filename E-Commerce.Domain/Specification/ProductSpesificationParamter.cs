using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Specification
{
    public class ProductSpesificationParamter
    {
        private const int MaxPageSize = 10;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public SpecificationOrder? Sorted { get; set; }

        public int IndexPage { get; set; } = 1;

        private int pagesize=10;

        public int PageSize
        {
            get { return pagesize; }
            set { pagesize = value>MaxPageSize?MaxPageSize:value; }
        }

        private string? searchvalue;

        public string? SearchValue
        {
            get => searchvalue;
            set => searchvalue = (value?.Trim().ToLower())!;
        }


    }
}
