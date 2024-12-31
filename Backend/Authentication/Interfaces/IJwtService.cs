using Authentication.Models;

namespace UserService.Interfaces
{
    public interface IJwtService
    {
        string GetJwtToken(User user);
    }
}
