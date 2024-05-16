using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Interfaces;
using E_Commerce.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.Specification
{
    public class ProudectSpecification : BaseSpecification<Products>

    {
        public ProudectSpecification(ProductSpesificationParamter paramter) : base(pro =>
        (!paramter.TypeId.HasValue || pro.TypeId == paramter.TypeId.Value) &&
         (!paramter.BrandId.HasValue || pro.BrandId == paramter.BrandId.Value)
        && (string.IsNullOrWhiteSpace(paramter.SearchValue) || pro.Name.ToLower().Contains(paramter.SearchValue.ToLower())))
        
        {
            IncludeExpression.Add(p => p.ProductBrand);
            IncludeExpression.Add(p => p.ProductType);

            if (paramter.Sorted is not null)
            {
                switch (paramter.Sorted)
                {
                    case SpecificationOrder.NameAsc:
                        OrderBy = x => x.Name;
                        break;
                    case SpecificationOrder.NameDesc:
                        OrderByDesc = x => x.Name;
                        break;
                    case SpecificationOrder.PriceAsc:
                        OrderBy = x => x.Price;
                        break;
                    case SpecificationOrder.PriceDecs:
                        OrderByDesc = x => x.Price;
                        break;
                    default :OrderBy= x => x.Name;
                        break;
                }
            }
            else
            {
                OrderBy = x => x.Name;
            }

            ApplayPagination(paramter.IndexPage, paramter.PageSize);
        }

        public ProudectSpecification(int id) : base(p => p.Id == id)
        {
            IncludeExpression.Add(p => p.ProductBrand);
            IncludeExpression.Add(p => p.ProductType);
        }
    }
}
