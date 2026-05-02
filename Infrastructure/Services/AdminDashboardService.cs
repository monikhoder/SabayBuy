using Core.Dtos;
using Core.Entities.OrderAggregate;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AdminDashboardService(StoreContext context) : IAdminDashboardService
{
    private static readonly OrderStatus[] RevenueStatuses =
    [
        OrderStatus.PaymentReceived,
        OrderStatus.OrderConfirm,
        OrderStatus.Shipped,
        OrderStatus.Delivered,
        OrderStatus.ReceivedOrder,
        OrderStatus.Completed
    ];

    public async Task<AdminDashboardDto> GetDashboardAsync()
    {
        var today = DateTime.UtcNow.Date;
        var revenueStartDate = today.AddDays(-6);
        const int lowStockThreshold = 10;

        var allOrders = await context.Orders
            .AsNoTracking()
            .Include(x => x.DeliveryMethod)
            .Include(x => x.OrderItems)
            .ToListAsync();

        var revenueOrders = allOrders
            .Where(order => RevenueStatuses.Contains(order.Status))
            .ToList();

        var summary = new DashboardSummaryDto
        {
            TotalRevenue = revenueOrders.Sum(GetOrderTotal),
            TodayRevenue = revenueOrders
                .Where(order => order.OrderDate.Date == today)
                .Sum(GetOrderTotal),
            TotalOrders = allOrders.Count,
            PendingOrders = allOrders.Count(order => order.Status == OrderStatus.Pending),
            WebOrders = allOrders.Count(order => order.Source == OrderSource.Web),
            PosOrders = allOrders.Count(order => order.Source == OrderSource.POS),
            TotalProducts = await context.Products.AsNoTracking().CountAsync(),
            LowStockItems = await context.ProductVariants.AsNoTracking().CountAsync(variant => variant.StockQuantity <= lowStockThreshold),
            TotalUsers = await context.Users.AsNoTracking().CountAsync()
        };

        var revenueByDay = Enumerable.Range(0, 7)
            .Select(index => revenueStartDate.AddDays(index))
            .Select(date =>
            {
                var ordersForDate = revenueOrders
                    .Where(order => order.OrderDate.Date == date)
                    .ToList();

                return new RevenueByDayDto
                {
                    Date = date,
                    Revenue = ordersForDate.Sum(GetOrderTotal),
                    Orders = ordersForDate.Count
                };
            })
            .ToList();

        var ordersByStatus = Enum.GetValues<OrderStatus>()
            .Select(status => new NameValueDto
            {
                Name = status.ToString(),
                Value = allOrders.Count(order => order.Status == status)
            })
            .Where(item => item.Value > 0)
            .ToList();

        var ordersBySource = Enum.GetValues<OrderSource>()
            .Select(source => new NameValueDto
            {
                Name = source.ToString(),
                Value = allOrders.Count(order => order.Source == source)
            })
            .ToList();

        var recentOrders = allOrders
            .OrderByDescending(order => order.OrderDate)
            .Take(8)
            .Select(order => new RecentOrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                BuyerEmail = order.BuyerEmail,
                CustomerName = order.ShippingAddress.FullName,
                Status = order.Status.ToString(),
                Source = order.Source.ToString(),
                PaymentMethod = order.PaymentMethod.ToString(),
                ItemsCount = order.OrderItems.Sum(item => item.Quantity),
                Total = GetOrderTotal(order)
            })
            .ToList();

        var topProducts = revenueOrders
            .SelectMany(order => order.OrderItems)
            .GroupBy(item => new
            {
                item.ItemOrdered.ProductId,
                item.ItemOrdered.ProductVariantId,
                item.ItemOrdered.ProductName,
                item.ItemOrdered.VariantName
            })
            .Select(group => new TopProductDto
            {
                ProductId = group.Key.ProductId,
                ProductVariantId = group.Key.ProductVariantId,
                ProductName = group.Key.ProductName,
                VariantName = group.Key.VariantName,
                QuantitySold = group.Sum(item => item.Quantity),
                Revenue = group.Sum(item => item.Price * item.Quantity)
            })
            .OrderByDescending(item => item.QuantitySold)
            .Take(8)
            .ToList();

        var lowStockProducts = await context.ProductVariants
            .AsNoTracking()
            .Include(variant => variant.Product)
            .Where(variant => variant.StockQuantity <= lowStockThreshold)
            .OrderBy(variant => variant.StockQuantity)
            .Take(8)
            .Select(variant => new LowStockProductDto
            {
                ProductId = variant.ProductId,
                ProductVariantId = variant.Id,
                ProductName = variant.Product != null ? variant.Product.ProductName : string.Empty,
                Sku = variant.Sku,
                Price = variant.Price,
                StockQuantity = variant.StockQuantity
            })
            .ToListAsync();

        return new AdminDashboardDto
        {
            Summary = summary,
            RevenueByDay = revenueByDay,
            OrdersByStatus = ordersByStatus,
            OrdersBySource = ordersBySource,
            RecentOrders = recentOrders,
            TopProducts = topProducts,
            LowStockProducts = lowStockProducts
        };
    }

    private static decimal GetOrderTotal(Order order)
    {
        return order.Subtotal + (order.DeliveryMethod?.Price ?? 0);
    }
}
