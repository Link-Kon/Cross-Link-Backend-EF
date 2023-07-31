using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication.List
{
    public class UserDeviceListResponse : BaseResponse<List<UserDevice>>
    {
        public UserDeviceListResponse(List<UserDevice> listResource) : base(listResource)
        {
        }
    }
}
