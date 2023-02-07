using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public class HeartRhythmRecordResponse : BaseResponse<HeartRhythmRecord>
    {
        public HeartRhythmRecordResponse(string message) : base(message)
        {
        }

        public HeartRhythmRecordResponse(HeartRhythmRecord resource) : base(resource)
        {
        }
    }
}
