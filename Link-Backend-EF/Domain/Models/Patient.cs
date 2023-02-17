namespace Link_Backend_EF.Domain.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public Decimal Weight { get; set; }
        public Decimal Height { get; set; }
        public string Country { get; set; }
        public int UserDataId { get; set; }

        public UserData UserData { get; set; }
    }
}
