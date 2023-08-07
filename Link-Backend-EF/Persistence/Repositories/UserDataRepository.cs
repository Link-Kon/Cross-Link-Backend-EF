using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Link_Backend_EF.Persistence.Repositories
{
    public class UserDataRepository : BaseRepository, IUserInfoRepository<UserData>
    {
        public UserDataRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(UserData model)
        {
            await _context.UserData.AddAsync(model);
        }

        public void Delete(UserData model)
        {
            _context.UserData.Remove(model);
        }

        public async Task<UserData> FindByIdAsync(int id)
        {
            return await _context.UserData.FindAsync(id);
        }

        // Find by Email
        public async Task<UserData> FindByStringAsync(string value)
        {
            return await _context.UserData.FirstOrDefaultAsync(i => i.Email == value);
        }

        public void Update(UserData model)
        {
            _context.UserData.Update(model);
        }

        public async Task<UserData> FindByCodeAndSharedIdAsync(string code, int sharedId)
        {
            Friendship userFriendship = await _context.Friendship
                .Where(f => (f.User1Code == code || f.User2Code == code) && f.SharedId == sharedId)
                .FirstOrDefaultAsync();

            if (userFriendship != null)
            {
                string matchedUserCode = userFriendship.User1Code == code ? userFriendship.User2Code : userFriendship.User1Code;

                User user = await _context.User.FirstOrDefaultAsync(i => i.Code == matchedUserCode);
                return await _context.UserData.FindAsync(user.Id);
            }
            else
            {
                User user = await _context.User.FirstOrDefaultAsync(i => i.Code == code);
                return await _context.UserData.FindAsync(user.Id);
            }
        }

    }
}