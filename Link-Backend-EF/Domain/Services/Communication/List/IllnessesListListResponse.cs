using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication.List
{
    public class IllnessesListListResponse : BaseResponse<List<IllnessesList>>
    {
        public IllnessesListListResponse(List<IllnessesList> listResource) : base(listResource)
        {
        }
    }
}
