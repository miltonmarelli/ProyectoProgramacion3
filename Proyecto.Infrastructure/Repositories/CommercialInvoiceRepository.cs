using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Proyecto.Application.Repositories;
using Proyecto.Domain.Models;
using Proyecto.Infraestructure.Context;

namespace Proyecto.Infraestructure.Repositories
{
    public class CommercialInvoiceRepository : ICommercialInvoiceRepository
    {
        private readonly ProyectoDbContext _dbContext;

        public CommercialInvoiceRepository(ProyectoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CommercialInvoice GetInvoiceById(Guid invoiceId)
        {
            return _dbContext.CommercialInvoices
                .Include(ci => ci.ShoppingCart)
                .ThenInclude(sc => sc.Productos)
                .FirstOrDefault(ci => ci.IdOrden == invoiceId);
        }

        public bool CreateInvoice(CommercialInvoice commercialInvoice)
        {
            try
            {
                _dbContext.CommercialInvoices.Add(commercialInvoice);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateInvoice(CommercialInvoice commercialInvoice)
        {
            if (_dbContext.CommercialInvoices.Any(ci => ci.IdOrden == commercialInvoice.IdOrden))
            {
                _dbContext.CommercialInvoices.Update(commercialInvoice);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteInvoice(Guid invoiceId)
        {
            var invoiceToDelete = _dbContext.CommercialInvoices.FirstOrDefault(ci => ci.IdOrden == invoiceId);
            if (invoiceToDelete != null)
            {
                _dbContext.CommercialInvoices.Remove(invoiceToDelete);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
