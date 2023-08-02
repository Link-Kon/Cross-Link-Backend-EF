using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public class IllnessesListResponse : BaseResponse<IllnessesList>
    {
        public IllnessesListResponse(string message) : base(message)
        {
        }

        public IllnessesListResponse(IllnessesList resource) : base(resource)
        {
        }
    }
}
