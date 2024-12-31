using Authentication.Models;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using UserService.Datas;
using UserService.DTOs;
using UserService.Interfaces;

namespace UserService.Services
{
    public class AuthService : Interfaces.IAuthService
    {
        private readonly UserDbContext context;
        private readonly IJwtService jwtService;
        private readonly ITokenBlacklistService tokenBlacklistService;

        public AuthService(UserDbContext context, IJwtService jwtService, ITokenBlacklistService tokenBlacklistService)
        {
            this.context = context;
            this.jwtService = jwtService;
            this.tokenBlacklistService = tokenBlacklistService;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
           var user = await context.Users.FirstOrDefaultAsync(u=>u.UserEmail == loginDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return "Invalid Credentials...";
            }
            return jwtService.GetJwtToken(user);
        }

        public async Task<string> LogoutAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return "No token provided.";
            }

            tokenBlacklistService.AddTokenToBlacklist(token);
            return "Logout Successfully...";

        }

        public async Task<string> RegisterAsync(RegisterDto registerDto)
        {
            var existUser = await context.Users.FirstOrDefaultAsync(u => u.UserEmail == registerDto.Email);
            if (existUser != null)
            {
                return "User already exists!";
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            var user = new User
            {
                UserEmail = registerDto.Email,
                UserName = registerDto.Name,
                Password = hashedPassword,
                Role = "User"
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return "Registeration Successfull...";
        }
    }
}
