using UserService.DTOs;

namespace UserService.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync (LoginDto loginDto);
        Task<string> RegisterAsync(RegisterDto registerDto);
        Task<string> LogoutAsync(string token);
    }
}
