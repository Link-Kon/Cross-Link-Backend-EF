using Link_Backend_EF.Domain.Models.Base;

namespace Link_Backend_EF.Domain.Models
{
    public class UserDevice : DateAuditory
    {
        public int Id { get; set; }
        public int UserDataId { get; set; }
        public int DeviceId { get; set; }
        public bool State {get; set; }

        public UserData UserData { get; set; }
        public Device Device { get; set; }
    }
}
