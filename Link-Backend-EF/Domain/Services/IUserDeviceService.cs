using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Domain.Services
{
    public interface IUserDeviceService
    {
        Task<UserDeviceResponse> SaveAsync(UserDevice model);
        Task<IEnumerable<UserDevice>> ListByUserIdAsync(int id);
        Task<UserDeviceResponse> UpdateAsync(UserDevice model);
        //Task<UserDeviceResponse> Delete(int id);
    }
}
