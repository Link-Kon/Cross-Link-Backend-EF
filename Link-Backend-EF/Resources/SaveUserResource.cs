using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveUserResource
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
