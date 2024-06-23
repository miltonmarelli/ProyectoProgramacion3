using System;
using System.Collections.Generic;

namespace Proyecto.Domain.Models
{
    public class CommercialInvoice
    {
        public Guid IdOrden { get; set; }
        public Client Client { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public double Total => CalculateTotal();
        public string Estado { get; set; }

        public Guid ClientId { get; set; }
        public CommercialInvoice()
        {
            IdOrden = Guid.NewGuid();
            ShoppingCart = new ShoppingCart();
            Client = new Client();
            Estado = "pendiente";
        }

        private double CalculateTotal()
        {
            double discountTotal = 0;
            foreach (var product in ShoppingCart.Productos)
            {
                discountTotal += product.PrecioUnitario * product.Descuento;
            }

            return ShoppingCart.Subtotal - discountTotal + (ShoppingCart.Subtotal * ShoppingCart.Impuesto);
        }
    }
}
