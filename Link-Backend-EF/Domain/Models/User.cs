using Link_Backend_EF.Domain.Models.Base;

namespace Link_Backend_EF.Domain.Models
{
    public class User : DateAuditory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserData UserData { get; set; }
        public List<Friendship> Friendships { get; set; }

        public User(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
