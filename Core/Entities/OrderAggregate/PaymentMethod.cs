using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    public enum PaymentMethod
    {
        aba, // 0 Aba Payway
        cod, // 1 Cash on Delivery
        stripe, // 2 Stripe
        khqr // 3 KHQR
    }
}
