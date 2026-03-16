using Core.Entities;
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
        IGenericRepository<Product> productRepo,
        IGenericRepository<ProductVariant> productVariantRepo,
        IGenericRepository<DeliveryMethod> deliveryMethodRepo
    ) : IPaymentService
    {

    public async Task<ShoppingCard?> GetTotalPrice(string basketId)
            {
                // Get the shopping cart
               var cart = await cartService.GetCardAsync(basketId);
               if (cart == null) return null;

               //Get shipping price
               var shippingPrice = 0m;
                if (!string.IsNullOrEmpty(cart.DeliveryMethodId))
                {
                     var id = Guid.Parse(cart.DeliveryMethodId);
                     var deliveryMethod = await deliveryMethodRepo.GetByIdAsync(id);
                     if(deliveryMethod == null) return null;
                     if(deliveryMethod.Price > 0) shippingPrice = deliveryMethod.Price;
                }
                //check the price of cart and update if needed
                foreach (var item in cart.Items)
                {
                    var id = Guid.Parse(item.ProductVariantId);
                    var productVariant = await productVariantRepo.GetByIdAsync(id);
                    if (productVariant == null) return null;
                    if(item.Price != productVariant.Price)
                    {
                        item.Price = productVariant.Price;
                    }
                }
                //Calculate total price ans add shipping price
                cart.TotalPrice = (cart.Items.Sum(x => x.Quantity * x.Price) + shippingPrice);
                return cart;
            }

    public async Task<object?> ProcessPaymentAsync(ShoppingCard cart, string paymentMethod)
    {
        decimal totalPrice = cart.TotalPrice ?? 0;
        switch (paymentMethod.ToLower())
        {
            case "aba":
                return await ProcessAbaPayment(totalPrice, cart.Id);

            case "stripe":
               // return await ProcessStripePayment(totalPrice, cart.Id);

            case "cash":
                return ProcessCashOnDelivery(totalPrice, cart.Id);

            default:
                throw new Exception("Payment method not supported");
        }
    }

    private async Task<object?> ProcessAbaPayment(decimal price, string cartId)
    {
        var merchantId = config["AbaPayWay:MerchantId"];
        var apiKey = config["AbaPayWay:ApiKey"];
        var apiUrl = config["AbaPayWay:ApiUrl"];
        var reqTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        var tranId = Guid.NewGuid().ToString("N").Substring(0, 20);
        var amountStr = price.ToString("0.00");

        var firstName = "Sabay";
        var lastName = "Customer";
        var phone = "012345678";
        var email = "customer@sabaybuy.com";
        var returnUrl = config["AbaPayWay:ReturnUrl"];
        var type = "purchase";
        var currency = "USD";

        string hashString = reqTime + merchantId + tranId + amountStr + firstName + lastName + email + phone + type + returnUrl + currency;
        string hash = GetHmacSha512(hashString, apiKey);

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
        formData.Add(new StringContent(currency), "currency");

        var response = await client.PostAsync(apiUrl, formData);
        var responseString = await response.Content.ReadAsStringAsync();

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
