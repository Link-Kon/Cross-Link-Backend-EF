using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Link_Backend_EF.Persistence.Repositories
{
    public class FriendshipRepository : BaseRepository, IFriendshipRepository
    {
        public FriendshipRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Friendship model)
        {
            await _context.Friendship.AddAsync(model);
        }

        public void Delete(Friendship model)
        {
            _context.Friendship.Remove(model);
        }

        public async Task<IEnumerable<Friendship>> ListByUserCodeAsync(string code)
        {
            return await _context.Friendship.Where(i => i.User1Code == code || i.User2Code == code).ToListAsync();
        }

        public async Task<Friendship> FindByUsersCodeAsync(string user1code, string user2code)
        {
            return await _context.Friendship.FirstOrDefaultAsync(i => i.User1Code == user1code && i.User2Code == user2code);
        }

        public void Update(Friendship model)
        {
            _context.Friendship.Update(model);
        }

        public async Task<Friendship> GetFriendshipProof(string user1Code, string user2Code)
        {
            return await _context.Friendship.FirstOrDefaultAsync(i =>
            ((i.User1Code == user1Code && i.User2Code == user2Code) ||
            (i.User1Code == user2Code && i.User2Code == user1Code)) && 
            (i.State));
        }
    }
}