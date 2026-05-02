using Core.Entities.OrderAggregate;

namespace Core.Interface;

public interface IInvoicePdfService
{
    byte[] GenerateOrderInvoice(Order order, string? logoPath = null);
}
