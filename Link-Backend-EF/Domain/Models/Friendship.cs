namespace Link_Backend_EF.Domain.Models
{
    public class Friendship 
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int PatientId { get; set; }
        public int CaretakerId { get; set; }
    }
}
