using System;
using Proyecto.Application.IServices;
using Proyecto.Domain.Models;
using Proyecto.Application.Repositories;

namespace Proyecto.Application.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductoRepository _productoRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IProductoRepository productoRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productoRepository = productoRepository;
        }

        public ShoppingCart GetShoppingCartByClientId(Guid clientId)
        {
            return _shoppingCartRepository.GetShoppingCartByClientId(clientId);
        }

        public bool AddProductoToCart(Guid clientId, Guid productId)
        {
            var shoppingCart = _shoppingCartRepository.GetShoppingCartByClientId(clientId);
            var product = _productoRepository.GetById(productId);

            if (shoppingCart == null || product == null)
            {
                return false; // Cliente o producto no encontrado
            }

            shoppingCart.Productos.Add(product);
            _shoppingCartRepository.UpdateShoppingCart(shoppingCart);
            return true;
        }

        public bool RemoveProductoFromCart(Guid clientId, Guid productId)
        {
            var shoppingCart = _shoppingCartRepository.GetShoppingCartByClientId(clientId);
            var product = _productoRepository.GetById(productId);

            if (shoppingCart == null || product == null)
            {
                return false; // Cliente o producto no encontrado
            }

            shoppingCart.Productos.Remove(product);
            _shoppingCartRepository.UpdateShoppingCart(shoppingCart);
            return true;
        }
    }
}
