using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Interfaces;
using System.Security.Claims;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService service;

        public PaymentController(IPaymentService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "UserOnly")]
        public async Task<IActionResult> DuePayment(int id)
        {
            //var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            //if (!int.TryParse(userIdClaim, out var userId))
            //{
            //    return Unauthorized("Invalid or missing user ID.");
            //}
            var result = await service.GetDuePaymentAsync(id);
            return Ok(result);
        }
    }
}
