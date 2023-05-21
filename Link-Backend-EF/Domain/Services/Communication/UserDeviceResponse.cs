using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public class UserDeviceResponse : BaseResponse<UserDevice>
    {
        public UserDeviceResponse(string message) : base(message)
        {
        }

        public UserDeviceResponse(UserDevice resource) : base(resource)
        {
        }
    }
}
