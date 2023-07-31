using Link_Backend_EF.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveHeartRhythmRecordResource : DateAuditory
    {
        [Required]
        public DateTime LectureDate { get; set; }
        [Required]
        public int Bpm { get; set; }
        [Required]
        public int PatientId { get; set; }

        public SaveHeartRhythmRecordResource(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
