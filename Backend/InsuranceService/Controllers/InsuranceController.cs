using InsuranceService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InsuranceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService service;

        public InsuranceController(IInsuranceService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "UserOnly")]
        public async Task<IActionResult> InsuranceDetails(int id)
        {
            //var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            //if (!int.TryParse(userIdClaim, out var userId))
            //{
            //    return Unauthorized("Invalid or missing user ID.");
            //}
            var result = await service.GetInsurancesDetailsAsync(id);
            return Ok(result);
        }
    }
}
