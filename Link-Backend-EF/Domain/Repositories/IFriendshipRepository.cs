using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Repositories
{
    public interface IFriendshipRepository
	{
        Task AddAsync(Friendship model);
        Task<Friendship> FindByIdAsync(int id);
        Task<Friendship> FindByPatiendIdAsync(int id);
        Task<Friendship> FindByCaretakerIdAsync(int id);
        void Update(Friendship model);
        void Delete(Friendship model);
    }
}