namespace UserService.Interfaces
{
    public interface ITokenBlacklistService
    {
        void AddTokenToBlacklist(string token);
        bool IsTokenBlacklisted(string token);
    }
}
