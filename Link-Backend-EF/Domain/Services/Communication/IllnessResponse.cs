using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public class IllnessResponse : BaseResponse<Illness>
    {
        public IllnessResponse(string message) : base(message)
        {
        }

        public IllnessResponse(Illness resource) : base(resource)
        {
        }
    }
}
