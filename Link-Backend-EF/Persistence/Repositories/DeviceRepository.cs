using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Context;

namespace Link_Backend_EF.Persistence.Repositories
{
    public class DeviceRepository : BaseRepository, IUserInfoRepository<Device>
    {
        public DeviceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Device model)
        {
            await _context.Device.AddAsync(model);
        }

        public void Delete(Device model)
        {
            _context.Device.Remove(model);
        }

        public Task<Device> FindByCodeAndSharedIdAsync(string code, int sharedId)
        {
            throw new NotImplementedException();
        }

        public async Task<Device> FindByIdAsync(int id)
        {
            return await _context.Device.FindAsync(id);
        }

        public Task<Device> FindByStringAsync(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(Device model)
        {
            _context.Device.Update(model);
        }
    }
}
