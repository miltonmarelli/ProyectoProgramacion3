using System;
using System.Linq;
using Proyecto.Application.Repositories;
using Proyecto.Domain.Models;
using Proyecto.Infraestructure.Context;

namespace Proyecto.Infraestructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ProyectoDbContext _context;

        public ShoppingCartRepository(ProyectoDbContext context)
        {
            _context = context;
        }

        public ShoppingCart GetShoppingCartByClientId(int clientId)
        {
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(sc => sc.ClientId == clientId);
            return shoppingCart ?? new ShoppingCart();
        }

        public bool UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            var existingCart = _context.ShoppingCarts.FirstOrDefault(sc => sc.IdShoppingCart == shoppingCart.IdShoppingCart);

            if (existingCart == null)
            {
                return false;
            }

            existingCart.Productos = shoppingCart.Productos;
            existingCart.Impuesto = shoppingCart.Impuesto;

            _context.SaveChanges();
            return true;
        }
    }
}
