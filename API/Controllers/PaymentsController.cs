using Api.Helpers;
using API.Dtos;
using API.Helpers;
using API.SignalR;
using AutoMapper;
using Azure;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;

namespace API.Controllers;

public class PaymentsController(
        IPaymentService paymentService,
        IUnitOfWork unit,
        IHubContext<NotificationHub> hubContext,
        IMapper mapper,
        UserManager<AppUser> userManager
) : BaseApiController
{
    [Authorize]
    [HttpPost("checkout")]
    public async Task<ActionResult<object?>> Checkout([FromBody] CheckoutDto checkoutDto)
    {

        var user = await userManager.GetUserByEmail(User);

        var cart = await paymentService.GetTotalPrice(checkoutDto.CartId, checkoutDto.DeliveryMethodId);
        if (cart == null) return BadRequest("Problem with your cart");

        var response = await paymentService.ProcessPaymentAsync(cart, checkoutDto.PaymentMethod, user);
        return response;
    }
    
    [HttpPost("webhook/aba")]
    public async Task<IActionResult> AbaWebhook([FromQuery] string tran_id)
    {
        if (string.IsNullOrEmpty(tran_id))
        {
            return BadRequest("Invalid transaction ID");
        }

        var jsonString = await paymentService.VerifyAbaPaymentAsync(tran_id);
        Console.WriteLine($"check trx respone {jsonString}");
        if (string.IsNullOrEmpty(jsonString))
        {
            return BadRequest("No response from ABA");
        }

        try
        {
            var responseObj = AbaPaymentResponse.FromJson(jsonString);
            //set payment approved for testes only 
            responseObj.AbaData.PaymentStatusCode = 0;
            responseObj.AbaData.PaymentStatus = "Approved";
            if (responseObj != null &&
                responseObj.AbaData?.PaymentStatusCode == 0)
            {
                // Get the amount from ABA response
                decimal abaAmount = responseObj.AbaData?.TotalAmount ?? 0;

                //Get Order
                var spec = new OrderByPaymentIntentIdSpecification(tran_id);
                var order = await unit.Repository<Order>().GetEntityWithSpec(spec);

                if (order == null) return NotFound("Order not found");

                decimal orderTotal = order.Subtotal + (order.DeliveryMethod?.Price ?? 0);

                order.Status = OrderStatus.PaymentReceived;
                unit.Repository<Order>().Update(order);
                await unit.Complete();

                string buyerEmail = order.BuyerEmail;

                //send notification to buyer
                if (!string.IsNullOrEmpty(buyerEmail))
                {
                    var connectionId = NotificationHub.getConnectionIdbyEmail(buyerEmail);

                    if (!string.IsNullOrEmpty(connectionId))
                    {
                        await hubContext.Clients.Client(connectionId).SendAsync("PaymentReceived", mapper.Map<OrderDto>(order));
                    }
                }
               

                return Ok(responseObj);
            }

            return BadRequest("Payment verification failed or not approved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Webhook Error: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }

    }


    // Get all delivery methods
    [HttpGet("delivery-methods")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
    {
        var deliveryMethods = await unit.Repository<DeliveryMethod>().ListAllAsync();
        return Ok(deliveryMethods);
    }

    //Get delivery method by available zip code
    [HttpGet("delivery-methods/{zipCode}")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethodsByZipCode(string zipCode)
    {
        if (string.IsNullOrWhiteSpace(zipCode) || zipCode.Length < 2)
        {
            return BadRequest("Zip code must be at least 2 characters.");
        }

        var deliveryMethods = await unit.Repository<DeliveryMethod>().ListAllAsync();
        string firstTwoDigits = zipCode.Substring(0, 2);
        return Ok(deliveryMethods.Where(dm => dm.AvailableZipcodes.Contains(firstTwoDigits)).ToList());
    }
}
