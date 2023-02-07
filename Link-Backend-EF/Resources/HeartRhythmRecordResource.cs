namespace Link_Backend_EF.Resources
{
    public class HeartRhythmRecordResource
    {
        public int Id { get; set; }
        public DateTime LectureDate { get; set; }
        public string Bpm { get; set; }
        public int UserDataId { get; set; }
    }
}
