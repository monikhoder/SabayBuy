namespace POS.Dtos
{
    public class POSOrderCheckoutResponseDto
    {
        public POSOrderDto Order { get; set; }
        public object Payment { get; set; }
        public bool HasOnlinePayment { get; set; }
    }
}
