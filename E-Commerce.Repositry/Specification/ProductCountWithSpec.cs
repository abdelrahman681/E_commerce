using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.Specification
{
    public class ProductCountWithSpec : BaseSpecification<Products>
    {
        public ProductCountWithSpec(ProductSpesificationParamter paramter) : base(pro =>
        (!paramter.TypeId.HasValue || pro.TypeId == paramter.TypeId.Value) &&
         (!paramter.BrandId.HasValue || pro.BrandId == paramter.BrandId.Value)
          && (string.IsNullOrWhiteSpace(paramter.SearchValue) || pro.Name.ToLower().Contains(paramter.SearchValue.ToLower())))
        {
        }
    }
}
