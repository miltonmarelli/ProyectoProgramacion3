using Proyecto.Application.IServices;
using Proyecto.Domain.Models;

namespace Proyecto.Application.Services
{
    public class CommercialInvoiceService : ICommercialInvoiceService
    {
        public string GetInvoiceDetails(CommercialInvoice Invoice)
        {

            var invoiceDetails = $"Detalles de la Compra (ID: {Invoice.IdOrden})\n";
            invoiceDetails += $"Cliente: {Invoice.Client.Name}\n";
            invoiceDetails += "Productos:\n";

            foreach (var producto in Invoice.ShoppingCart.Productos)
            {
                invoiceDetails += $"{producto.Descripcion} - Precio: {producto.PrecioUnitario:C} - Descuento: {producto.Descuento:P}\n";
            }

            invoiceDetails += $"Subtotal: {Invoice.ShoppingCart.Subtotal:C}\n";
            invoiceDetails += $"Impuestos: {Invoice.ShoppingCart.Impuesto:P}\n";
            invoiceDetails += $"Total: {Invoice.Total:C}";

            return invoiceDetails;
        }
    }
}

