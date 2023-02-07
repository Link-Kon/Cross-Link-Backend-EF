using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Domain.Services
{
    public interface IFriendshipService
    {
        Task<FriendshipResponse> SaveAsync(Friendship model);
        Task<FriendshipResponse> FindByPatiendIdAsync(int id);
        Task<FriendshipResponse> FindByCaretakerAsync(int id);
        Task<FriendshipResponse> Update(int id, Friendship model);
        Task<FriendshipResponse> Delete(int id);
    }
}
