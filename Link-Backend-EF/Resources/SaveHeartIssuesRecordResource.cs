using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveHeartIssuesRecord
    {
        [Required]
        public string LectureDate { get; set; }
        [Required]
        public string Severity { get; set; }
        [Required]
        public int UserDataId { get; set; }
    }
}
