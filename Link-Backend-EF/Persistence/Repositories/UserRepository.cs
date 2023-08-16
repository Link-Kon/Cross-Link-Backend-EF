using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Link_Backend_EF.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserInfoRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User model)
        {
            await _context.User.AddAsync(model);
        }

        public void Delete(User model)
        {
            _context.User.Remove(model);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<User> FindByCodeAsync(string value)
        {
            return await _context.User.FirstOrDefaultAsync(i => i.Code == value);
        }

        // Find by Username
        public async Task<User> FindByStringAsync(string value)
        {
            return await _context.User.FirstOrDefaultAsync(i => i.Username == value);
        }

        public void Update(User model)
        {
            _context.User.Update(model);
        }

        public Task<User> FindByCodeAndSharedIdAsync(string code, int sharedId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByIdAndOldTokenAsync(int id, string token)
        {
            return await _context.User.FirstOrDefaultAsync(i => i.Id == id && i.Token == token);
        }
    }
}