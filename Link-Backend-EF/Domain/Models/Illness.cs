using Link_Backend_EF.Domain.Models.Base;

namespace Link_Backend_EF.Domain.Models
{
    public class Illness : DateAuditory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CreatorId { get; set; }

        public IllnessesList IllnessesList { get; set; }

        public Illness(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
