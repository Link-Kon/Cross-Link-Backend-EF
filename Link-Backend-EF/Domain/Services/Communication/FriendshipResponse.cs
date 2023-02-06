using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public class FriendshipResponse : BaseResponse<Friendship>
    {
        public FriendshipResponse(string message) : base(message)
        {
        }

        public FriendshipResponse(Friendship resource) : base(resource)
        {
        }
    }
}
