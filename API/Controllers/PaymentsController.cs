using System;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PaymentsController : BaseApiController
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ShoppingCard>> CreateOrUpdatePaymentIntent(string basketId)
    {
        //below code is just for testing purpose, we will implement the actual logic in the future
        var cart = new ShoppingCard
        {
            Id = basketId,
            PaymentIntentId = Guid.NewGuid().ToString()
        };
        return Ok(cart);
    }

}
