using Link_Backend_EF.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveUserDataResource : DateAuditory
    {
        [Required]
        public bool State { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string UserPhoto { get; set; }
        [Required]
        public int UserId { get; set; }

        public SaveUserDataResource(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
