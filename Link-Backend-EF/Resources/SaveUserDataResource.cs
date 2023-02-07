using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveUserDataResource
    {
        [Required]
        public bool Active { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Names { get; set; }
        public string Lastname { get; set; }
        public string UserPhoto { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
