namespace Link_Backend_EF.Resources
{
    public class HeartRhythmRecordResource
    {
        public int Id { get; set; }
        public DateTime LectureDate { get; set; }
        public int Bpm { get; set; }
        public int PatientId { get; set; }
    }
}
