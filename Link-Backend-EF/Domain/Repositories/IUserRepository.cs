using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindByCodeAsync(string code);
    }
}