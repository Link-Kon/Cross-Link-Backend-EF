using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public class BaseResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T Resource { get; private set; }
        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }
        public BaseResponse(T resource)
        {
            if (resource == null)
            {
                Success = false;
                Resource = resource;
            }
            else {
                Success = true;
                Resource = resource;
            }
        }

        public UserData Resource2 { get; private set; }
        public BaseResponse(UserData resource)
        {
            if (resource == null)
            {
                Success = false;
                Resource2 = resource;
            }
            else
            {
                Success = true;
                Resource2 = resource;
            }
        }
    }
}
