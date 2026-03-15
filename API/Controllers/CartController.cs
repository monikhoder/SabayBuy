using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CartController(ICartService cartService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ShoppingCard>> GetCardById(string id)
        {
            var card = await cartService.GetCardAsync(id);
            return Ok(card ?? new ShoppingCard { Id = id });
        }
        [HttpPost]
        public async Task<ActionResult<ShoppingCard>> UpdateCard(ShoppingCard shoppingCard)
        {
            var card = await cartService.SetCardAsync(shoppingCard);
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
