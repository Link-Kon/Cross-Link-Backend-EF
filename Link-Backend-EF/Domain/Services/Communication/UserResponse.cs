using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(string message) : base(message)
        {
        }

        public UserResponse(User resource) : base(resource)
        {   
        }

        public UserResponse(UserData resource) : base(resource)
        {
        }
    }
}
