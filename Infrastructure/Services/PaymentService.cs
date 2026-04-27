using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Services;

public class PaymentService(
        IConfiguration config
    ) : IPaymentService
    {
    public async Task<string> VerifyAbaPaymentAsync(string tranId)
    {
        var merchantId = config["AbaPayWay:MerchantId"];
        var apiKey = config["AbaPayWay:ApiKey"];
        var checkApiUrl = config["AbaPayWay:ApiUrl"] + "payment-gateway/v1/payments/check-transaction-2";
        var reqTime = DateTime.Now.ToString("yyyyMMddHHmmss");

        string hashString = reqTime + merchantId + tranId;
        string hash = GetHmacSha512(hashString, apiKey);

        using var client = new HttpClient();
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(reqTime), "req_time");
        formData.Add(new StringContent(merchantId), "merchant_id");
        formData.Add(new StringContent(tranId), "tran_id");
        formData.Add(new StringContent(hash), "hash");

        var response = await client.PostAsync(checkApiUrl, formData);
       
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<PaymentResult?> CreatePaymentForOrderAsync(PaymentMethod paymentMethod, decimal total, AppUser user, Guid orderId)
    {
        return paymentMethod switch
        {
            PaymentMethod.aba => await ProcessAbaPayment(total, user),
            PaymentMethod.stripe => throw new NotSupportedException("Stripe payment is not implemented yet"),
            PaymentMethod.khqr => throw new NotSupportedException("KHQR payment is not implemented yet"),
            PaymentMethod.cod => new PaymentResult
            {
                PaymentResponse = ProcessCashOnDelivery(total, orderId.ToString())
            },
            _ => throw new NotSupportedException("Payment method not supported")
        };
    }

    private async Task<PaymentResult?> ProcessAbaPayment(decimal price, AppUser user)
    {
        var merchantId = config["AbaPayWay:MerchantId"];
        var apiKey = config["AbaPayWay:ApiKey"];
        var apiUrl = config["AbaPayWay:ApiUrl"] + "payment-gateway/v1/payments/purchase";
        var reqTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        var tranId = Guid.NewGuid().ToString("N").Substring(0, 20);
        var amountStr = price.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);

        var firstName = user.FirstName ?? "Customer";
        var lastName = user.LastName ?? "Customer";
        var phone = user.PhoneNumber ?? "012345678";
        var email = user.Email ?? "";
        var returnUrl = config["AbaPayWay:ReturnUrl"];
        var type = "purchase";
        var currency = "USD";
        var payment_option = "cards";

        string hashString = reqTime + merchantId + tranId + amountStr + firstName + lastName + email + phone + type + payment_option + returnUrl + currency;
        Console.WriteLine($"HashString : {hashString}");
        string hash = GetHmacSha512(hashString, apiKey);

        Console.WriteLine($"Hash : {hash}");


        using var client = new HttpClient();
        var formData = new MultipartFormDataContent();

        formData.Add(new StringContent(hash), "hash");
        formData.Add(new StringContent(tranId), "tran_id");
        formData.Add(new StringContent(amountStr), "amount");
        formData.Add(new StringContent(firstName), "firstname");
        formData.Add(new StringContent(lastName), "lastname");
        formData.Add(new StringContent(phone), "phone");
        formData.Add(new StringContent(email), "email");
        formData.Add(new StringContent(reqTime), "req_time");
        formData.Add(new StringContent(merchantId), "merchant_id");
        formData.Add(new StringContent(returnUrl), "return_url");
        formData.Add(new StringContent(type), "type");
        formData.Add(new StringContent(payment_option), "payment_option");
        formData.Add(new StringContent(currency), "currency");

        var response = await client.PostAsync(apiUrl, formData);
        var responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"ABA Response: {responseString}");
        var jsonDocument = JsonDocument.Parse(responseString);
        return new PaymentResult
        {
            PaymentIntentId = tranId,
            PaymentResponse = jsonDocument.RootElement.Clone()
        };
    }


    private object ProcessCashOnDelivery(decimal price, string cartId)
    {
        return new { status = "success", message = "Order placed successfully with Cash on Delivery" };
    }

    private string GetHmacSha512(string message, string key)
            {
                var keyBytes = Encoding.UTF8.GetBytes(key);
                var messageBytes = Encoding.UTF8.GetBytes(message);

                using (var hmac = new HMACSHA512(keyBytes))
                {
                    var hashBytes = hmac.ComputeHash(messageBytes);
                    return Convert.ToBase64String(hashBytes);
                }
            }
   
}
