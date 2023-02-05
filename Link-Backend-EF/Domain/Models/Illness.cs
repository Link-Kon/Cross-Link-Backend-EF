namespace Link_Backend_EF.Domain.Models
{
    public class Illness
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }
        public int? Creator { get; set; }
    }
}
