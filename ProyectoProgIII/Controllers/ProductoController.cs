using Microsoft.AspNetCore.Mvc;
using Proyecto.Application.IServices;
using Proyecto.Domain.Models;
using System;
using System.Collections.Generic;

namespace ProyectoProgIII.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("GetProductList")]
        public ActionResult<IEnumerable<Producto?>> GetProductList()
        {
            var productList = _productoService.GetProductList();
            return Ok(productList);
        }

        [HttpGet("GetProductById/{id}")]
        public ActionResult<Producto?> GetById(Guid id)
        {
            var product = _productoService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        public ActionResult CreateProduct(Producto producto)
        {
            var success = _productoService.CreateProduct(producto);
            if (!success)
            {
                return Conflict("Ya existe un producto con el mismo ID");
            }
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        [HttpPut("UpdateProduct/{id}")]
        public ActionResult UpdateProduct(Guid id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest("ID de producto no valido");
            }
            var success = _productoService.UpdateProduct(producto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("DeleteProduct/{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            var success = _productoService.DeleteProduct(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("ApplyDiscount/{id}")]
        public ActionResult ApplyDiscount(Guid id, double percentage)
        {
            var success = _productoService.ApplyDiscount(id, percentage);
            if (!success)
            {
                return NotFound();
            }
            return Ok("El descuento se aplico correctamente");
        }
    }
}