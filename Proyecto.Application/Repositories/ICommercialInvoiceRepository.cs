using System;
using Proyecto.Domain.Models;

namespace Proyecto.Application.Repositories
{
    public interface ICommercialInvoiceRepository
    {
        CommercialInvoice GetInvoiceById(Guid invoiceId);
        bool CreateInvoice(CommercialInvoice commercialInvoice);
        bool UpdateInvoice(CommercialInvoice commercialInvoice);
        bool DeleteInvoice(Guid invoiceId);
    }
}