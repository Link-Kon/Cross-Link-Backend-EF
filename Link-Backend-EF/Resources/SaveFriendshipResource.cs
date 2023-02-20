using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveFriendshipResource
    {
        [Required]
        public bool Active { get; set; }
        [Required]
        public string User1Code { get; set; }
        [Required]
        public string User2Code { get; set; }
    }
}
