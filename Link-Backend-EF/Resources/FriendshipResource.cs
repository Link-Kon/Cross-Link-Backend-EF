namespace Link_Backend_EF.Resources
{
    public class FriendshipResource
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int PatientId { get; set; }
        public int CaretakerId { get; set; }
    }
}
