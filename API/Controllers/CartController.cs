using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CartController(ICartService cartService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetCardById(string id)
        {
            var card = await cartService.GetCardAsync(id);
            return Ok(card ?? new ShoppingCart { Id = id });
        }
        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateCard(ShoppingCart shoppingCart)
        {
            var card = await cartService.SetCardAsync(shoppingCart);
            if (card == null) return BadRequest("Failed to update card");
            return card;
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCard(string id)
        {
            var result =  cartService.DeleteCardAsync(id);
            if (result == null) return BadRequest("can not delete card");
            return Ok();

        }
    }
}
