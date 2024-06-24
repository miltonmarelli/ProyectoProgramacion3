using System;
using Proyecto.Application.IServices;
using Proyecto.Domain.Models;
using Proyecto.Application.Repositories;
using Proyecto.Application.Models.Dtos;

namespace Proyecto.Application.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IProductoRepository productoRepository, IUserRepository userRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productoRepository = productoRepository;
            _userRepository = userRepository;
        }

        public ShoppingCartDto GetShoppingCartByClientId(int clientId)
        {
            var shoppingCart = _shoppingCartRepository.GetShoppingCartByClientId(clientId);
            if (shoppingCart == null)
            {
                throw new InvalidOperationException($"Shopping cart for client with ID {clientId} not found.");
            }

            var client = _userRepository.GetByName(shoppingCart.ClientName);

            return new ShoppingCartDto
            {
                IdShoppingCart = shoppingCart.IdShoppingCart,
                Impuesto = shoppingCart.Impuesto,
                ClientId = shoppingCart.ClientId,
                Productos = shoppingCart.Productos.Select(p => p.Descripcion).ToList(),
                Subtotal = shoppingCart.Subtotal,
                Client = new UserDto
                {
                    Name = client.Name,
                    Email = client.Email,
                }
            };
        }

        public bool AddProductoToCart(int clientId, Guid productId)
        {
            var shoppingCart = _shoppingCartRepository.GetShoppingCartByClientId(clientId);
            var product = _productoRepository.GetById(productId);

            if (shoppingCart == null || product == null)
            {
                throw new InvalidOperationException($"Shopping cart for client with ID {clientId} not found.");
            }

            shoppingCart.Productos.Add(product);
            _shoppingCartRepository.UpdateShoppingCart(shoppingCart);
            return true;
        }

        public bool RemoveProductoFromCart(int clientId, Guid productId)
        {
            var shoppingCart = _shoppingCartRepository.GetShoppingCartByClientId(clientId);
            var product = _productoRepository.GetById(productId);

            if (shoppingCart == null || product == null)
            {
                return false;
            }

            shoppingCart.Productos.Remove(product);
            _shoppingCartRepository.UpdateShoppingCart(shoppingCart);
            return true;

        }
    }
}
