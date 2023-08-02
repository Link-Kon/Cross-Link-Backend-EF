using Link_Backend_EF.Domain.Models.Base;

namespace Link_Backend_EF.Domain.Models
{
    public class IllnessesList : DateAuditory
    {
        public int Id { get; set; }
        public int UserDataId { get; set; }
        public int IllnessId { get; set; }
        public bool State { get; set; }


        public UserData UserData { get; set; }
        public Illness Illness { get; set; }

        public IllnessesList(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
