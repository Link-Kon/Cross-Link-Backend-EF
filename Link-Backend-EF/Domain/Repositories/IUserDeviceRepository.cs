using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Repositories
{
    public interface IUserDeviceRepository
    {
        Task AddAsync(UserDevice model);
        Task<IEnumerable<UserDevice>> ListByUserIdAsync(int id);
        Task<UserDevice> FindByUsersIdAndDeviceIdAsync(int userId, int deviceId);
        void Update(UserDevice model);
        void Delete(UserDevice model);
    }
}
