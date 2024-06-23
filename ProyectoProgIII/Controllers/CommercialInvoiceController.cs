using Microsoft.AspNetCore.Mvc;
using Proyecto.Application.IServices;
using Proyecto.Domain.Models;

namespace Proyecto.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommercialInvoiceController : ControllerBase
    {
        private readonly ICommercialInvoiceService _invoiceService;

        public CommercialInvoiceController(ICommercialInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("{invoiceId}")]
        public IActionResult GetInvoiceDetails(CommercialInvoice invoiceId)
        {
            var invoice = _invoiceService.GetInvoiceDetails(invoiceId);
            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

    }
}
