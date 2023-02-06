using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public class FallRecordResponse : BaseResponse<FallRecord>
    {
        public FallRecordResponse(string message) : base(message)
        {
        }

        public FallRecordResponse(FallRecord resource) : base(resource)
        {
        }
    }
}
