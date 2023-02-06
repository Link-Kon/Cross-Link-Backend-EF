namespace Link_Backend_EF.Domain.Models
{
    public class UserData
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public string Names { get; set; }
        public string Lastname { get; set; }
        public string UserPhoto { get; set; }
        public int UserId { get; set; }
        List<Illness> Illnesses { get; set; }
    }
}
