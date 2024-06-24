using Microsoft.AspNetCore.Mvc;
using Proyecto.Application.IServices;
using Proyecto.Domain.Models;
using System;

namespace ProyectoProgIII.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("GetShoppingCart/{clientId}")]
        public ActionResult<ShoppingCart> GetShoppingCart(int clientId)
        {
            var shoppingCart = _shoppingCartService.GetShoppingCartByClientId(clientId);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            return Ok(shoppingCart);
        }

        [HttpPost("AddProductToCart/{clientId}/{productId}")]
        public ActionResult AddProductToCart(int clientId, Guid productId)
        {
            var success = _shoppingCartService.AddProductoToCart(clientId, productId);
            if (!success)
            {
                return NotFound("Product or shopping cart not found");
            }
            return Ok("Product added to cart successfully");
        }

        [HttpPost("RemoveProductFromCart/{clientId}/{productId}")]
        public ActionResult RemoveProductFromCart(int clientId, Guid productId)
        {
            var success = _shoppingCartService.RemoveProductoFromCart(clientId, productId);
            if (!success)
            {
                return NotFound("Product or shopping cart not found");
            }
            return Ok("Product removed from cart successfully");
        }
    }
}