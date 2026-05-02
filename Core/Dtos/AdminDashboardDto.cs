namespace Core.Dtos;

public class AdminDashboardDto
{
    public required DashboardSummaryDto Summary { get; set; }
    public required IReadOnlyList<RevenueByDayDto> RevenueByDay { get; set; }
    public required IReadOnlyList<NameValueDto> OrdersByStatus { get; set; }
    public required IReadOnlyList<NameValueDto> OrdersBySource { get; set; }
    public required IReadOnlyList<RecentOrderDto> RecentOrders { get; set; }
    public required IReadOnlyList<TopProductDto> TopProducts { get; set; }
    public required IReadOnlyList<LowStockProductDto> LowStockProducts { get; set; }
}

public class DashboardSummaryDto
{
    public decimal TotalRevenue { get; set; }
    public decimal TodayRevenue { get; set; }
    public int TotalOrders { get; set; }
    public int PendingOrders { get; set; }
    public int WebOrders { get; set; }
    public int PosOrders { get; set; }
    public int TotalProducts { get; set; }
    public int LowStockItems { get; set; }
    public int TotalUsers { get; set; }
}

public class RevenueByDayDto
{
    public DateTime Date { get; set; }
    public decimal Revenue { get; set; }
    public int Orders { get; set; }
}

public class NameValueDto
{
    public required string Name { get; set; }
    public int Value { get; set; }
}

public class RecentOrderDto
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public required string BuyerEmail { get; set; }
    public required string CustomerName { get; set; }
    public required string Status { get; set; }
    public required string Source { get; set; }
    public required string PaymentMethod { get; set; }
    public int ItemsCount { get; set; }
    public decimal Total { get; set; }
}

public class TopProductDto
{
    public Guid ProductId { get; set; }
    public Guid ProductVariantId { get; set; }
    public required string ProductName { get; set; }
    public required string VariantName { get; set; }
    public int QuantitySold { get; set; }
    public decimal Revenue { get; set; }
}

public class LowStockProductDto
{
    public Guid ProductId { get; set; }
    public Guid ProductVariantId { get; set; }
    public required string ProductName { get; set; }
    public required string Sku { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
