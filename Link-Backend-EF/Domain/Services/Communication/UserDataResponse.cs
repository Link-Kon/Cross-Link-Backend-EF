using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public class UserDataResponse : BaseResponse<UserData>
    {
        public UserDataResponse(string message) : base(message)
        {
        }

        public UserDataResponse(UserData resource) : base(resource)
        {
        }
    }
}
