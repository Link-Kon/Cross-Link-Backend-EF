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

        public async Task<Friendship> FindByCaretakerIdAsync(int id)
        {
            return await _context.Friendship.FirstOrDefaultAsync(i => i.CaretakerId == id);
        }

        public async Task<Friendship> FindByIdAsync(int id)
        {
            return await _context.Friendship.FindAsync(id);
        }

        public async Task<Friendship> FindByPatiendIdAsync(int id)
        {
            return await _context.Friendship.FirstOrDefaultAsync(i => i.PatientId == id);
        }

        public void Update(Friendship model)
        {
            _context.Friendship.Update(model);
        }
    }
}