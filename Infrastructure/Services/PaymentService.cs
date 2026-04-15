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
        IConfiguration config,
        ICartService cartService,
        IUnitOfWork unit
    ) : IPaymentService
    {

    public async Task<ShoppingCart?> GetTotalPrice(string cartId, string shippingId )
            {
                // Get the shopping cart
               var cart = await cartService.GetCardAsync(cartId);
               if (cart == null) return null;

               //Get shipping price
               var shippingMethod = await unit.Repository<DeliveryMethod>().GetByIdAsync(Guid.Parse(shippingId));
               decimal shippingPrice = shippingMethod != null ? shippingMethod.Price : 0;

        //check the price of cart and update if needed
        foreach (var item in cart.Items)
                {
                    var id = Guid.Parse(item.ProductVariantId);
                    var productVariant = await unit.Repository<ProductVariant>().GetByIdAsync(id);
                    if (productVariant == null) return null;
                    if(item.Price != productVariant.Price)
                    {
                        item.Price = productVariant.Price;
                    }
                }

                //Calculate total price ans add shipping price
                cart.TotalPrice = (cart.Items.Sum(x => x.Quantity * x.Price) + shippingPrice);
                //Update the cart with the new total price
                cart = await cartService.SetCardAsync(cart);
                return cart;
            }

    public async Task<object?> ProcessPaymentAsync(ShoppingCart cart, string paymentMethod, AppUser user)
    {
        decimal totalPrice = cart.TotalPrice ?? 0;
        Console.WriteLine($"Total price to be paid: {totalPrice}");
        switch (paymentMethod.ToLower())
        {
            case "aba":
                return await ProcessAbaPayment(totalPrice, cart.Id, user);

            case "stripe":
               // return await ProcessStripePayment(totalPrice, cart.Id);

            case "cod":
                return ProcessCashOnDelivery(totalPrice, cart.Id);

            default:
                throw new Exception("Payment method not supported");
        }
    }
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

    private async Task<object?> ProcessAbaPayment(decimal price, string cartId, AppUser user)
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
        return jsonDocument.RootElement;
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
