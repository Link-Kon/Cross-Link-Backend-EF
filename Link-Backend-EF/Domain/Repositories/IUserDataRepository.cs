using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Repositories
{
    public interface IUserDataRepository
    {
        Task<UserData> FindByFriendAsync(string userCode);
    }
}
