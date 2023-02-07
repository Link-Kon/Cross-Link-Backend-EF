namespace Link_Backend_EF.Resources
{
    public class HeartIssuesRecordResource
    {
        public int Id { get; set; }
        public DateTime LectureDate { get; set; }
        public string Severity { get; set; }
        public int UserDataId { get; set; }
    }
}
