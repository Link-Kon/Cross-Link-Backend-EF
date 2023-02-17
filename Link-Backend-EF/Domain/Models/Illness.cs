namespace Link_Backend_EF.Domain.Models
{
    public class Illness
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CreatorId { get; set; }

        //public UserData? Creator { get; set; }
        public List<UserData> UsersData { get; set; }
    }
}
