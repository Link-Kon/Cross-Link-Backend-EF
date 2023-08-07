using Link_Backend_EF.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveFriendshipResource : DateAuditory
    {
        [Required]
        public bool State { get; set; }
        [Required]
        public string User1Code { get; set; }
        [Required]
        public string User2Code { get; set; }

        public SaveFriendshipResource(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
