using E_Commerce.Domain.Entity.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.Specification
{
    public class OrderWithPaymentIntentSpec : BaseSpecification<Order>
    {
        public OrderWithPaymentIntentSpec(string paymentintenid) :
            base(order=>order.PaymentIntentId== paymentintenid)
        {
            IncludeExpression.Add(i => i.DeliveryMethod);
        }
    }
}
