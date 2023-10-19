using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public class DeviceResponse : BaseResponse<Device>
    {
        public DeviceResponse(string message) : base(message)
        {
        }

        public DeviceResponse(Device resource) : base(resource)
        {
        }
    }
}
