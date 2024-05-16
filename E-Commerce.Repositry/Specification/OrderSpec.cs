using E_Commerce.Domain.Entity.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.Specification
{
    public class OrderSpec : BaseSpecification<Order>
    {
        public OrderSpec(string email) : base(o=>o.BuyerEmail==email)
        {
            IncludeExpression.Add(o => o.DeliveryMethod);
            IncludeExpression.Add(o => o.OrderItems);

            OrderByDesc=o=>o.OrderDate;
        }

        public OrderSpec(Guid Id,string email) : base(o => o.BuyerEmail == email && o.Id==Id)
        {
            IncludeExpression.Add(o => o.DeliveryMethod);
            IncludeExpression.Add(o => o.OrderItems);

        }
    }
}
