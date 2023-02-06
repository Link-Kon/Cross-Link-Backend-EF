using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public class HeartIssuesRecordResponse : BaseResponse<HeartIssuesRecord>
    {
        public HeartIssuesRecordResponse(string message) : base(message)
        {
        }

        public HeartIssuesRecordResponse(HeartIssuesRecord resource) : base(resource)
        {
        }
    }
}
