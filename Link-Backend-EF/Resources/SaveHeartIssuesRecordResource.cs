using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveHeartIssuesRecordResource
    {
        [Required]
        public DateTime LectureDate { get; set; }
        [Required]
        public string Severity { get; set; }
        [Required]
        public int PatientId { get; set; }
    }
}
