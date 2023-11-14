using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<string> GetDeviceTokenByUserCode(string code);
        Task<User> FindByCodeAsync(string code);
        Task<User> FindByIdAndOldTokenAsync(int id, string token);
    }
}