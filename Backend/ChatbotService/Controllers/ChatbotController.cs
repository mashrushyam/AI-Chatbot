using ChatbotService.DTOs;
using ChatbotService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatbotService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatbotController : ControllerBase
    {
        private readonly IChatbotService service;

        public ChatbotController(IChatbotService service)
        {
            this.service = service;
        }

        [HttpPost("chat")]
        [Authorize(Policy = "UserOnly")]
        public async Task<IActionResult> Chat([FromBody] ChatDto chatDto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized("Invalid or missing user ID.");
            }

            var responseMessage = string.Empty;

            //if (chatDto.Message.ToLower().Contains("appointment"))
            //{
            //    responseMessage = await service.SetAppointment(userId, chatDto.AppointmentDate, chatDto.AppointmentTime);
            //}
            if (chatDto.Message.ToLower().Contains("due payment"))
            {
                responseMessage = await service.GetDuePayment(userId);
            }
            else if (chatDto.Message.ToLower().Contains("insurance"))
            {
                responseMessage = await service.GetInsuranceDetails(userId);
            }
            else if (chatDto.Message.ToLower().Contains("prescription"))
            {
                responseMessage = await service.GetPrescription(userId);
            }
            else
            {
                responseMessage = "Sorry, I didn't understand that. Can you please rephrase?";
            }

            return Ok(responseMessage);
        }
    }
}
