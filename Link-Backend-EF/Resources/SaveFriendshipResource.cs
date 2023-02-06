using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveFriendshipResource
    {
        [Required]
        public bool Active { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int CaretakerId { get; set; }
    }
}
