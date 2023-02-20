namespace Link_Backend_EF.Domain.Models
{
    public class HeartIssuesRecord
    {
        public int Id { get; set; }
        public DateTime LectureDate { get; set; }
        public string Severity { get; set; }
        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
