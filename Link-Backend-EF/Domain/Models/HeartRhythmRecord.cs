namespace Link_Backend_EF.Domain.Models
{
    public class HeartRhythmRecord
    {
        public int Id { get; set; }
        public string LectureDate { get; set; }
        public string Bpm { get; set; }
        public int UserDataId { get; set; }
    }
}
