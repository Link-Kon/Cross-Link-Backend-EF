namespace Link_Backend_EF.Domain.Models
{
    public class UserDevice
    {
        public int Id { get; set; }
        public int UserDataId { get; set; }
        public int DeviceId { get; set; }
        public bool State {get; set; }

        public UserData UserData { get; set; }
        public Device Device { get; set; }
    }
}
