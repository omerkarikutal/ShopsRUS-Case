using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUS.Business.Abstract;
using ShopsRUS.Core.Model;

namespace ShopsRUS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpPost("createInvoice")]
        public async Task<IActionResult> CreateInvoice(InvoiceRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model Error");

            return Ok(await _invoiceService.CreateInvoice(request));
        }
        [HttpGet("getinvoce/{invoiceNumber}")]
        public async Task<IActionResult> GetInvoice(string invoiceNumber)
        {
            if (string.IsNullOrEmpty(invoiceNumber))
                return BadRequest("Invoice number is required");

            return Ok(await _invoiceService.GetInvoice(invoiceNumber));
        }
    }
}
