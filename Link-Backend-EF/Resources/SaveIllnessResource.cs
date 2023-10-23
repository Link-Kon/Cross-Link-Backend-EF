using Link_Backend_EF.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveIllnessResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int? CreatorId { get; set; }
    }
}
