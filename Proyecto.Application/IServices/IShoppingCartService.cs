using Proyecto.Application.Models.Dtos;
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
        ShoppingCartDto GetShoppingCartByClientId(int clientId);
        bool AddProductoToCart(int clientId, Guid productId);
        bool RemoveProductoFromCart(int clientId, Guid productId);
    }
}

