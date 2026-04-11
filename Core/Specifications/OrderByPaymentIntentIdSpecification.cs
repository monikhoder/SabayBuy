using Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class OrderByPaymentIntentIdSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdSpecification(string paymentIntentId)
            : base(x => x.PaymentIntentId == paymentIntentId)
        {
            AddInclude(x => x.DeliveryMethod);

            // AddInclude(x => x.OrderItems);
        }

    }
}
