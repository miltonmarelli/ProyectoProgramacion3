using Proyecto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.IServices
{
    public interface IShoppingCartService
    {
        ShoppingCart GetShoppingCartByClientId(Guid clientId);
        bool AddProductoToCart(Guid clientId, Guid productId);
        bool RemoveProductoFromCart(Guid clientId, Guid productId);
    }
}

