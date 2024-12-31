using AppointmentService.DTOs;
using AppointmentService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppointmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        //[HttpPost("set-appointment")]
        //[Authorize(Policy = "UserOnly")]
        //public async Task<IActionResult> SetAppointment(AppointmentDto appointmentDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values
        //        .SelectMany(v => v.Errors)
        //        .Select(e => e.ErrorMessage)
        //        .ToList();

        //        return BadRequest(new { Errors = errors });
        //    }

        //    var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        //    if (!int.TryParse(userIdClaim, out var userId))
        //    {
        //        return Unauthorized("Invalid or missing user ID.");
        //    }

        //    var result = await appointmentService.SetAppointment(appointmentDto, userId);
        //    return Ok(result);
        //}
    }
}
