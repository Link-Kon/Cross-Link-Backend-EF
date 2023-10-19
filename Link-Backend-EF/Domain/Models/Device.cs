using Link_Backend_EF.Domain.Models.Base;

namespace Link_Backend_EF.Domain.Models
{
    public class Device : DateAuditory
    {
        public int Id { get; set; }
        public string? Nickname { get; set; }
        public string MacAddress { get; set; }
        public string Model { get; set; }
        public decimal Version { get; set; } 
        public UserDevice UserDevice { get; set; }

        public Device(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
