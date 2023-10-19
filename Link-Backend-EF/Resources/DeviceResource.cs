namespace Link_Backend_EF.Resources
{
    public class DeviceResource
    {
        public int Id { get; set; }
        public string? Nickname { get; set; }
        public string MacAddress { get; set; }
        public string Model { get; set; }
        public decimal Version { get; set; }
    }
}
