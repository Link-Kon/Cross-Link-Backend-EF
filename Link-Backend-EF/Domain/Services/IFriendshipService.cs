using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services
{
    public interface IFriendshipService
    {
        Task SaveAsync(Friendship model);
        Task<Friendship> FindByPatiendIdAsync(int id);
        Task<Friendship> FindByCaretakerAsync(int id);
        void Update(int id, Friendship model);
        void Delete(int id);
    }
}
