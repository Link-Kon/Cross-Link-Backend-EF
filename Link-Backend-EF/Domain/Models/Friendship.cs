using Link_Backend_EF.Domain.Models.Base;

namespace Link_Backend_EF.Domain.Models
{
    public class Friendship : DateAuditory
    {
        public int SharedId { get; set; }
        public bool State { get; set; }
        public string User1Code { get; set; }
        public string User2Code { get; set; }

        public User User1 { get; set; }
        public User User2 { get; set; }

        public Friendship(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
