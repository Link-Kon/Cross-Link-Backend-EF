using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Link_Backend_EF.Persistence.Repositories
{
    public class UserDeviceRepository : BaseRepository, IListRelationRepository<UserDevice>
    {
        public UserDeviceRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(UserDevice model)
        {
            await _context.UserDevice.AddAsync(model);
        }

        public void Delete(UserDevice model)
        {
            _context.UserDevice.Remove(model);
        }

        public async Task<UserDevice> FindByUsersIdAndEntityIdAsync(int userId, int deviceId)
        {
            return await _context.UserDevice.FirstOrDefaultAsync(i => i.UserDataId == userId && i.DeviceId == deviceId);
        }

        public async Task<List<UserDevice>> ListByUserIdAsync(int id)
        {
            return await _context.UserDevice.Where(i => i.UserDataId == id).ToListAsync();
        }

        public void Update(UserDevice model)
        {
            _context.UserDevice.Update(model);
        }
    }
}

