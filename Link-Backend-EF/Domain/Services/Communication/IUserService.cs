using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Resources.Base;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public interface IUserService
    {
        Task<string> GetDeviceTokenByUserCode(string code);
        Task<UserResponse> FindByCodeAsync(string code);
        Task<UserResponse> FindByIdAndOldTokenAsync(TokenValidationResource resource);
        Task<UserResponse> UpdateDeviceTokenAsync(string userCode, User model);
    }
}
