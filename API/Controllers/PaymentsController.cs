using API.Dtos;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers;

public class PaymentsController(
        IPaymentService paymentService,
        IGenericRepository<DeliveryMethod> deliveryMethodRepo
) : BaseApiController
{
    [Authorize]
    [HttpPost("checkout")]
    public async Task<ActionResult<object?>> Checkout([FromBody] CheckoutDto checkoutDto)
    {


        
        var cart = await paymentService.GetTotalPrice(checkoutDto.CartId, checkoutDto.DeliveryMethodId);
        if (cart == null) return BadRequest("Problem with your cart");

        var response = await paymentService.ProcessPaymentAsync(cart, checkoutDto.PaymentMethod);
        return response;
    }

    // Get all delivery methods
    [HttpGet("delivery-methods")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
    {
        var deliveryMethods = await deliveryMethodRepo.ListAllAsync();
        return Ok(deliveryMethods);
    }

    //Get delivery method by available zip code
    [HttpGet("delivery-methods/{zipCode}")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethodsByZipCode(string zipCode)
    {
        var deliveryMethods = await deliveryMethodRepo.ListAllAsync();
        string firstTwoDigits = zipCode.Substring(0, 2);
        return Ok(deliveryMethods.Where(dm => dm.AvailableZipcodes.Contains(firstTwoDigits)).ToList());
    }
}
