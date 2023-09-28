using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Domain.Repositories
{
    public interface IFriendshipRepository
	{
        Task AddAsync(Friendship model);
        Task<IEnumerable<Friendship>> ListByUserCodeAsync(string code);
        Task<Friendship> GetFriendshipProof(string user1Code, string user2Code);
        Task<Friendship> FindByUsersCodeAsync(string user1code, string user2code);
        void Update(Friendship model);
        void Delete(Friendship model);
    }
}