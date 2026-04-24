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
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Cart id is required");
            }

            var card = await cartService.GetCardAsync(id);
            return Ok(card ?? new ShoppingCart { Id = id });
        }
        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateCard(ShoppingCart shoppingCart)
        {
            if (string.IsNullOrWhiteSpace(shoppingCart.Id))
            {
                return BadRequest("Cart id is required");
            }

            if (shoppingCart.Items.Any(item =>
                    string.IsNullOrWhiteSpace(item.ProductId) ||
                    string.IsNullOrWhiteSpace(item.ProductVariantId) ||
                    item.Quantity <= 0))
            {
                return BadRequest("Cart contains invalid items");
            }

            var card = await cartService.SetCardAsync(shoppingCart);
            if (card == null) return BadRequest("Failed to update card");
            return card;
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCard(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Cart id is required");
            }

            var result = await cartService.DeleteCardAsync(id);
            if (!result) return NotFound("Cart not found");
            return Ok();

        }
    }
}
