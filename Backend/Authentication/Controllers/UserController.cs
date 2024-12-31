using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.DTOs;
using UserService.Interfaces;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService userService;

        public UserController(IAuthService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                 .SelectMany(v => v.Errors)
                 .Select(e => e.ErrorMessage)
                 .ToList();

                return BadRequest(new { Errors = errors });
            }

            var result =await  userService.LoginAsync(loginDto);
            if(result == "Invalid Credentials...")
            {
                return Unauthorized(result);
            }
            return Ok(result);
        }

        [HttpPost("logout")]
        [Authorize(Policy = "UserOnly")]
        public async Task<IActionResult> Logout()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var result = await userService.LogoutAsync(token);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                 .SelectMany(v => v.Errors)
                 .Select(e => e.ErrorMessage)
                 .ToList();

                return BadRequest(new { Errors = errors });
            }

            var result = await userService.RegisterAsync(registerDto);
            return Ok(result);
        }
    }
}
