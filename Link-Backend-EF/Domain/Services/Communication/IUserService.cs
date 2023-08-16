using Link_Backend_EF.Resources.Base;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public interface IUserService
    {
        Task<UserResponse> FindByIdAndOldTokenAsync(TokenValidationResource resource);
    }
}
