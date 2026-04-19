using Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class OrderSpecification : BaseSpecification<Order>
    {
        //Get My Order
        public OrderSpecification(string email, OrderSpecParams specParams)
            : base(x => x.BuyerEmail == email && (string.IsNullOrEmpty(specParams.Status) || x.Status == ParseStatus(specParams.Status)))
        {
            AddInclude(x => x.DeliveryMethod);
            AddInclude(x => x.OrderItems);
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "dateAsc":
                        AddOrderBy(x => x.OrderDate);
                        break;
                    case "dateDesc":
                        AddOrderByDescending(x => x.OrderDate);
                        break;
                    case "totalAsc":
                        AddOrderBy(x => x.Subtotal);
                        break;
                    case "totalDesc":
                        AddOrderByDescending(x => x.Subtotal);
                        break;
                    default:
                        AddOrderByDescending(x => x.OrderDate);
                        break;
                }
            }
            else
            {
                AddOrderByDescending(x => x.OrderDate);
            }
        }
        //Get all orders (Admin / sale)
        public OrderSpecification(OrderSpecParams specParams)
            : base(x =>  (string.IsNullOrEmpty(specParams.Status) || x.Status == ParseStatus(specParams.Status)) &&
                (string.IsNullOrEmpty(specParams.Search) || x.Id.ToString().ToLower().Contains(specParams.Search.ToLower()))
            )
        {
            AddInclude(x => x.DeliveryMethod);
            AddInclude(x => x.OrderItems);
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "dateAsc":
                        AddOrderBy(x => x.OrderDate);
                        break;
                    case "dateDesc":
                        AddOrderByDescending(x => x.OrderDate);
                        break;
                    case "totalAsc":
                        AddOrderBy(x => x.Subtotal);
                        break;
                    case "totalDesc":
                        AddOrderByDescending(x => x.Subtotal);
                        break;
                    default:
                        AddOrderByDescending(x => x.OrderDate);
                        break;
                }
            }
            else
            {
                AddOrderByDescending(x => x.OrderDate);
            }
        }
        //Get my  order by ID
        public OrderSpecification(Guid id, string email) : base(x => x.Id == id && x.BuyerEmail == email)
        {
            AddInclude("OrderItems");
            AddInclude("DeliveryMethod");
        }
        //get order by ID (admin / Sale)
        public OrderSpecification(Guid id) : base(x => x.Id == id)
        {
            AddInclude("OrderItems");
            AddInclude("DeliveryMethod");
        }

        private static OrderStatus? ParseStatus(string status)
        {
            if (Enum.TryParse<OrderStatus>(status, true, out var result))
            {
                return result;
            }
            return null;
        }
    }
}
