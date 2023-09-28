using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Domain.Services
{
    public interface IUserDataService
    {
        Task<UserDataResponse> FindByFriendAsync(string user1Code, string user2Code);
    }
}
