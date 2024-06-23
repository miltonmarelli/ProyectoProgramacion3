using System;
using Proyecto.Domain.Models;

namespace Proyecto.Application.Repositories
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetShoppingCartByClientId(Guid clientId);
        bool UpdateShoppingCart(ShoppingCart shoppingCart);
    }
}

