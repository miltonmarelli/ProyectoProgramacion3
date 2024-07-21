using Proyecto.Application.IServices;
using Proyecto.Domain.Repositories;
using Proyecto.Domain.Models;

namespace Proyecto.Application.Services
{
    public class CommercialInvoiceService : ICommercialInvoiceService
    {
        private readonly ICommercialInvoiceRepository _commercialInvoiceRepository;
        private readonly IUserRepository _userRepository;

        public CommercialInvoiceService(ICommercialInvoiceRepository commercialInvoiceRepository, IUserRepository userRepository)
        {
            _commercialInvoiceRepository = commercialInvoiceRepository;
            _userRepository = userRepository;
        }
        public string GetInvoiceDetails(CommercialInvoice Invoice)
        {
            var invoiceDetails = $"Detalles de la Compra (ID: {Invoice.IdOrden})\n";
            invoiceDetails += $"Cliente: {Invoice.ClientName}\n";
            invoiceDetails += "Productos:\n";

            foreach (var producto in Invoice.ShoppingCart.Productos)
            {
                invoiceDetails += $"{producto.Descripcion} - Precio: {producto.PrecioUnitario:C} - Descuento: {producto.Descuento: %}\n";
            }

            invoiceDetails += $"Subtotal: {Invoice.ShoppingCart.Subtotal: $}\n";
            invoiceDetails += $"Impuestos: {Invoice.ShoppingCart.Impuesto: $}\n";
            invoiceDetails += $"Total: {Invoice.Total:C}";

            return invoiceDetails;
        }
    }
}

