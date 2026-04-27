namespace Core.Entities;

public class PaymentResult
{
    public string PaymentIntentId { get; set; } = string.Empty;
    public object? PaymentResponse { get; set; }
}
