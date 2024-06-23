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

        [HttpGet("{clientId}")]
        public ActionResult<ShoppingCart> GetShoppingCart(Guid clientId)
        {
            var shoppingCart = _shoppingCartService.GetShoppingCartByClientId(clientId);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            return Ok(shoppingCart);
        }

        [HttpPost("{clientId}/add-product/{productId}")]
        public ActionResult AddProductToCart(Guid clientId, Guid productId)
        {
            var success = _shoppingCartService.AddProductoToCart(clientId, productId);
            if (!success)
            {
                return NotFound();
            }
            return Ok("Product added to cart successfully.");
        }

        [HttpPost("{clientId}/remove-product/{productId}")]
        public ActionResult RemoveProductFromCart(Guid clientId, Guid productId)
        {
            var success = _shoppingCartService.RemoveProductoFromCart(clientId, productId);
            if (!success)
            {
                return NotFound();
            }
            return Ok("Product removed from cart successfully.");
        }
    }
}