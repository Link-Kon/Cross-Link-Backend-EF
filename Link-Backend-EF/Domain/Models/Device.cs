namespace Link_Backend_EF.Domain.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Model { get; set; }
        public double Version { get; set; }
        public UserDevice UserDevice { get; set; }
    }
}
