using UserService.Interfaces;

namespace UserService.Services
{
    public class TokenBlacklistingService : ITokenBlacklistService
    {
        private readonly HashSet<string> _blacklistedTokens = new HashSet<string>();
        public void AddTokenToBlacklist(string token)
        {
            _blacklistedTokens.Add(token);
        }

        public bool IsTokenBlacklisted(string token)
        {
            return _blacklistedTokens.Contains(token);
        }
    }
}
