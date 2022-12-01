using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUS.Business.Abstract;
using ShopsRUS.Core.Model;

namespace ShopsRUS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpPost("calculateDiscount")]
        public async Task<IActionResult> CalculateDiscount(DiscountRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model Error");

            return Ok(await _discountService.CalculateDiscount(request));
        }
    }
}
