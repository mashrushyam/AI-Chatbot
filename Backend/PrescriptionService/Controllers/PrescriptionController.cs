using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrescriptionService.Interfaces;
using System.Security.Claims;

namespace PrescriptionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService service;
        private readonly ILogger<PrescriptionController> logger;

        public PrescriptionController(IPrescriptionService service, ILogger<PrescriptionController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "UserOnly")]
        public async Task<IActionResult> PrescriptionDetails(int id)
        {
            //var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            //if (!int.TryParse(userIdClaim, out var userId))
            //{
            //    return Unauthorized("Invalid or missing user ID.");
            //}

            logger.LogInformation($"Received request for prescription details for user ID: {id}");

            var result = await service.GetAllPrescriptionsAsync(id);
            return Ok(result);
        }
    }
}
