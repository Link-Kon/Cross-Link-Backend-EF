using Link_Backend_EF.Domain.Models.Base;

namespace Link_Backend_EF.Domain.Models
{
    public class UserData : DateAuditory
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string UserPhoto { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Patient Patient { get; set; }
        public List<Illness> Illnesses { get; set; }
        public UserDevice UserDevice { get; set; }

        public UserData(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
