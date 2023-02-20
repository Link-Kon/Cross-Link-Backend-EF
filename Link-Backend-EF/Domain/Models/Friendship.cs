namespace Link_Backend_EF.Domain.Models
{
    public class Friendship 
    {
        public bool Active { get; set; }
        public string User1Code { get; set; }
        public string User2Code { get; set; }

        public User User1 { get; set; }
        public User User2 { get; set; }
    }
}
