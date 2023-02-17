using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveFallRecordResource
    {
        [Required]
        public DateTime LectureDate { get; set; }
        [Required]
        public string Severity { get; set; }
        [Required]
        public int UserDataId { get; set; }
    }
}
