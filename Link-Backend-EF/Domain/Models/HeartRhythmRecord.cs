﻿namespace Link_Backend_EF.Domain.Models
{
    public class HeartRhythmRecord
    {
        public int Id { get; set; }
        public DateTime LectureDate { get; set; }
        public int Bpm { get; set; }
        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
