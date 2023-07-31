using Link_Backend_EF.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveFallRecordResource : DateAuditory
    {
        [Required]
        public DateTime LectureDate { get; set; }
        [Required]
        public string Severity { get; set; }
        [Required]
        public int PatientId { get; set; }

        public SaveFallRecordResource(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
