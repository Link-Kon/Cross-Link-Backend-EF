using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveIllnessResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Description { get; set; }

        public int? Creator { get; set; }
    }
}
