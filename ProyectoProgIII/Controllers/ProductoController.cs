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

        [HttpGet]
        public ActionResult<IEnumerable<Producto?>> GetProductList()
        {
            var productList = _productoService.GetProductList();
            return Ok(productList);
        }

        [HttpGet("{id}")]
        public ActionResult<Producto?> GetById(Guid id)
        {
            var product = _productoService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult CreateProduct(Producto producto)
        {
            var success = _productoService.CreateProduct(producto);
            if (!success)
            {
                return Conflict("Product with the same ID already exists.");
            }
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(Guid id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest("Invalid product ID");
            }
            var success = _productoService.UpdateProduct(producto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            var success = _productoService.DeleteProduct(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("apply-discount/{id}")]
        public ActionResult ApplyDiscount(Guid id, double percentage)
        {
            var success = _productoService.ApplyDiscount(id, percentage);
            if (!success)
            {
                return NotFound();
            }
            return Ok("Discount applied successfully.");
        }
    }
}