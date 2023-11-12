using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Resources;

namespace Link_Backend_EF.Domain.Services
{
    public interface IFriendshipService
    {
        Task<FriendshipResponse> SaveAsync(Friendship model);
        Task<IEnumerable<FriendshipListResponse>> ListByUserCodeAsync(string code);
        Task<FriendshipResponse> UpdateAsync(Friendship model);
        //Task<FriendshipResponse> Delete(int id);
        Task<FriendshipResponse> GetFriendshipProof(string user1Code, string user2Code);
    }
}
