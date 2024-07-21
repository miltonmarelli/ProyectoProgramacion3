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

        [HttpGet("GetShoppingCart/{clientName}")]
        public ActionResult<ShoppingCart> GetShoppingCart(string clientName)
        {
            var shoppingCart = _shoppingCartService.GetShoppingCartByClientName(clientName); ;
            if (shoppingCart == null)
            {
                return NotFound();
            }
            return Ok(shoppingCart);
        }

        [HttpPost("AddProductToCart/{clientName}/{productId}")]
        public ActionResult AddProductToCart(string clientName, Guid productId)
        {
            var success = _shoppingCartService.AddProductoToCart(clientName, productId);
            if (!success)
            {
                return NotFound("Producto o carrito de compras no encontrado");
            }
            return Ok("Producto agregado al carrito exitosamente");
        }

        [HttpPost("RemoveProductFromCart/{clientName}/{productId}")]
        public ActionResult RemoveProductFromCart(string clientName, Guid productId)
        {
            var success = _shoppingCartService.RemoveProductoFromCart(clientName, productId);
            if (!success)
            {
                return NotFound("Producto o carrito de compras no encontrado");
            }
            return Ok("Producto removido del carrito exitosamente");
        }
    }
}